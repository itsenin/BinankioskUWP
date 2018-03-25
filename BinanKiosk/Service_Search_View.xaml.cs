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
	public sealed partial class Service_Search_View : Page
	{
		Service service;
		Picture service_Picture, department_Logo;
		DispatcherTimer Timer;
		int counter = 0;
		public Service_Search_View()
		{
			this.InitializeComponent();

		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			Timer = new DispatcherTimer();
			counter = 0;
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();

			service = (Service)e.Parameter;
			service_Picture = Global.GetPic(service.Image_Path);
			//department_Logo = Global.GetPic(service..Department_Image_Path);
			Service_Name.Text = service.Service_Name.ToUpper();
			Service_Image.Source = Global.AsBitmapImage(service_Picture.image);
			//Department_Logo.Source = Global.AsBitmapImage(department_Logo.image);
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
		private async void Searchbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Search));
		}

		private async void Mapbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Map_1f));
		}

		private async void Servicesbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Services));
		}

		private async void Jobsbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(v_Job_Category));
		}

		private async void Eventbtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Event));
		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
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
	}
}
