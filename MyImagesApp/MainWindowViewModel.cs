using MyImagesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private HomeViewModel homeViewModel = new HomeViewModel();
        private LoginViewModel loginViewModel = new LoginViewModel();
        private AddImageViewModel addImageViewModel = new AddImageViewModel();
        private ProfileViewModel profileViewModel = new ProfileViewModel();
        private MeniViewModel meniViewModel = new MeniViewModel();
        private BindableBase currentViewModel;
        private BindableBase currentMeni;

        private static MainWindowViewModel _instance;

        public static MainWindowViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindowViewModel();

                return _instance;
            }
        }

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = loginViewModel;
            CurrentMeni = null;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public BindableBase CurrentMeni
        {
            get { return currentMeni; }
            set
            {
                SetProperty(ref currentMeni, value);
            }
        }

        public void OnNav(string destination)
        {

            switch (destination)
            {
                case "home":
                    CurrentViewModel = homeViewModel;
                    CurrentMeni = meniViewModel;
                    break;
                case "viewProfile":
                    CurrentViewModel = profileViewModel;
                    CurrentMeni = meniViewModel;
                    break;
                case "login":
                    CurrentViewModel = loginViewModel;
                    CurrentMeni = null;
                    break;
                case "addImage":
                    CurrentViewModel = addImageViewModel;
                    CurrentMeni = meniViewModel;
                    break;
            }

        }

    }
}
