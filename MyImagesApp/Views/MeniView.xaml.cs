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
    /// Interaction logic for MeniView.xaml
    /// </summary>
    public partial class MeniView : UserControl
    {
        ImageBrush brush = new ImageBrush();
        ImageBrush brush2 = new ImageBrush();

        public MeniView()
        {
            InitializeComponent();
            this.DataContext = new MyImagesApp.ViewModel.MeniViewModel();
            LoadButtons();

            txtUser.Text = MainWindow.currentUser.Username;
        }

        private void LoadButtons()
        {
            expander.IsExpanded = false;
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img12.png"));
            brush.Stretch = Stretch.Uniform;
            btnAddImage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img10.png"));
            brush2.Stretch = Stretch.Uniform;
            btnProfile.Background = brush2;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img13.png"));
            btnAddImage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img10.png"));
            btnProfile.Background = brush2;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img12.png"));
            btnAddImage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/img11.png"));
            btnProfile.Background = brush2;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            LoadButtons();
        }
    }
}
