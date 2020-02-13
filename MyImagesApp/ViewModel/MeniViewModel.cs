using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp.ViewModel
{
    public class MeniViewModel : BindableBase, INotifyPropertyChanged
    {
        public MyICommand HomeCommand { get; set; }
        public MyICommand AddImageCommand { get; set; }
        public MyICommand ProfileCommand { get; set; }
        public MyICommand LogoutCommand { get; set; }

        public MeniViewModel()
        {
            HomeCommand = new MyICommand(Home);
            AddImageCommand = new MyICommand(AddImage);
            ProfileCommand = new MyICommand(Profile);
            LogoutCommand = new MyICommand(Logout);
        }

        private void Home()
        {
            MainWindowViewModel.Instance.OnNav("home");
        }

        private void AddImage()
        {
            MainWindowViewModel.Instance.OnNav("addImage");
        }

        private void Profile()
        {
            MainWindowViewModel.Instance.OnNav("viewProfile");
        }

        private void Logout()
        {
            MainWindowViewModel.Instance.OnNav("login");
        }
    }
}
