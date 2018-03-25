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
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_3f : Page
	{
		List<Image> Steplist_R301_304, Steplist_R302_303, Steplist_R305, Steplist_R306,
			Steplist_R307, Steplist_R308, Steplist_R309, Steplist_R310, Steplist_R311, Steplist_R312, Temp_ListSteps;
		List<Button> ButtonList;
		DispatcherTimer Timer = new DispatcherTimer();
		public Map_3f()
		{
			this.InitializeComponent();
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			Steplist_R301_304 = new List<Image> { img_Base, img_rOptional_1_8, img_R301_304_1, img_R301_304_2, img_rOptional_1_5, img_R301_304_3, img_R301_304_4, img_rOptional_1_2_4 };
			Steplist_R302_303 = new List<Image> { img_Base, img_rOptional_1_8, img_R301_304_1, img_R301_304_2, img_rOptional_1_5, img_R301_304_3, img_R301_304_4, img_rOptional_1_2_4, img_R302_R303_1, img_R302_R303_2, img_rOptional_2_3 };
			Steplist_R305 = new List<Image> { img_Base, img_rOptional_1_8, img_R301_304_1, img_R301_304_2, img_rOptional_1_5, img_R305_1, img_R305_2 };
			Steplist_R306 = new List<Image> { img_Base, img_rOptional_1_8, img_R301_304_1, img_R301_304_2, img_rOptional_1_5, img_R305_1, img_R306_1, img_R306_2 };
			Steplist_R307 = new List<Image> { img_Base, img_rOptional_1_8, img_R301_304_1, img_R301_304_2, img_rOptional_1_5, img_R305_1, img_R306_1, img_R307_1, img_R307_2, img_R307_3, img_R307_4 };

			Steplist_R308 = new List<Image> { img_Base, img_rOptional_1_8, img_R308_1 };
			Steplist_R309 = new List<Image> { img_Base, img_R310_1, img_R310_2, img_R309_1, img_R309_2 };
			Steplist_R310 = new List<Image> { img_Base, img_R310_1, img_R310_2, img_R310_3 };
			Steplist_R311 = new List<Image> { img_Base, img_R310_1, img_R310_2, img_R312_1, img_R312_2, img_rOptional_11_12, img_R311_1, img_R311_2 };
			Steplist_R312 = new List<Image> { img_Base, img_R310_1, img_R310_2, img_R312_1, img_R312_2, img_rOptional_11_12 };
			ButtonList = new List<Button> { btn_R301, btn_R302, btn_R303, btn_R304, btn_R305, btn_R306, btn_R307, btn_R308, btn_R309, btn_R310, btn_R311, btn_R312 };
		}
		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			if (e.Parameter != null)
			{
				var room = (Global.Room)e.Parameter;
				await Room_Populator(room);
			}
		}
		private void Timer_Tick(object sender, object e)
		{
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
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

		private void fstFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_1f));
		}

		private void sndFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_2f));
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Global.Button_Renaming(ButtonList);
			Global.Show_Hide_Image(Steplist_R301_304, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R302_303, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R305, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R306, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R307, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R308, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R309, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R310, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R311, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R312, Global.Img_Property.Collapsed);
			if (Global.language == "Filipino")
			{
				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Trabaho";

				MainTitle.Text = "MAPA";
			}

		}

		private void Room_Click(object sender, RoutedEventArgs e)
		{
			var clicked_Button = e.OriginalSource as Button;
			this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(clicked_Button.Name.Split('_')[1]));
			//if (clicked_Button.Name.Equals(btn_R301.Name)) { Step_Populator(Steplist_R301_304, Global.Room.R301); }
			//else if (clicked_Button.Name.Equals(btn_R302.Name)) { Step_Populator(Steplist_R302_303, Global.Room.R302); }
			//else if (clicked_Button.Name.Equals(btn_R303.Name)) { Step_Populator(Steplist_R302_303, Global.Room.R303); }
			//else if (clicked_Button.Name.Equals(btn_R304.Name)) { Step_Populator(Steplist_R301_304, Global.Room.R304); }
			//else if (clicked_Button.Name.Equals(btn_R305.Name)) { Step_Populator(Steplist_R305, Global.Room.R305); }
			//else if (clicked_Button.Name.Equals(btn_R306.Name)) { Step_Populator(Steplist_R306, Global.Room.R306); }
			//else if (clicked_Button.Name.Equals(btn_R307.Name)) { Step_Populator(Steplist_R307, Global.Room.R307); }
			//else if (clicked_Button.Name.Equals(btn_R308.Name)) { Step_Populator(Steplist_R308, Global.Room.R308); }
			//else if (clicked_Button.Name.Equals(btn_R309.Name)) { Step_Populator(Steplist_R309, Global.Room.R309); }
			//else if (clicked_Button.Name.Equals(btn_R310.Name)) { Step_Populator(Steplist_R310, Global.Room.R310); }
			//else if (clicked_Button.Name.Equals(btn_R311.Name)) { Step_Populator(Steplist_R311, Global.Room.R311); }
			//else if (clicked_Button.Name.Equals(btn_R312.Name)) { Step_Populator(Steplist_R312, Global.Room.R312); }
			//pass yung key value pair sa next form
		}

		private async Task Step_Populator(List<Image> StepList, Global.Room room)
		{
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			Temp_ListSteps = StepList;
			Global.Enable_Disable_Button(Global.Button_Property.Disable, ButtonList);
			foreach (var step in StepList)
			{
				if (step.Equals(img_Base))
				{
					if (room.Equals(Global.Room.R309) || room.Equals(Global.Room.R310) || room.Equals(Global.Room.R311) || room.Equals(Global.Room.R312))
					{ step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_1_8))
				{
					if (room.Equals(Global.Room.R308)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_1_5))
				{
					if (room.Equals(Global.Room.R305) || room.Equals(Global.Room.R306) || room.Equals(Global.Room.R307)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
				}
				if (step.Equals(img_rOptional_1_2_4))
				{
					if (room.Equals(Global.Room.R301)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
					else if (room.Equals(Global.Room.R304)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_2_3))
				{
					if (room.Equals(Global.Room.R303)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
				}
				if (step.Equals(img_rOptional_11_12))
				{
					if (room.Equals(Global.Room.R312)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
				}
				step.Visibility = Visibility.Visible;
				await Task.Delay(TimeSpan.FromSeconds(0.5));
			}
			//Number of Blinks after showing the arrows
			for (int i = 0; i < 4; i++)
			{
				Global.Show_Hide_Image(StepList, Global.Img_Property.Collapsed);
				await Task.Delay(TimeSpan.FromSeconds(0.5));
				Global.Show_Hide_Image(StepList, Global.Img_Property.Visible);
				await Task.Delay(TimeSpan.FromSeconds(0.5));
			}
			Global.Enable_Disable_Button(Global.Button_Property.Enable, ButtonList);
			Global.IsClicked = true;
		}
		private async Task Room_Populator(Global.Room room)
		{
			if (room.Equals(Global.Room.R301)) { await Step_Populator(Steplist_R301_304, room); }
			else if (room.Equals(Global.Room.R302)) { await Step_Populator(Steplist_R302_303, room); }
			else if (room.Equals(Global.Room.R303)) { await Step_Populator(Steplist_R302_303, room); }
			else if (room.Equals(Global.Room.R304)) { await Step_Populator(Steplist_R301_304, room); }
			else if (room.Equals(Global.Room.R305)) { await Step_Populator(Steplist_R305, room); }
			else if (room.Equals(Global.Room.R306)) { await Step_Populator(Steplist_R306, room); }
			else if (room.Equals(Global.Room.R307)) { await Step_Populator(Steplist_R307, room); }
			else if (room.Equals(Global.Room.R308)) { await Step_Populator(Steplist_R308, room); }
			else if (room.Equals(Global.Room.R309)) { await Step_Populator(Steplist_R309, room); }
			else if (room.Equals(Global.Room.R310)) { await Step_Populator(Steplist_R310, room); }
			else if (room.Equals(Global.Room.R311)) { await Step_Populator(Steplist_R311, room); }
			else if (room.Equals(Global.Room.R312)) { await Step_Populator(Steplist_R312, room); }
		}
	}
}
