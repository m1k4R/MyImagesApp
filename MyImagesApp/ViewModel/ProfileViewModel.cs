using MyImagesApp.Model;
using MyImagesApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp.ViewModel
{
    public class ProfileViewModel : BindableBase, INotifyPropertyChanged
    {
        private User user = new User();
        private string oldPassword;
        private string validateOldPassword;

        public MyICommand ApplyChangesCommand { get; set; }

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

        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                if (oldPassword != value)
                {
                    oldPassword = value;
                    OnPropertyChanged("OldPassword");
                }
            }
        }

        public string ValidateOldPassword
        {
            get
            {
                return validateOldPassword;
            }
            set
            {
                if (validateOldPassword != value)
                {
                    validateOldPassword = value;
                    OnPropertyChanged("ValidateOldPassword");
                }
            }
        }

        public ProfileViewModel()
        {
            ApplyChangesCommand = new MyICommand(ApplyChanges);
            Initialize();
        }

        private void Initialize()
        {
            if (MainWindow.currentUser != null)
            {
                User = new User { Username = MainWindow.currentUser.Username, Password = MainWindow.currentUser.Password };
            }
        }

        private void ApplyChanges()
        {
            User.Username = ProfileView.username;
            User.Password = ProfileView.password;
            oldPassword = ProfileView.oldPassword;

            User.ValidateEditProfile();

            if (User.IsValid)
            {
                if (oldPassword.Equals(MainWindow.currentUser.Password))
                {
                    User changedUser = new User { Username = User.Username, Password = User.Password };
                    UserData.Instance.EditUser(changedUser, MainWindow.currentUser.Username);
                    MainWindow.currentUser = UserData.Instance.GetUser(User.Username);
                    ValidateOldPassword = "";
                    MainWindowViewModel.Instance.OnNav("home");
                }
                else
                {
                    ValidateOldPassword = "Wrong password.";
                }
               
            }
        }
    }
}
