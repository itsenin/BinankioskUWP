using BinanKiosk.Enums;
using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
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
	public sealed partial class Office_Search_View : Page
	{
		Office office;
		DispatcherTimer Timer;
		int counter = 0;
		public Office_Search_View()
		{
			this.InitializeComponent();
		}
		async protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			counter = 0;
			base.OnNavigatedTo(e);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			Timer = new DispatcherTimer();
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			office = (Office)e.Parameter;
			Office_Name.Text = office.Office_Name.ToUpper();
			//for the image of offices
			BitmapImage bitmapImage2 = new BitmapImage();
			StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Offices));
			StorageFile storageFile = await storageFolder.GetFileAsync(office.image_path);
			using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read))
			{
				await bitmapImage2.SetSourceAsync(stream);
			}
			office_Image.Source = bitmapImage2;
			// for the image of department
			bitmapImage2 = new BitmapImage();
			StorageFolder storageFolder2 = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Departments));
			StorageFile storageFile2 = await storageFolder2.GetFileAsync(office.department.Department_Image_Path);
			using (IRandomAccessStream stream = await storageFile2.OpenAsync(FileAccessMode.Read))
			{
				await bitmapImage2.SetSourceAsync(stream);
			}
			Department_Logo.Source = bitmapImage2;
			//Department_Logo.Source = Global.GetImage(office.department.Department_Image_Path, Global.Subfolders.Departments);
			MyScrollViewer.RegisterPropertyChangedCallback(ScrollViewer.ZoomFactorProperty, (s, a) => { counter = 0; });
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

		private void OnSizeChanged(object sender, SizeChangedEventArgs args)
		{
			counter = 0;
			//theImage.Height = MyScrollViewer.ViewportHeight;
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

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void btn_Find_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
			this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(office.Room_Name));
		}

		private async void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			Global.GoBack(this);
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Global.language == "Filipino")
			{
				MainTitle.Text = "OPISINA";

				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
			}
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
