using BinanKiosk.Enums;
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
		DispatcherTimer Timer;

		private JobRepository jobRepository;
		private OfficialRepository officialRepository;
		private ServiceRepository serviceRepository;
		private OfficeRepository officeRepository;

		private Categories SelectedItem;

		private IList<Service> Service_postsList; //Given List
		private IList<Service> Service_displayPostsList; //List to be displayed in ListView

		private IList<M_Job_Type> Job_postsList; //Given List
		private IList<M_Job_Type> temp_Job_postsList; //Given List
		private IList<M_Job_Type> Job_displayPostsList; //List to be displayed in ListView

		private IList<Official> Official_postsList; //Given List
		private IList<Official> Official_displayPostsList; //List to be displayed in ListView

		private IList<Office> Office_postsList; //Given List
		private IList<Office> Office_displayPostsList; //List to be displayed in ListView

		ObservableCollection<Items> All_postsList; //Given List
		private IList<Items> All_displayPostsList; //List to be displayed in ListView

		int pageIndex = -1;
		int pageSize = 15; //Set the size of the page
		int Service_totalPage = 0, Job_totalPage = 0, Official_totalPage = 0, Office_totalPage = 0,All_totalPage;
		int counter = 0;
		#endregion

		#region Enums
		
		private enum SearchType { All, Filtered }
		#endregion
		
		//Constructor
		public Search()
		{
			this.InitializeComponent();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			Timer = new DispatcherTimer();
			//Initialization
			#region
			//Global.language = "Filipino";
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			jobRepository = new JobRepository();
			officialRepository = new OfficialRepository();
			serviceRepository = new ServiceRepository();
			officeRepository = new OfficeRepository();
			Service_postsList = new List<Service>(); //Given List
			Service_displayPostsList = new List<Service>(); //List to be displayed in ListView
			Job_postsList = new List<M_Job_Type>(); //Given List
			temp_Job_postsList = new List<M_Job_Type>(); //Given List
			Job_displayPostsList = new List<M_Job_Type>(); //List to be displayed in ListView
			Official_postsList = new List<Official>(); //Given List
			Official_displayPostsList = new List<Official>(); //List to be displayed in ListView
			Office_postsList = new List<Office>(); //Given List
			Office_displayPostsList = new List<Office>(); //List to be displayed in ListView

			All_postsList = new ObservableCollection<Items>(); //Given List
			All_displayPostsList = new List<Items>(); //List to be displayed in ListView
			pageIndex = -1;
			pageSize = 15; //Set the size of the page
			Service_totalPage = 0; Job_totalPage = 0; Official_totalPage = 0; Office_totalPage = 0;
			counter = 0;

			//populates the list
			Job_postsList = jobRepository.GetAll_JobTypes();
			temp_Job_postsList = Job_postsList.GroupBy(x => x.Job_Types).Select(x => x.First()).ToList();
			Official_postsList = officialRepository.GetAll_Official();
			Service_postsList = serviceRepository.GetAll_Service();
			Office_postsList = officeRepository.GetAll_Office();
			
			#endregion
			//computes for the total number of pages
			Service_totalPage = Count_Page(Service_postsList.ToList<object>());
			Job_totalPage = Count_Page(temp_Job_postsList.ToList<object>());
			Office_totalPage = Count_Page(Office_postsList.ToList<object>());
			Official_totalPage = Count_Page(Official_postsList.ToList<object>());
			All_totalPage = (Office_postsList.Count + temp_Job_postsList.Count + Official_postsList.Count + Service_postsList.Count) / pageSize;
			//Set default selected item is all
			if (e.NavigationMode != NavigationMode.Back)
			{
				SelectedItem = Categories.All;
				rb_All.IsChecked = true;
			}
		}
		private void Timer_Tick(object sender, object e)
		{
			counter += 1;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			if(counter >= 7)
			{
				Timer.Stop();
				Frame.Navigate(typeof(Idle_Page));
			}
				
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			counter = 0;
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
						Show_PageNum(SelectedItem, Official_postsList.ToList<object>());
						break;
					case "Offices":
						SelectedItem = Categories.Office;
						Office_postsList = officeRepository.GetAll_Office();
						Show_PageNum(SelectedItem, Office_postsList.ToList<object>());
						break;
					case "Services":
						SelectedItem = Categories.Service;
						Service_postsList = serviceRepository.GetAll_Service();
						Show_PageNum(SelectedItem, Service_postsList.ToList<object>());
						break;
					case "Jobs":
						SelectedItem = Categories.Job;
						Job_postsList = jobRepository.GetAll_JobTypes();
						temp_Job_postsList = Job_postsList.GroupBy(x => x.Job_Types).Select(x => x.First()).ToList();
						Show_PageNum(SelectedItem, temp_Job_postsList.ToList<object>());
						break;
					case "All":
						SelectedItem = Categories.All;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (All_totalPage + 1).ToString();
						break;
				}
				AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
			}

		}

		private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
		{
			counter = 0;
			pageIndex = 0;
			AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
		}

		private ObservableCollection<Items> PopulateGrid(Categories category, SearchType searchType)
		{
			ObservableCollection<Items> items = new ObservableCollection<Items>();
			//FOR OFFICER
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
					Show_PageNum(Categories.Officer, Filtered_Officials.ToList<object>());
				}
			}
			// FOR OFFICE
			if (category.Equals(Categories.Office) || category.Equals(Categories.All))
			{
				if (searchType.Equals(SearchType.All))
				{
					if (category.Equals(Categories.Office))
						Office_displayPostsList = Office_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
					else
						Office_displayPostsList = Office_postsList;
					foreach (var office in Office_displayPostsList)
					{
						items.Add(new Items()
						{
							Objectname = office.Office_Name,
							itemObject = office,
							itemCategory = Categories.Office
						});
					}
				}
				else
				{
					var Filtered_Offices = Office_postsList.Where(stringToCheck => stringToCheck.Office_Name.ToLower().Contains(tb_Search.Text.ToLower()));
					if (category.Equals(Categories.Office))
						Office_displayPostsList = Filtered_Offices.Skip(pageIndex * pageSize).Take(pageSize).ToList();
					else
						Office_displayPostsList = Filtered_Offices.ToList();

					foreach (var office in Office_displayPostsList)
					{
						items.Add(new Items()
						{
							Objectname = office.Office_Name,
							itemObject = office,
							itemCategory = Categories.Office
						});
					}
					Show_PageNum(Categories.Office, Filtered_Offices.ToList<object>());
				}
			}
			// FOR JOB LISTS
			if (category.Equals(Categories.Job) || category.Equals(Categories.All))
			{
				if (searchType.Equals(SearchType.All))
				{
					if (category.Equals(Categories.Job))
						Job_displayPostsList = temp_Job_postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
					else
						Job_displayPostsList = temp_Job_postsList;
					foreach (var Job_Category in Job_displayPostsList)
					{
						items.Add(new Items()
						{
							Objectname = Job_Category.Job_Types,
							itemObject = Job_Category,
							itemCategory = Categories.Job
						});
					}
				}
				else
				{
					var Filtered_Jobs = temp_Job_postsList.Where(stringToCheck => stringToCheck.Job_Types.ToLower().Contains(tb_Search.Text.ToLower()));
					if (category.Equals(Categories.Job))
						Job_displayPostsList = Filtered_Jobs.Skip(pageIndex * pageSize).Take(pageSize).ToList();
					else
						Job_displayPostsList = Filtered_Jobs.ToList();

					foreach (var Job_Category in Job_displayPostsList)
					{
						items.Add(new Items()
						{
							Objectname = Job_Category.Job_Types,
							itemObject = Job_Category,
							itemCategory = Categories.Job
						});
					}
					Show_PageNum(Categories.Job, Filtered_Jobs.ToList<object>());
				}
			}
			// FOR SERVICES
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
					Show_PageNum(Categories.Service, Filtered_Services.ToList<object>());
				}
			}
			if (category.Equals(Categories.All))
			{
				All_postsList = items;
				Show_PageNum(Categories.All, All_postsList.ToList<object>());
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
		private void Searchbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(Search));
		}

		private void Mapbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(Map_1f));
		}

		private void Servicesbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(Services));
		}

		private void Jobsbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(v_Job_Category));
		}

		private void Eventbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(Event));
		}

		private async void Left_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			bool GoBack = false;
			switch (SelectedItem)
			{
				case Categories.Officer:
					if ((pageIndex + Official_totalPage) > Official_totalPage)
					{
						pageIndex--;
						GoBack = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Official_totalPage + 1).ToString();
					}
					break;
				case Categories.Office:
					if ((pageIndex + Office_totalPage) > Office_totalPage)
					{
						pageIndex--;
						GoBack = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Office_totalPage + 1).ToString();
					}
					break;
				case Categories.Service:
					if ((pageIndex + Service_totalPage) > Service_totalPage)
					{
						pageIndex--;
						GoBack = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Service_totalPage + 1).ToString();
					}
					break;
				case Categories.Job:
					if ((pageIndex + Job_totalPage) > Job_totalPage)
					{
						pageIndex--;
						GoBack = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Job_totalPage + 1).ToString();
					}
					break;
				case Categories.All:
					if ((pageIndex + All_totalPage) > All_totalPage)
					{
						pageIndex--;
						GoBack = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (All_totalPage + 1).ToString();
					}
					break;
			}
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (GoBack)
			{
				if (tb_Search.Text.Equals(""))
					AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
				else
					AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
			}
		}

		private async void Right_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			bool Next = false;
			switch (SelectedItem)
			{
				case Categories.Officer:
					if ((pageIndex + 1) <= Official_totalPage)
					{
						pageIndex++;
						Next = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Official_totalPage + 1).ToString();
					}
					break;
				case Categories.Office:
					if ((pageIndex + 1) <= Office_totalPage)
					{
						pageIndex++;
						Next = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Office_totalPage + 1).ToString();
					}
					break;
				case Categories.Service:
					if ((pageIndex + 1) <= Service_totalPage)
					{
						pageIndex++;
						Next = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Service_totalPage + 1).ToString();
					}
					break;
				case Categories.Job:
					if ((pageIndex + 1) <= Job_totalPage)
					{
						pageIndex++;
						Next = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (Job_totalPage + 1).ToString();
					}
					break;
				case Categories.All:
					if ((pageIndex + 1) <= All_totalPage)
					{
						pageIndex++;
						Next = true;
						tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (All_totalPage + 1).ToString();
					}
					break;
			}
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Next)
			{
				if (tb_Search.Text.Equals(""))
					AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.All);
				else
					AdaptiveGridViewControl.ItemsSource = PopulateGrid(SelectedItem, SearchType.Filtered);
			}
		}

		private async void AdaptiveGridViewControl_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			Items Item = new Items();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if ((e.OriginalSource as TextBlock) != null)
				Item = (e.OriginalSource as TextBlock).DataContext as Items;
			else
				Item = (e.OriginalSource as Image).DataContext as Items;
			switch (Item.itemCategory)
			{
				case Categories.Officer:
					Frame.Navigate(typeof(Official_Search_View), Item.itemObject);
					break;

				case Categories.Office:
					Frame.Navigate(typeof(Office_Search_View), Item.itemObject);
					break;

				case Categories.Service:
					Frame.Navigate(typeof(Service_Search_View), Item.itemObject);
					break;

				case Categories.Job:
					Frame.Navigate(typeof(v_Job_List), new Items { itemCategory = Categories.Job, itemObject = Job_postsList, Objectname = Item.Objectname });
					break;
			}
		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}
		
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
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

		private int Count_Page(List<object> objectList)
		{
			if (objectList.Count % pageSize == 0)
				return objectList.Count / pageSize - 1;
			else
				return objectList.Count / pageSize;
		}
		private void Show_PageNum(Categories category, List<object> object_List)
		{
			int temp_index = -1;
			if (object_List.Count != 0)
				temp_index = pageIndex;
			switch (category)
			{
				case Categories.Officer:
					Official_totalPage = Count_Page(object_List);
					tb_PageNum.Text = "Page " + (temp_index + 1).ToString() + " / " + (Official_totalPage + 1).ToString();
					break;
				case Categories.Office:
					Office_totalPage = Count_Page(object_List);
					tb_PageNum.Text = "Page " + (temp_index + 1).ToString() + " / " + (Office_totalPage + 1).ToString();
					break;
				case Categories.Service:
					Service_totalPage = Count_Page(object_List);
					tb_PageNum.Text = "Page " + (temp_index + 1).ToString() + " / " + (Service_totalPage + 1).ToString();
					break;
				case Categories.Job:
					Job_totalPage = Count_Page(object_List);
					tb_PageNum.Text = "Page " + (temp_index + 1).ToString() + " / " + (Job_totalPage + 1).ToString();
					break;
				case Categories.All:
					All_totalPage = Count_Page(object_List);
					tb_PageNum.Text = "Page " + (temp_index + 1).ToString() + " / " + (All_totalPage + 1).ToString();
					break;
			}
		}
		private async void Goto_OtherForm(TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
		}

	}
}
