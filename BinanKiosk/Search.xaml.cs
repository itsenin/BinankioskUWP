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
        #region Variables
        DispatcherTimer Timer = new DispatcherTimer();

        private JobRepository jobRepository;
        private OfficialRepository officialRepository;
        private ServiceRepository serviceRepository;

        private Categories SelectedItem;

        private IList<Service> Service_postsList = new List<Service>(); //Given List
        private IList<Service> Service_displayPostsList = new List<Service>(); //List to be displayed in ListView

        private IList<M_Job_Category> Job_postsList = new List<M_Job_Category>(); //Given List
        private IList<M_Job_Category> Job_displayPostsList = new List<M_Job_Category>(); //List to be displayed in ListView

        private IList<Official> Official_postsList = new List<Official>(); //Given List
        private IList<Official> Official_displayPostsList = new List<Official>(); //List to be displayed in ListView

        ObservableCollection<Items> All_postsList = new ObservableCollection<Items>(); //Given List
        private IList<Items> All_displayPostsList = new List<Items>(); //List to be displayed in ListView

        int pageIndex = -1;
        int pageSize = 15; //Set the size of the page
        int Service_totalPage = 0, Job_totalPage = 0, Official_totalPage = 0, All_totalPage;
        #endregion

        #region Enums
        private enum Categories { Officer, Office, Service, Job, All }
        private enum SearchType { All, Filtered }
        #endregion

        private class Items
        {
            public string Objectname { get; set; }
            public object itemObject { get; set; }
            public Categories itemCategory { get; set; }

        }

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
            serviceRepository = new ServiceRepository();

            //populates the list
            Job_postsList = jobRepository.GetAll_JobCategories();
            Official_postsList = officialRepository.GetAll_Official();
            Service_postsList = serviceRepository.GetAll_Service();

            //computes for the total number of pages
            Service_totalPage = Service_postsList.Count / 15;
            Job_totalPage = Job_postsList.Count / 15;
            Official_totalPage = Official_postsList.Count / 15;
            All_totalPage = (Service_postsList.Count + Job_postsList.Count + Official_postsList.Count) / 15;
        }

        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            bool Next = false;
            switch (SelectedItem)
            {
                case Categories.Officer:
                    if ((pageIndex + 1) <= Official_totalPage)
                    {
                        pageIndex++;
                        Next = true;
                    }
                    break;
                case Categories.Office:
                    if ((pageIndex + 1) <= Official_totalPage)
                    {
                        pageIndex++;
                        Next = true;
                    }
                    break;
                case Categories.Service:
                    if ((pageIndex + 1) <= Service_totalPage)
                    {
                        pageIndex++;
                        Next = true;
                    }
                    break;
                case Categories.Job:
                    if ((pageIndex + 1) <= Job_totalPage)
                    {
                        pageIndex++;
                        Next = true;
                    }
                    break;
                case Categories.All:
                    if ((pageIndex + 1) <= All_totalPage)
                    {
                        pageIndex++;
                        Next = true;
                    }
                    break;
            }

            if (Next)
            {
                if (tb_Search.Text.Equals(""))
                    AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
                else
                    AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
            }


        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            bool GoBack = false;
            switch (SelectedItem)
            {
                case Categories.Officer:
                    if ((pageIndex + Official_totalPage) > Official_totalPage)
                    {
                        pageIndex--;
                        GoBack = true;
                    }
                    break;
                case Categories.Office:
                    if ((pageIndex + Official_totalPage) > Official_totalPage)
                    {
                        pageIndex--;
                        GoBack = true;
                    }
                    break;
                case Categories.Service:
                    if ((pageIndex + Service_totalPage) > Service_totalPage)
                    {
                        pageIndex--;
                        GoBack = true;
                    }
                    break;
                case Categories.Job:
                    if ((pageIndex + Job_totalPage) > Job_totalPage)
                    {
                        pageIndex--;
                        GoBack = true;
                    }
                    break;
                case Categories.All:
                    if ((pageIndex + All_totalPage) > All_totalPage)
                    {
                        pageIndex--;
                        GoBack = true;
                    }
                    break;
            }

            if (GoBack)
            {
                if (tb_Search.Text.Equals(""))
                    AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
                else
                    AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
            }

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
                    Frame.Navigate(typeof(Services_View));
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
            tb_Search.Text = "";
            pageIndex = 0;
            RadioButton rb = sender as RadioButton;
            //MessageDialog md;
            if (rb != null)
            {
                string CategoryType = rb.Tag.ToString();
                switch (CategoryType)
                {
                    case "Official":
                        SelectedItem = Categories.Officer;
                        Official_postsList = officialRepository.GetAll_Official();
                        break;
                    case "Department":
                        SelectedItem = Categories.Office;
                        Official_postsList = officialRepository.GetAll_Official();
                        break;
                    case "Services":
                        SelectedItem = Categories.Service;
                        Service_postsList = serviceRepository.GetAll_Service();
                        break;
                    case "Jobs":
                        SelectedItem = Categories.Job;
                        Job_postsList = jobRepository.GetAll_JobCategories();
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
                    if (category.Equals(Categories.Officer))
                        Official_displayPostsList = Official_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Official_displayPostsList = Official_postsList;
                    foreach (var official in Official_displayPostsList)
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
                    var Filtered_Officials = Official_postsList.Where(stringToCheck => (stringToCheck.First_Name + " " + stringToCheck.Middle_Initial + " " + stringToCheck.Last_Name + " " + stringToCheck.Suffix).ToLower().Contains(tb_Search.Text.ToLower()));
                    if (category.Equals(Categories.Officer))
                        Official_displayPostsList = Filtered_Officials.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Official_displayPostsList = Filtered_Officials.ToList();
                    foreach (var official in Official_displayPostsList)
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
                    if (category.Equals(Categories.Office))
                        Official_displayPostsList = Official_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Official_displayPostsList = Official_postsList;
                    foreach (var official in Official_displayPostsList)
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
                    var Filtered_Offices = Official_postsList.Where(stringToCheck => stringToCheck.department.Department_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    if (category.Equals(Categories.Officer))
                        Official_displayPostsList = Filtered_Offices.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Official_displayPostsList = Filtered_Offices.ToList();

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
                    if (category.Equals(Categories.Job))
                        Job_displayPostsList = Job_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Job_displayPostsList = Job_postsList;
                    foreach (var Job_Category in Job_displayPostsList)
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
                    var Filtered_Jobs = Job_postsList.Where(stringToCheck => stringToCheck.Job_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    if (category.Equals(Categories.Job))
                        Job_displayPostsList = Filtered_Jobs.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Job_displayPostsList = Filtered_Jobs.ToList();

                    foreach (var Job_Category in Job_displayPostsList)
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
                    if (category.Equals(Categories.Service))
                        Service_displayPostsList = Service_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Service_displayPostsList = Service_postsList;
                    foreach (var service in Service_displayPostsList)
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
                    var Filtered_Services = Service_postsList.Where(stringToCheck => stringToCheck.Service_Name.ToLower().Contains(tb_Search.Text.ToLower()));
                    if (category.Equals(Categories.Service))
                        Service_displayPostsList = Filtered_Services.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    else
                        Service_displayPostsList = Filtered_Services.ToList();
                    foreach (var service in Service_displayPostsList)
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
            if (category.Equals(Categories.All))
            {
                All_postsList = items;
                All_displayPostsList = All_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                items.Clear();
                foreach (var item in All_displayPostsList)
                {
                    items.Add(new Items()
                    {
                        Objectname = item.Objectname,
                        itemObject = item.itemObject,
                        itemCategory = item.itemCategory
                    });
                }
                return items;
            }
            else
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Set default selected item is all
            SelectedItem = Categories.All;
            rb_All.IsChecked = true;
            //aSystem.Diagnostics.Process.Start("osk.exe");

            if (Global.language == "Filipino")
            {
                Searchbtn.Label = "Hanapin";
                Mapbtn.Label = "Mapa";
                Servicesbtn.Label = "Mga Serbisyo";
                Jobsbtn.Label = "Mga Trabaho";

                MainTitle.Text = "HANAPIN";

                tbOfficers.Text = "Mga Opisyal";
                tbOffices.Text = "Kagawaran";
                tbServices.Text = "Mga Serbisyo";
                tbJobs.Text = "Mga Trabaho";
                tbAll.Text = "Lahat";

            }
        }
    }
}
