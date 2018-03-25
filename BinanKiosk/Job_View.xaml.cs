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
using BinanKiosk.Models;
using BinanKiosk.Enums;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Job_View : Page
    {
		M_Job_Type job_Type;
		Picture picture;
		DispatcherTimer Timer;
		int counter;
        public Job_View()
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
			job_Type = (M_Job_Type)e.Parameter;
			picture = Global.GetPic(job_Type.job_Image_Path);
			theImage.Source = Global.AsBitmapImage(picture.image);
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

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Global.GoBack(this);
		}
		private async void Goto_OtherForm(TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
		}
	}
}
