using MyImagesApp.Model;
using MyImagesApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyImagesApp.ViewModel
{
    public class LoginViewModel : BindableBase, INotifyPropertyChanged
    {
        private User user = new User();

        public MyICommand LoginCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        
        public LoginViewModel()
        {
            LoginCommand = new MyICommand(Login);
            RegisterCommand = new MyICommand(Register);
            BackCommand = new MyICommand(Back);

        }

        public User User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        private void Login()
        {
            User.Username = LoginView.username;
            User.Password = LoginView.password;

            User.ValidateLogin();

            if (User.IsValid)
            {
                MainWindow.currentUser = user;
                MainWindowViewModel.Instance.OnNav("home");
            }
        }

        private void Register()
        {
            User.Username = LoginView.username;
            User.Password = LoginView.password;

            User.Validate();

            if (User.IsValid)
            {
                User newUser = new User { Username = User.Username, Password = User.Password };
                UserData.Instance.AddUser(newUser);
                User user = UserData.Instance.GetUser(User.Username);
                MainWindow.currentUser = user;
                MainWindowViewModel.Instance.OnNav("addImage");
            }
        }

        private void Back()
        {
            User.Username = LoginView.username;
            User.Password = LoginView.password;
            User.Validate();
        }
    }
}
