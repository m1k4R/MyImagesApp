using MyImagesApp.ViewModel;
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
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public static string username;
        public static string password;
        public static string oldPassword;

        public ProfileView()
        {
            InitializeComponent();
            this.DataContext = new MyImagesApp.ViewModel.ProfileViewModel();

            ShowProfile();
        }

        public void ShowProfile()
        {
            labelUsername.Visibility = Visibility.Hidden;
            LabelPassword.Visibility = Visibility.Hidden;
            LabelNewPassword.Visibility = Visibility.Hidden;
            txtUsername.Visibility = Visibility.Hidden;
            txtOldPassword.Visibility = Visibility.Hidden;
            txtNewPassword.Visibility = Visibility.Hidden;
            btnApplyChanges.Visibility = Visibility.Hidden;
            btnEditProfile.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Hidden;
            txtName.Text = MainWindow.currentUser.Username;
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            labelUsername.Visibility = Visibility.Visible;
            LabelPassword.Visibility = Visibility.Visible;
            LabelNewPassword.Visibility = Visibility.Visible;
            txtUsername.Visibility = Visibility.Visible;
            txtOldPassword.Visibility = Visibility.Visible;
            txtNewPassword.Visibility = Visibility.Visible;
            btnApplyChanges.Visibility = Visibility.Visible;
            btnEditProfile.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Visible;
        }

        private void btnApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            username = txtUsername.Text;
            password = txtNewPassword.Password;
            oldPassword = txtOldPassword.Password;
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowProfile();
        }
    }
}
