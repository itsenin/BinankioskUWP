using BinanKiosk.Enums;
using BinanKiosk.Models;
using BinanKiosk.Repository;
using BinanKiosk.Service_Folder;
using Newtonsoft.Json;
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
		private IList<Service> postsList; //Given List
		private IList<Service> displayPostsList; //List to be displayed in ListView
		int pageIndex = 0;
		int pageSize = 6; //Set the size of the page
		int totalPage = 0;
		int counter = 0;
		ServiceRepository serviceRepository;
		DispatcherTimer Timer;
		ObservableCollection<BindedItems> items;
		public class BindedItems
		{
			public Service service { get; set; }
			public string Citizen_Charter { get; set; }
			public string Locate { get; set; }
		}
		public Services()
		{
			this.InitializeComponent();
			

		} //end of Services constructor
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			postsList = new List<Service>(); //Given List
			displayPostsList = new List<Service>(); //List to be displayed in ListView
			pageIndex = 0;
			pageSize = 6; //Set the size of the page
			totalPage = 0;
			serviceRepository = new ServiceRepository();
			Timer = new DispatcherTimer();
			//For the time
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			//Instantiation of List of services
			items = new ObservableCollection<BindedItems>();

			// Populating the list from the database
			postsList = serviceRepository.GetAll_Service();
			totalPage = postsList.Count / 6;
			AdaptiveGridViewControl.ItemsSource = Service_Populator();
		}
		private void Timer_Tick(object sender, object e)
		{
			counter += 1;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			if (counter >= Global.Timeout)
			{
				Timer.Stop();
				Frame.Navigate(typeof(Idle_Page));
			}
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
		
		private ObservableCollection<BindedItems> Service_Populator()
		{
			items.Clear();
			displayPostsList = postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
			//For populating the Adaptive Grid View
			foreach (var service in displayPostsList)
			{
				string description = "",Location="";
				if (Global.language != "Filipino")
				{
					description = "Citizen Charter";
					Location = "LOCATE";
				}
				else
				{
					description = "GABAY NG MAMAMAYAN";
					Location = "HANAPIN";
				}
					
				items.Add(new BindedItems()
				{
					service = new Service {
						Service_ID = service.Service_ID,
						Service_Name = service.Service_Name,
						Image_Path = service.Image_Path,
						office = new Office {  Office_ID = service.office.Office_ID, image_path = service.office.image_path, Office_Name = service.office.Office_Name, Room_Name = service.office.Room_Name}
					},
					Citizen_Charter = description,
					Locate = Location
					
				});
			}
			return items;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Global.language == "Filipino")
			{
				MainTitle.Text = "MGA SERBISYO";

				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
				tb_PageNum.Text = "Pahina " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
			}
			else
				tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
		}

		private void bt_CitizenCharter_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			var bindedItems = (sender as Button).DataContext as BindedItems;
			this.Frame.Navigate(typeof(Services_View), bindedItems.service);
		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private async void Left_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if ((pageIndex + totalPage) > totalPage)
			{
				pageIndex--;
				AdaptiveGridViewControl.ItemsSource = Service_Populator();
				if(Global.language != "Filipino")
					tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
				else
					tb_PageNum.Text = "Pahina " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
			}
		}

		private async void Right_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if ((pageIndex + 1) <= totalPage)
			{
				pageIndex++;
				AdaptiveGridViewControl.ItemsSource = Service_Populator();
				if (Global.language != "Filipino")
					tb_PageNum.Text = "Page " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
				else
					tb_PageNum.Text = "Pahina " + (pageIndex + 1).ToString() + " / " + (totalPage + 1).ToString();
			}
		}

		private async void AdaptiveGridViewControl_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}
		private async void Goto_OtherForm(TappedRoutedEventArgs e)
		{
			Timer.Stop();
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
		}

		private void bt_Locate_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			var bindedItems = (sender as Button).DataContext as BindedItems;
			this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(bindedItems.service.office.Room_Name));
		}
	}
}
