using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for ShoppingWindow.xaml
    /// </summary>
    public partial class ShoppingWindow : Window
    {
        MusicStoreContext context = new MusicStoreContext();
        public ShoppingWindow()
        {
            InitializeComponent();
            cbGenre.ItemsSource = context.Genres.ToList().Select(genre => genre.Name).ToList();
            cbGenre.SelectedIndex = 0;
            bindGrid(1);
        }

        private void bindGrid(int pageIndex)
        {
            var albumIQ = context.Albums.Where(a => a.GenreId == (int) cbGenre.SelectedValue);
            int i = 0;
            foreach (var sp in listView.Children)
            {
                foreach(var obj in ((StackPanel)sp).Children)
                {
                    if (obj is Image)
                    {
                        ((Image)obj).Source = null;
                    }
                    if (obj is Label)
                    {
                        ((Label)obj).Content = "";
                    }
                    if (obj is Button)
                    {
                        ((Button)obj).Visibility = Visibility.Hidden;
                    }
                    
                }
                i++;
                
            }
            i = 0;
            /*
            pages = PaginatedList<Album>.Create(albumIQ, pageIndex, 4);
            foreach (var sp in listView.Children)
            {
                if(i < pages.Count)
                {
                    foreach(var obj in ((StackPanel)sp).Children)
                    {
                        if(obj is Image)
                        {
                            try
                            {
                                string path = pages[i].AlbumUrl.Re
                            }
                        }
                    }
                }
            }
            */
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            bindGrid(1);
            //cbGenre.ItemsSource = context.Genres.ToList().Select(genre => genre.Name).ToList();

        }
    }
}
