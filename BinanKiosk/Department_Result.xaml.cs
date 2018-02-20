using BinanKiosk.Models;
using BinanKiosk.Repository;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Department_Result : Page
    {
        DepartmentRepository departmentRepository = new DepartmentRepository();
        OfficialRepository OfficialRepository = new OfficialRepository();
        DispatcherTimer Timer = new DispatcherTimer();
        private Official official;
        public Department_Result()
        {
            this.InitializeComponent();
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            official = (Official)e.Parameter;
            string Schedule = "Monday to Friday excluding Holidays 8:00 am to 5:00 pm (No Noon Break)";
            tb_DeptName.Text = official.department.Department_Name;
            tb_Department_Description.Text = official.department.Department_Description;
            tb_Official_Name.Text = official.First_Name + " " + official.Middle_Initial + " " + official.Last_Name + " " + official.Suffix;
            tb_Schedule.Text = Schedule;
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
            //this.Frame.Navigate(typeof(Services));
        }

        private void Jobsbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(v_Job_Category));
        }
    }
}
