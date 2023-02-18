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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {

            InitializeComponent();

        }
        public MainWindow(Boolean checkAdmin)
        {

            InitializeComponent();
            album.IsEnabled = checkAdmin;

        }
        private void album_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    

     private void ShoppingOnClick(object sender, RoutedEventArgs e)
        {
            ShoppingWindow shop = new ShoppingWindow();
            shop.ShowDialog();
        }

        private void AlbumOnClick(object sender, RoutedEventArgs e)
        {
            AlbumWindow album = new AlbumWindow();
            album.ShowDialog();
        }
        private void CartOnClick(object sender, RoutedEventArgs e)
        {
            CartWindow cart = new CartWindow();
            cart.ShowDialog();
        }
        private void LoginOnClick(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            this.Close();
            login.ShowDialog();
            
        }

      
    }
}
