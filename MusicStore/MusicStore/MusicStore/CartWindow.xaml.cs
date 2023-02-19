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
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        MusicStoreContext context;

        Settings settings = new Settings();
        ShoppingCart cartAlbums = ShoppingCart.GetCart();

        public CartWindow()
        {
            InitializeComponent();

            context = new MusicStoreContext();

            ShoppingCart cart = ShoppingCart.GetCart();
            lvCart.ItemsSource = cart.GetCartItems();
            txtTotal.Text = cart.GetTotal().ToString(".00");
            btnCheckout.IsEnabled = !string.IsNullOrEmpty(settings.UserName) && cart.GetTotal() > 0;
        }

        public CartWindow(ShoppingCart cart)
        {
            InitializeComponent();
            cartAlbums = cart;
            lvCart.ItemsSource = cart.GetCartItems();
            txtTotal.Text = cart.GetTotal().ToString(".00");
            btnCheckout.IsEnabled = !string.IsNullOrEmpty(settings.UserName) && cart.GetTotal() > 0;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            CheckoutWindow checkoutWindow = new CheckoutWindow();
            checkoutWindow.ShowDialog();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Cart c =  b.CommandParameter as Cart;
            cartAlbums.RemoveFromCart(c.RecordId);
            lvCart.ItemsSource = cartAlbums.GetCartItems();
            btnCheckout.IsEnabled = !string.IsNullOrEmpty(settings.UserName) && cartAlbums.GetTotal() > 0;

        }
    }
}
