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

namespace MyImagesApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public static string username;
        public static string password;

        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new MyImagesApp.ViewModel.LoginViewModel();

            ShowLogin();
        }

        private void ShowLogin()
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            username = "";
            password = "";

            labelNewAccount.Content = "Please Log In";
            labelRegister.Visibility = Visibility.Visible;
            btnNewAccount.Visibility = Visibility.Visible;
            btnRegister.Visibility = Visibility.Hidden;
            btnLogin.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Hidden;

            validUsername.Visibility = Visibility.Hidden;
            validPassword.Visibility = Visibility.Hidden;
        }

        private void btnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            username = "";
            password = "";

            labelNewAccount.Content = "Create new account";
            labelRegister.Visibility = Visibility.Hidden;
            btnNewAccount.Visibility = Visibility.Hidden;
            btnRegister.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Visible;

            validUsername.Visibility = Visibility.Hidden;
            validPassword.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Password;

            validUsername.Visibility = Visibility.Visible;
            validPassword.Visibility = Visibility.Visible;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Password;

            validUsername.Visibility = Visibility.Visible;
            validPassword.Visibility = Visibility.Visible;
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowLogin();
        }
    }
}
