using BinanKiosk.Enums;
using BinanKiosk.Models;
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
	public sealed partial class Office_Search_View : Page
	{
		Office office;
		Picture office_Picture, department_Logo;
		DispatcherTimer Timer;
		int counter = 0;
		public Office_Search_View()
		{
			this.InitializeComponent();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			counter = 0;
			Timer = new DispatcherTimer();
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();

			office = (Office)e.Parameter;
			office_Picture = Global.GetPic(office.image_path);
			department_Logo = Global.GetPic(office.department.Department_Image_Path);
			Office_Name.Text = office.Office_Name.ToUpper();
			office_Image.Source = Global.AsBitmapImage(office_Picture.image);
			Department_Logo.Source = Global.AsBitmapImage(department_Logo.image);
			MyScrollViewer.RegisterPropertyChangedCallback(ScrollViewer.ZoomFactorProperty, (s, a) => { counter = 0; });
		}
		private void Timer_Tick(object sender, object e)
		{
			counter += 1;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			if (counter >= 7)
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

		private async void btn_Find_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(office.Room_Name));
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Global.GoBack(this);
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Global.language == "Filipino")
			{
				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Trabaho";

				MainTitle.Text = "RESULTA";
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
