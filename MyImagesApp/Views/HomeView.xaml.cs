using MyImagesApp.Model;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = new MyImagesApp.ViewModel.HomeViewModel();

            spHome.Children.Clear();

            foreach (MyImage image in HomeViewModel.Images)
            {
                StackPanel sp = new StackPanel { Height = 260, Background = new SolidColorBrush(Colors.White), Margin = new Thickness(0, 0, 0, 50) };
                sp.Children.Add(new Image { Height = 200, Source = new BitmapImage(new Uri(image.Path)), Stretch = Stretch.UniformToFill });
                sp.Children.Add(new TextBlock { TextWrapping = TextWrapping.Wrap, Text = image.Title, FontSize = 16, FontFamily = new FontFamily("Kristen ITC") });
                sp.Children.Add(new TextBlock { TextWrapping = TextWrapping.Wrap, Text = image.Description, FontSize = 14, FontFamily = new FontFamily("Kristen ITC") });
                sp.Children.Add(new TextBlock { TextWrapping = TextWrapping.Wrap, Text = image.Date, FontSize = 11, Foreground = new SolidColorBrush(Colors.Gray), FontFamily = new FontFamily("Kristen ITC") });

                spHome.Children.Add(sp);
            }
        }
    }
}
