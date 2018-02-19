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
    public sealed partial class v_Job_Category : Page
    {
        JobRepository jobRepository = new JobRepository();
        DispatcherTimer Timer = new DispatcherTimer();
        public v_Job_Category()
        {
            this.InitializeComponent();
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            ObservableCollection<M_Job_Category> items = new ObservableCollection<M_Job_Category>();
            foreach (var Category in jobRepository.GetAll_JobCategories())
            {
                items.Add(new M_Job_Category()
                {
                    Job_ID = Category.Job_ID,
                    Job_Name = Category.Job_Name
                });
            }
            AdaptiveGridViewControl.ItemsSource = items;
        }
        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }
        private void AdaptiveGridViewControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            var _Category = e.ClickedItem as M_Job_Category;
            Frame.Navigate(typeof(v_Job_List), _Category);
        }

        private void JobButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(v_Job_Category));
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Home));
        }
    }
}
