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
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
