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
    public sealed partial class Search : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();

        private IList<M_Job_Category> Job_Categories;
        private IList<Official> Officials;
        private IList<Service> Services;

        private JobRepository jobRepository;
        private OfficialRepository officialRepository;
        private DepartmentRepository departmentRepository;
        private ServiceRepository serviceRepository;

        private Categories SelectedItem;
        private class Items
        {
            public string Objectname { get; set; }
            public object itemObject { get; set; }
            public Categories itemCategory { get; set; }

        }
        private enum Categories { Officer, Office, Service, Job, All }
        private enum SearchType { All, Filtered }
        //Constructor
        public Search()
        {
            this.InitializeComponent();
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            jobRepository = new JobRepository();
            officialRepository = new OfficialRepository();
            departmentRepository = new DepartmentRepository();
            serviceRepository = new ServiceRepository();

            Job_Categories = jobRepository.GetAll_JobCategories();
            Officials = officialRepository.GetAll_Official();
            Services = serviceRepository.GetAll_Service();
        }
        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }

        private void AdaptiveGridViewControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Item = e.ClickedItem as Items;
            switch (Item.itemCategory)
            {
                case Categories.Officer:
                    Frame.Navigate(typeof(Official_Result), Item.itemObject);
                    break;

                case Categories.Office:
                    Frame.Navigate(typeof(Department_Result), Item.itemObject);
                    break;

                case Categories.Service:
                    break;

                case Categories.Job:
                    Frame.Navigate(typeof(v_Job_List), Item.itemObject);
                    break;
            }
            var _Category = e.ClickedItem;

            //MessageDialog md = new MessageDialog(e.ClickedItem);
            //await md.ShowAsync();
            //Frame.Navigate(typeof(Job_List), _Category);

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            //MessageDialog md;
            if (rb != null)
            {
                string CategoryType = rb.Tag.ToString();
                switch (CategoryType)
                {
                    case "Officers":
                        SelectedItem = Categories.Officer;
                        Officials = officialRepository.GetAll_Official();
                        break;
                    case "Offices":
                        SelectedItem = Categories.Office;
                        Officials = officialRepository.GetAll_Official();
                        break;
                    case "Services":
                        SelectedItem = Categories.Service;
                        Services = serviceRepository.GetAll_Service();
                        break;
                    case "Jobs":
                        SelectedItem = Categories.Job;
                        Job_Categories = jobRepository.GetAll_JobCategories();
                        break;
                    case "All":
                        SelectedItem = Categories.All;
                        break;
                }
                AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
            }

        }
        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
        }
        private ObservableCollection<Items> PopulateGrid(Categories category, SearchType searchType)
        {
            ObservableCollection<Items> items = new ObservableCollection<Items>();
            if (category.Equals(Categories.Officer) || category.Equals(Categories.All))
            {
                if (searchType.Equals(SearchType.All))
                {
                    foreach (var official in Officials)
                    {
                        items.Add(new Items()
                        {
                            Objectname = official.First_Name + " " + official.Middle_Initial + " " + official.Last_Name + " " + official.Suffix,
                            itemObject = official,
                            itemCategory = Categories.Officer
                        });
                    }
                }
                else
                {
                    //checks the official list then check if it contains the string in the textbox
                    var Filtered_Officials = Officials.Where(stringToCheck => (stringToCheck.First_Name + " " + stringToCheck.Middle_Initial + " " + stringToCheck.Last_Name + " " + stringToCheck.Suffix).ToLower().Contains(tb_Search.Text.ToLower()));
                    foreach (var official in Filtered_Officials)
                    {
                        items.Add(new Items()
                        {
                            Objectname = official.First_Name + " " + official.Middle_Initial + " " + official.Last_Name + " " + official.Suffix,
                            itemObject = official,
                            itemCategory = Categories.Officer
                        });
                    }
                }
            }

            if (category.Equals(Categories.Office) || category.Equals(Categories.All))
            {
                if (searchType.Equals(SearchType.All))
                {
                    foreach (var official in Officials)
                    {
                        items.Add(new Items()
                        {
                            Objectname = official.department.Department_Name,
                            itemObject = official,
                            itemCategory = Categories.Office
                        });
                    }
                }
                else
                {
                    var Filtered_Offices = Officials.Where(stringToCheck => stringToCheck.department.Department_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    foreach (var official in Filtered_Offices)
                    {
                        items.Add(new Items()
                        {
                            Objectname = official.department.Department_Name,
                            itemObject = official,
                            itemCategory = Categories.Office
                        });
                    }
                }
            }

            if (category.Equals(Categories.Job) || category.Equals(Categories.All))
            {
                if (searchType.Equals(SearchType.All))
                {
                    foreach (var Job_Category in Job_Categories)
                    {
                        items.Add(new Items()
                        {
                            Objectname = Job_Category.Job_Name,
                            itemObject = Job_Category,
                            itemCategory = Categories.Job
                        });
                    }
                }
                else
                {
                    var Filtered_Jobs = Job_Categories.Where(stringToCheck => stringToCheck.Job_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    foreach (var Job_Category in Filtered_Jobs)
                    {
                        items.Add(new Items()
                        {
                            Objectname = Job_Category.Job_Name,
                            itemObject = Job_Category,
                            itemCategory = Categories.Job
                        });
                    }
                }
            }

            if (category.Equals(Categories.Service) || category.Equals(Categories.All))
            {
                if (searchType.Equals(SearchType.All))
                {
                    foreach (var service in Services)
                    {
                        items.Add(new Items()
                        {
                            Objectname = service.Service_Name,
                            itemObject = service,
                            itemCategory = Categories.Service
                        });
                    }
                }
                else
                {
                    //checks the official list then check if it contains the string in the textbox
                    var Filtered_Services = Services.Where(stringToCheck => stringToCheck.Service_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    foreach (var service in Filtered_Services)
                    {
                        items.Add(new Items()
                        {
                            Objectname = service.Service_Name,
                            itemObject = service,
                            itemCategory = Categories.Service
                        });
                    }
                }
            }

            return items;
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
