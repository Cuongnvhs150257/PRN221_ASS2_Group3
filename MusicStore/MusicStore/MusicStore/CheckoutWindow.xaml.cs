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
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        MusicStoreContext context;

        public CheckoutWindow()
        {
            InitializeComponent();

            context = new MusicStoreContext();
            User user = context.Users.Where(u => u.UserName == Settings.UserName).FirstOrDefault();
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAddress.Text = user.Address;
            txtCity.Text = user.City;
            txtState.Text = user.State;
            txtCountry.Text = user.Country;
            txtPhone.Text = user.Phone;
            txtEmail.Text = user.Email;
            txtTotal.Text = ShoppingCart.GetCart().GetTotal().ToString(".00");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order
            {
                UserName = Settings.UserName,
                OrderDate = DateTime.Now,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text

            };
            ShoppingCart cart = ShoppingCart.GetCart();
            int orderId = cart.CreateOrder(order);
            MessageBox.Show($"Oderd id =  {orderId} is saved! ");
            this.Close();
        }
    }
}
