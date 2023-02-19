using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for ShoppingWindow.xaml
    /// </summary>
    public partial class ShoppingWindow : Window
    {
        MusicStoreContext context = new MusicStoreContext();
        int previous = 1;
        int next = 0;
        ShoppingCart cartAlbums= ShoppingCart.GetCart();
        public ShoppingWindow()
        {
            InitializeComponent();
            cbGenre.ItemsSource = context.Genres.ToList().Select(genre => genre.Name).ToList();
            next = previous + 1;
            bindGrid(previous);
        }


        private async void bindGrid(int pageIndex)
        {
            int i = 0;
            var query = context.Albums.OrderBy(ab => ab.AlbumId);
            List<Album> list = await PaginatedList<Album>.CreateAsync(query, pageIndex, 4);
            PaginatedList<Album> pages = (PaginatedList<Album>)list;
            foreach (var sp in listView.Children)
            {
                if (i < pages.Count)
                {
                    foreach (var obj in ((StackPanel)sp).Children)
                    {
                        if (obj is Label)
                        {
                            ((Label)obj).Content = list[i].Title.ToString() + ": " + pages[i].Price.ToString() + " USD";
                        }
                        if (obj is Image)
                        {
                            try
                            {
                                String path = pages[i].AlbumUrl.Replace('/', '\\');

                                ((Image)obj).Source = new BitmapImage(new Uri($"file://{Directory.GetCurrentDirectory()}{path}"));

                            }
                            catch
                            {
                            }
                        }
                        if (obj is Button)
                        {
                            Button btnAdd = (Button)obj;
                            btnAdd.Visibility = Visibility.Visible;
                            btnAdd.CommandParameter = pages[i].AlbumId;
                           
                            btnAdd.Click += CartOnClick;
                        }
                    }
                }
                i++;
            }
            btnPrevious.IsEnabled = pages.HasPreviousPage;
            btnNext.IsEnabled = pages.HasNextPage;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            bindGrid(1);
        }

        private void previousPage_Click(object sender, RoutedEventArgs e)
        {
            next = previous;
            previous -= 1;
            bindGrid(previous);
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            previous = next;
            next += 1;
            bindGrid(next);
        }

        private void CartOnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int value = (int)button.CommandParameter;
            Album album = context.Albums.SingleOrDefault(al => al.AlbumId == value);
            cartAlbums.AddToCart(album);
            CartWindow cart = new CartWindow(cartAlbums);
            cart.ShowDialog();
            
        }
    }
}
