using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WorkPlanner.Catalog;
using WorkPlanner.View;

namespace WorkPlanner.Common
{
    public static class ChangePage
    {

       public static void Logout()
       {
            EmployeesSingleton.Instance.EmployeesObject = null;
            new NavigateToNewPage<MainPage>().Navigate();
       }

       public static void Admin()
       {
          new NavigateToNewPage<AdminPage>().Navigate();
       }
    }

    public class NavigateToNewPage<T> where T : Page
    {
        public void Navigate()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(T));
            Window.Current.Content = frame;
            Window.Current.Activate();
        }      
    }
}
