using Microsoft.Win32;
using MyImagesApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImagesApp.ViewModel
{
    public class AddImageViewModel : BindableBase, INotifyPropertyChanged
    {
        private MyImage image = new MyImage();

        public MyICommand AddImageCommand { get; set; }
        public MyICommand LoadImageCommand { get; set; }

        public AddImageViewModel()
        {
            AddImageCommand = new MyICommand(AddImage);
            LoadImageCommand = new MyICommand(LoadImage);
        }

        public MyImage Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        

        private void AddImage()
        {
            Image.Validate();

            if (Image.IsValid)
            {
                MyImage newImage = new MyImage
                {
                    Title = Image.Title,
                    Description = Image.Description,
                    Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    Path = Image.Path
                };

                UserData.Instance.AddUserImage(MainWindow.currentUser, newImage);

                MainWindowViewModel.Instance.OnNav("home");
            }

            
        }

        private void LoadImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (.jpg;.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (.png)|.png";

            if (dlg.ShowDialog() == true)
            {
                Image.Path = dlg.FileName;
            }
        }
    }
}
