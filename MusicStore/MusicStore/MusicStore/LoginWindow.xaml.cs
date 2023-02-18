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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {   
        Settings settings = new Settings();

        Boolean checkAdmin;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MusicStoreContext context = new MusicStoreContext();
            User user = context.Users.Where(u => u.UserName == txtUser.Text
            && u.Password == txtPass.Text).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("This account doesn't exist");

            }
            else if(user.UserName == "admin")
            {
                MessageBox.Show("Admin Login Success");
                checkAdmin = true;
                MainWindow main = new MainWindow(checkAdmin);
                main.ShowDialog();
                this.Close();
            }
            else
            {
                settings.UserName = user.UserName;
                settings.Role = user.Role;
                ShoppingCart cart = ShoppingCart.GetCart();
                cart.MigrateCart();
                MessageBox.Show("Login Success");
                this.Close();
                
            }
        }
    }
}
