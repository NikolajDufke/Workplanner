using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Visibility = Windows.UI.Xaml.Visibility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WorkPlanner.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        public AdminPage()
        {
            this.InitializeComponent();
            //DroppedPanel.Visibility == Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DropDownClick(object sender, RoutedEventArgs e)
        {
            //DroppedPanel.Visibility == Visibility.Visible;
        }


        private void Create(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateEmployeePage));
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateEmployeePage));
        }

        //private void Edit(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof());
        //}
    }
}
