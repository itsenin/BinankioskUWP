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
using BinanKiosk.Models;
using BinanKiosk.Repository;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Job_List : Page
    {
        JobRepository jobRepository = new JobRepository();

        private M_Job_Category _Category;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _Category = (M_Job_Category)e.Parameter;
            ObservableCollection<M_Job_Type> items = new ObservableCollection<M_Job_Type>();
            foreach (var JobType in jobRepository.GetAll_JobTypes(_Category))
            {
                items.Add(new M_Job_Type()
                {
                    JobType_ID = JobType.JobType_ID,
                    Category = new M_Job_Category { Job_ID = JobType.Category.Job_ID, Job_Name = JobType.Category.Job_Name },
                    Job_Company = JobType.Job_Company,
                    Job_Description = JobType.Job_Description,
                    Job_Location = JobType.Job_Location,
                    Job_Types = JobType.Job_Types
                });
            }
            if (items.Count <= 0)
            {
                tb_Result.Text = "No Result";
                img_trans.Visibility = Visibility.Visible;
            }
            listViewControl.ItemsSource = items;
        }

        public Job_List()
        {
            this.InitializeComponent();
            DispatcherTimer Timer = new DispatcherTimer();
            DataContext = this;
            Timer.Tick += Timer_Tick;
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }
        private async void listViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var output = e.AddedItems[0] as M_Job_Type;
            MessageDialog md = new MessageDialog(output.Job_Company);
            await md.ShowAsync();

        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }

        private void Jobsbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Job_Category));
        }
    }
}
