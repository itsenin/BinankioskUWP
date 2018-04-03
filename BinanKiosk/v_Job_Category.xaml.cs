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
    public sealed partial class v_Job_Category : Page
    {
		private IList<M_Job_Category> postsList; //Given List
		private IList<M_Job_Category> displayPostsList; //List to be displayed in ListView
		int pageIndex = 0;
		int pageSize = 6; //Set the size of the page
		int totalPage = 0;
		int counter = 0;
		JobRepository jobRepository;
		DispatcherTimer Timer;
		ObservableCollection<BindedItems> items;
		public class BindedItems
		{
			public M_Job_Category job_Category { get; set; }
			public string Job_List { get; set; }
			public string Locate { get; set; }
		}
		public v_Job_Category()
		{
			this.InitializeComponent();
		} //end of Services constructor
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;

			postsList = new List<M_Job_Category>(); //Given List
			displayPostsList = new List<M_Job_Category>(); //List to be displayed in ListView
			pageIndex = 0;
			pageSize = 6; //Set the size of the page
			totalPage = 0;
			jobRepository = new JobRepository();
			Timer = new DispatcherTimer();
			//Instantiation of List of services
			items = new ObservableCollection<BindedItems>();
			
			//For the time
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			counter = 0;
			// Populating the list from the database
			postsList = jobRepository.GetAll_JobCategories();
			totalPage = postsList.Count / 6;
			AdaptiveGridViewControl.ItemsSource = Job_Category_Populator();
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

		private ObservableCollection<BindedItems> Job_Category_Populator()
		{
			items.Clear();
			displayPostsList = postsList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
			//For populating the Adaptive Grid View
			foreach (var job_category in displayPostsList)
			{
				string description = "";
				if (Global.language != "Filipino")
					description = "SHOW ALL JOB LIST";
				else
					description = "IPAKITA ANG LISTAHAN NG TRABAHO";
				items.Add(new BindedItems()
				{
					job_Category = new M_Job_Category
					{
						Job_ID = job_category.Job_ID,
						Job_Name = job_category.Job_Name
					},

					Job_List = description,
					Locate = "LOCATE"
				});
			}
			return items;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Global.language == "Filipino")
			{
				MainTitle.Text = "MGA KATEGORYA NG TRABAHO";

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
				AdaptiveGridViewControl.ItemsSource = Job_Category_Populator();
				if (Global.language != "Filipino")
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
				AdaptiveGridViewControl.ItemsSource = Job_Category_Populator();
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

		private void bt_Job_Category_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			var bindedItems = (sender as Button).DataContext as BindedItems;
			Frame.Navigate(typeof(v_Job_List), new Items { itemCategory = Categories.Job_Category, itemObject = bindedItems.job_Category, Objectname = bindedItems.job_Category.Job_Name });
		}
		private async void Goto_OtherForm(TappedRoutedEventArgs e)
		{
			Timer.Stop();
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
		}
	}
}
