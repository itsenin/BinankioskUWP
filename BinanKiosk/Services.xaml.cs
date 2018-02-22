using BinanKiosk.Models;
using BinanKiosk.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Services : Page
    {
        private IList<Service> postsList = new List<Service>(); //Given List
        private IList<Service> displayPostsList = new List<Service>(); //List to be displayed in ListView
        int pageIndex = -1;
        int pageSize = 6; //Set the size of the page
        int totalPage = 0;

        ServiceRepository serviceRepository = new ServiceRepository();
        DispatcherTimer Timer = new DispatcherTimer();
        ObservableCollection<Service> items;

        public Services()
        {
            this.InitializeComponent();

            //For the time
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            //Instantiation of List of services
            items = new ObservableCollection<Service>();

            Right_Click(null, null);
            // Populating the list from the database
            postsList = serviceRepository.GetAll_Service();
            totalPage = postsList.Count / 6;
            AdaptiveGridViewControl.ItemsSource = Service_Populator();

        } //end of Services constructor

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if ((pageIndex + 1) <= totalPage)
            {
                pageIndex++;
                AdaptiveGridViewControl.ItemsSource = Service_Populator();
            }

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if ((pageIndex + 1) >= totalPage)
            {
                pageIndex--;
                AdaptiveGridViewControl.ItemsSource = Service_Populator();
            }

        }
        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }
        private void AdaptiveGridViewControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var _Category = e.ClickedItem as M_Job_Category;
            //Frame.Navigate(typeof(Services_View), _Category);
            Frame.Navigate(typeof(Services_View));
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

        private void Jobsbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(v_Job_Category));
        }

        private void Servicesbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Services));
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private ObservableCollection<Service> Service_Populator()
        {
            items.Clear();
            displayPostsList = postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            //For populating the Adaptive Grid View
            foreach (var service in displayPostsList)
            {
                items.Add(new Service()
                {
                    Service_ID = service.Service_ID,
                    Service_Name = service.Service_Name
                });
            }
            return items;
        }
        
    }
}
