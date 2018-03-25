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
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Animation;
using BinanKiosk.Models;
using BinanKiosk.Repository;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	/// 


	public class Temporary_Image
	{
		public BitmapImage Image_Source { get; set; }
	}
	public sealed partial class Event : Page
	{
		EventRepository EventRepository;
		ObservableCollection<Temporary_Image> items;
		DispatcherTimer Timer;
		DispatcherTimer Carousel_Timer;
		int counter = 0;
		public Event()
		{
			this.InitializeComponent();
			
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			Timer = new DispatcherTimer();
			Carousel_Timer = new DispatcherTimer();
			EventRepository = new EventRepository();
			items = new ObservableCollection<Temporary_Image>();
			DataContext = this;
			var Slider_Images = EventRepository.GetAll_Slider_Images();
			foreach (var image in Slider_Images)
			{
				items.Add(new Temporary_Image() { Image_Source = Global.AsBitmapImage(Global.GetPic(image.Image_Source).image) });
			}
			Carousel_Control.ItemsSource = items;
			Carousel_Control2.ItemsSource = items;

			Carousel_Control2.SelectedIndex = items.Count / 2;
			Carousel_Control.SelectedIndex = items.Count / 2;
			//For the carousel
			Carousel_Timer.Interval = new TimeSpan(0, 0, 6);
			Carousel_Timer.Tick += Carousel_Slider;
			Carousel_Timer.Start();
			// For the timer
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
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

		private void Carousel_Slider(object sender, object e)
		{
			if ((Carousel_Control2.SelectedIndex + 1) < items.Count)
			{
				Carousel_Control2.SelectedIndex += 1;
				Carousel_Control.SelectedIndex = Carousel_Control2.SelectedIndex;
			}

			else
			{
				Carousel_Control2.SelectedIndex = 0;
				Carousel_Control.SelectedIndex = Carousel_Control2.SelectedIndex;
			}
				
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Global.language == "Filipino")
			{
				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Trabaho";
			}
		}

		private void Carousel_Control2_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Carousel_Control.SelectedIndex = Carousel_Control2.SelectedIndex;
			Carousel_Timer.Stop();
			Carousel_Timer.Start();
		}

		private void Carousel_Control_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Carousel_Control2.SelectedIndex = Carousel_Control.SelectedIndex;
			Carousel_Timer.Stop();
			Carousel_Timer.Start();
		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
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
	}
}
