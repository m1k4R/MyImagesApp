using MyImagesApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp.ViewModel
{
    public class HomeViewModel : BindableBase, INotifyPropertyChanged
    {
        private static List<MyImage> images;

        public static List<MyImage> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
            }
        }

        public HomeViewModel()
        {
            Images = new List<MyImage>();
            Initialize();
        }

        public void Initialize()
        {
            if (MainWindow.currentUser != null)
            {
                Images = new List<MyImage>(UserData.Instance.GetUserImages(MainWindow.currentUser));
            }
        }
    }
}
