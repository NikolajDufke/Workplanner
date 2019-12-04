using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WorkPlanner.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WorkPlanner.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        private AdminPageViewModel viewModel;

        public AdminPage()
        {
            this.InitializeComponent();
            viewModel = new AdminPageViewModel();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEmployeePage));
        }

        private void ToggleButtonOpen(object sender, RoutedEventArgs e)
        {
            if (DroppedPanel.Visibility == Visibility.Visible)
            {
                DroppedPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                DroppedPanel.Visibility = Visibility.Visible;
            }
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {
            AddButton(sender, e);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}

