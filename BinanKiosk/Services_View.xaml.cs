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
using BinanKiosk.Service_Folder;
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Imaging;
using System.ComponentModel;
using Windows.Graphics.Imaging;
using BinanKiosk.Enums;
using Windows.Storage;
using Windows.Storage.Streams;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Services_View : Page
    {
		Service service;
		ServiceClientWrapper client;
		DispatcherTimer Timer;
		int counter = 0;
		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			DataContext = this;
			Timer = new DispatcherTimer();
			client = new ServiceClientWrapper();
			
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			counter = 0;
			service = (Service)e.Parameter;
			BitmapImage bitmapImage2 = new BitmapImage();
			StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Services));
			StorageFile storageFile = await storageFolder.GetFileAsync(service.Image_Path);
			using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read))
			{
				await bitmapImage2.SetSourceAsync(stream);
			}
			theImage.Source = bitmapImage2;
			MyScrollViewer.RegisterPropertyChangedCallback(ScrollViewer.ZoomFactorProperty, (s, a) => { counter = 0; });
		}
		public Services_View()
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

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
			counter = 0;
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
				MainTitle.Text = "GABAY NG MAMAMAYAN";

				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
			}
		}
		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Goto_OtherForm(e);
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

