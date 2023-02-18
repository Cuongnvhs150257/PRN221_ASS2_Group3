﻿using MusicStore.Models;
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
                MessageBox.Show("Tài khoản không tồn tại");

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

                MessageBox.Show("Login Success");
                this.Close();
                
            }
        }
    }
}
