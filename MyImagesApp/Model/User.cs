using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp.Model
{
    public class User : ValidationBase
    {
        public string username;
        public string password;
        public List<MyImage> Images { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public User() { }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Username is required.";
            }
            else if (UserData.Instance.CheckIfUserExists(this.username))
            {
                this.ValidationErrors["Username"] = "Username already exists.";
            }
            else if (char.IsDigit(this.username[0]))
            {
                this.ValidationErrors["Username"] = "The first character cannot be a number.";
            }
            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Password is required.";
            }
            else if ((this.password).Length <= 6)
            {
                this.ValidationErrors["Password"] = "Password must be longer than 6 characters.";
            }
        }

        protected override void Login()
        {
            User user = null;

            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Username is required.";
            }
            else if (!UserData.Instance.CheckIfUserExists(this.username))
            {
                this.ValidationErrors["Username"] = "Wrong username.";
            }
            else
            {
                user = UserData.Instance.GetUser(this.username);
            }

            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Password is required.";
            }
            else if (user == null || !user.Password.Equals(this.password))
            {
                this.ValidationErrors["Password"] = "Wrong password.";
            }
        }

        protected override void EditProfile()
        {
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Username is required.";
            }
            else if (!this.username.Equals(MainWindow.currentUser.Username))
            {
                if (UserData.Instance.CheckIfUserExists(this.username))
                {
                    this.ValidationErrors["Username"] = "Username already exists.";
                }
            }
            else if (char.IsDigit(this.username[0]))
            {
                this.ValidationErrors["Username"] = "The first character cannot be a number.";
            }
            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Password is required.";
            }
            else if ((this.password).Length <= 6)
            {
                this.ValidationErrors["Password"] = "Password must be longer than 6 characters.";
            }
        }
    }
}
