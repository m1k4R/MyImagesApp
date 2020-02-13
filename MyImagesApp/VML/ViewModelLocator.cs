using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyImagesApp.VML
{
    public static class ViewModelLocator
    {
        public static readonly DependencyProperty AutoHookedUpViewModelProperty = DependencyProperty.RegisterAttached("AutoHookedUpViewModel",
            typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoHookedUpViewModelChanged));

        public static bool GetAutoHookedUpViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
        }

        public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoHookedUpViewModelProperty, value);
        }

        public static void AutoHookedUpViewModelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs arg)
        {
            if (DesignerProperties.GetIsInDesignMode(obj))
            {
                return;
            }

            var viewType = obj.GetType();
            string str = viewType.FullName;
            str = str.Replace(".Views", ".ViewModel");
            var viewTypeName = str;

            var viewModelTypeName = viewTypeName + "Model";
            var viewModelType = Type.GetType(viewModelTypeName);
            var viewModel = Activator.CreateInstance(viewModelType);

            ((FrameworkElement)obj).DataContext = viewModel;
        }
    }
}
