using Microsoft.Win32;
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
            List<Genre> list= context.Genres.ToList();
            Genre genre=new Genre();
            genre.Name = "All";
            list.Insert(0, genre);
            cbGenre.ItemsSource = list;
            next = previous + 1;
            //bindGridFilter(1, 0);
        }

        private async void bindGridFilter(int pageIndex, int genreId)
        {
            int i = 0;
            var query = context.Albums.OrderBy(ab => ab.AlbumId);
            if (genreId !=0)
            {
                query = context.Albums.Where(album => album.Genre.GenreId == genreId).OrderBy(ab => ab.AlbumId);
            }
            //MessageBox.Show("All size of List Albums Filter: "+query.ToList().Count.ToString());
            
            //var query = context.Albums.Where(album=> album.Genre.GenreId==genreId).OrderBy(ab => ab.AlbumId);
            List<Album> list = await PaginatedList<Album>.CreateAsync(query, pageIndex, 4);
            PaginatedList<Album> pages = (PaginatedList<Album>)list;
            //MessageBox.Show("All size of page List Albums: " + pages.Count);
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
                                string workingDirectory = Environment.CurrentDirectory;
                                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                                ((Image)obj).Source = new BitmapImage(new Uri(projectDirectory + path));
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
                    i++;
                }
                else
                {
                    foreach (var obj in ((StackPanel)sp).Children)
                    {
                        if (obj is Label)
                        {
                            ((Label)obj).Content = "";
                        }
                        if (obj is Image)
                        {
                            try
                            {
                                ((Image)obj).Source = null;
                            }
                            catch
                            {
                            }
                        }
                        if (obj is Button)
                        {
                            ((Button)obj).Visibility = Visibility.Hidden;
                        }
                    }
                    i++;
                }
                
            }
            btnPrevious.IsEnabled = pages.HasPreviousPage;
            btnNext.IsEnabled = pages.HasNextPage;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = cbGenre.SelectedItem as Genre;
            previous = 1;
            next = previous + 1;
            bindGridFilter(previous, genre.GenreId);
        }

        private void previousPage_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = cbGenre.SelectedItem as Genre;
            next = previous;
            previous -= 1;
            if (genre != null)
            {
                bindGridFilter(previous, genre.GenreId);
            }
            else
            {
                bindGridFilter(previous, 0);
            }
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = cbGenre.SelectedItem as Genre;
            previous = next;
            next += 1;
            if (genre != null)
            {
                bindGridFilter(previous, genre.GenreId);
            }
            else
            {
                bindGridFilter(previous, 0);
            }
            
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
