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
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class v_Job_List : Page
    {
		JobRepository jobRepository;
        DispatcherTimer Timer;
		private Items item_List;
        private M_Job_Category _Category;
		int counter = 0;
		public class Temp_Job_Type
		{
			public int JobType_ID { get; set; }
			public string Job_Types { get; set; }
			public M_Job_Category Category { get; set; }
			public string Job_Description { get; set; }
			public string Job_Location { get; set; }
			public string Job_Company { get; set; }
			public string job_Image_Path { get; set; }
			public BitmapImage logo_Image_Path { get; set; }
		}
		protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
			counter = 0;
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			jobRepository = new JobRepository();
			Timer = new DispatcherTimer();
            
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			item_List = (Items)e.Parameter;
			ObservableCollection<Temp_Job_Type> items = new ObservableCollection<Temp_Job_Type>();
			if (item_List.itemCategory.Equals(Categories.Job_Category))
			{
				_Category = (M_Job_Category)item_List.itemObject;
				foreach (var JobType in jobRepository.GetAll_JobTypes(_Category))
				{
					BitmapImage bitmapImage2 = new BitmapImage();
					StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Job_Company_Logos));
					StorageFile storageFile = await storageFolder.GetFileAsync(JobType.logo_Image_Path);
					using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read))
					{
						await bitmapImage2.SetSourceAsync(stream);
					}
					items.Add(new Temp_Job_Type()
					{
						JobType_ID = JobType.JobType_ID,
						Category = new M_Job_Category { Job_ID = JobType.Category.Job_ID, Job_Name = JobType.Category.Job_Name },
						Job_Company = JobType.Job_Company,
						Job_Description = JobType.Job_Description,
						Job_Location = JobType.Job_Location,
						Job_Types = JobType.Job_Types,
						job_Image_Path = JobType.job_Image_Path,
						logo_Image_Path = bitmapImage2
					});
				}
			}
			else
			{
				var Job_List = (List<M_Job_Type>)item_List.itemObject;
				var Filtered_Job_List = Job_List.Where(stringToCheck => (stringToCheck.Job_Types).ToLower().Equals(item_List.Objectname.ToLower()));

				foreach (var JobType in Filtered_Job_List)
				{
					BitmapImage bitmapImage2 = new BitmapImage();
					StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Job_Company_Logos));
					StorageFile storageFile = await storageFolder.GetFileAsync(JobType.logo_Image_Path);
					using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read))
					{
						await bitmapImage2.SetSourceAsync(stream);
					}
					items.Add(new Temp_Job_Type()
					{
						JobType_ID = JobType.JobType_ID,
						Category = new M_Job_Category { Job_ID = JobType.Category.Job_ID, Job_Name = JobType.Category.Job_Name },
						Job_Company = JobType.Job_Company,
						Job_Description = JobType.Job_Description,
						Job_Location = JobType.Job_Location,
						Job_Types = JobType.Job_Types,
						job_Image_Path = JobType.job_Image_Path,
						logo_Image_Path = bitmapImage2
					});
				}
			}
           
            if (items.Count <= 0)
            {
				if (Global.language != "Filipino")
					tb_Result.Text = "No Result";
				else
					tb_Result.Text = "Walang Resulta";
				img_trans.Visibility = Visibility.Visible;
            }
            else
            {
                tb_Result.Text = "";
                img_trans.Visibility = Visibility.Collapsed;
            }
            listViewControl.ItemsSource = items;
		}
        public v_Job_List()
        {
            this.InitializeComponent();
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

		private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Global.language == "Filipino")
            {
				MainTitle.Text = "LISTAHAN NG TRABAHO";

				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
			}
			ContentDialog InstructionDialog = new ContentDialog()
			{
				Title = "Instruction",
				Content = "Tap a job to view the requirements!",
				CloseButtonText = "Ok"
			};
			await InstructionDialog.ShowAsync();
		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void listViewControl_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			Temp_Job_Type job_Type = new Temp_Job_Type();
			if ((e.OriginalSource as TextBlock) != null)
				job_Type = (e.OriginalSource as TextBlock).DataContext as Temp_Job_Type;
			else if ((e.OriginalSource as Grid) != null)
				job_Type = (e.OriginalSource as Grid).DataContext as Temp_Job_Type;
			else if ((e.OriginalSource as Image) != null)
				job_Type = (e.OriginalSource as Image).DataContext as Temp_Job_Type;
			else
				job_Type = null;
			if (job_Type != null)
			{
				Frame.Navigate(typeof(Job_View), job_Type);
			}
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			Timer.Stop();
			Global.GoBack(this);
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
