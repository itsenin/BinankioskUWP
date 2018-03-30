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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public class temp_Class_Image
	{
		public BitmapImage Image_Source { get; set; }
	}
	public sealed partial class Idle_Page : Page
	{
		EventRepository EventRepository;
		ObservableCollection<temp_Class_Image> items;
		public Idle_Page()
		{
			this.InitializeComponent();
		}
		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			EventRepository = new EventRepository();

			items = new ObservableCollection<temp_Class_Image>();
			Global.Entrance_Transition(this, E_Transitions.Continuum);
			DataContext = this;
			//this.NavigationCacheMode = NavigationCacheMode.Required;
			var Slider_Images = EventRepository.GetAll_Slider_Images();
			foreach (var image in Slider_Images)
			{
				BitmapImage bitmapImage2 = new BitmapImage();
				StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Global.GetImage(Global.Subfolders.Home));
				StorageFile storageFile = await storageFolder.GetFileAsync(image.Image_Name);
				using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read))
				{
					await bitmapImage2.SetSourceAsync(stream);
				}
				items.Add(new temp_Class_Image() { Image_Source = bitmapImage2 });
			}
			ROTtest.ItemsSource = items;

		}
		private void Eventbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Event));
		}

		private void Searchbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Search));
		}

		private void Mapbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_1f));
		}

		private void Servicesbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Services));
		}

		private void Jobsbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(v_Job_Category));
		}
		//protected override void OnNavigatedTo(NavigationEventArgs e)
		//{
		//    Storyboard1.Begin();
		//}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Point touchPosition = e.GetPosition(MyGrid);
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.Frame.Navigate(typeof(Language));
		}
	}
}
