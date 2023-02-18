using Microsoft.EntityFrameworkCore;
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
        int previous = 0;
        int next = 0;
        public ShoppingWindow()
        {
            InitializeComponent();
            cbGenre.ItemsSource = context.Genres.ToList().Select(genre => genre.Name).ToList();
            next = previous + 1;
            LoadData();
        }

        private async void LoadData()
        {
            var query = context.Albums.OrderBy(ab => ab.AlbumId);
            var paginatedList = await PaginatedList<Album>.CreateAsync(query, 1, 4);
            lvAlbums.ItemsSource = paginatedList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void previousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
