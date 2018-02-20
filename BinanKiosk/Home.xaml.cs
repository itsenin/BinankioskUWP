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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public class MenuItem
    { 
        public string IName
        {
            get; set;
        }
    }
    public sealed partial class Home : Page
    {
        public Home()
        {

            this.InitializeComponent();
            DispatcherTimer Timer = new DispatcherTimer();
            DataContext = this;
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            ObservableCollection<MenuItem> items = new ObservableCollection<MenuItem>();
            items.Add(new MenuItem()
            {
                IName = "ms-appx:///Assets/Slides/10.jpg"
            });
            items.Add(new MenuItem()
            {
                IName = "ms-appx:///Assets/Slides/11.jpg"
            });
            items.Add(new MenuItem()
            {
                IName = "ms-appx:///Assets/Slides/13.jpg"
            });
            
            ROTtest.ItemsSource = items;
        }
        

        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy")+ System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }

        private void Mapbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Map_1f));
        }

        private void Servicesbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Services));
        }

        private void Jobsbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(v_Job_Category));
        }
    }
}
