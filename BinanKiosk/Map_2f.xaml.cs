using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BinanKiosk.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_2f : Page
	{
		List<Image> Steplist_R201, Steplist_R202, Steplist_R203, Steplist_R204, Steplist_R205, Steplist_R206,
			Steplist_R207_208, Steplist_R209, Steplist_R210, Steplist_R211, Steplist_R212, Steplist_R213,
			Steplist_R214, Steplist_R215, Steplist_R216, Steplist_R217, Steplist_R218, Steplist_R219,
			Steplist_R220, Steplist_R221, Steplist_R222, Steplist_R223,Steplist_Stairs_3f, Temp_ListSteps;
		List<Button> ButtonList;
		DispatcherTimer Timer = new DispatcherTimer();
		public Map_2f()
		{
			this.InitializeComponent();
			Global.IsClicked = false;
			DataContext = this;
			//For the Timer
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			//Population of list
			Steplist_R201 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_r201_202_203_1, img_r201_202_203_2, img_r201_202_203_3, img_rOptional_1_3, img_rOptional_1_2 };
			Steplist_R202 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_r201_202_203_1, img_r201_202_203_2, img_r201_202_203_3, img_rOptional_1_3, img_rOptional_1_2, img_R202_1, img_R202_2, img_R202_3 };
			Steplist_R203 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_r201_202_203_1, img_r201_202_203_2, img_r201_202_203_3, img_rOptional_1_3 };
			Steplist_R204 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_R204_1, img_R204_2, img_rOptional_4_5 };
			Steplist_R205 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_R204_1, img_R204_2, img_rOptional_4_5, img_R205_1, img_R205_2 };
			Steplist_R206 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_R204_1, img_R204_2, img_rOptional_4_5, img_R205_1, img_R206_1, img_R206_2 };
			Steplist_R207_208 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_R204_1, img_R204_2, img_rOptional_4_5, img_R205_1, img_R206_1, img_R207_208_1, img_rOptional_7_8 };
			Steplist_R209 = new List<Image> { img_LeftBase_1, img_LeftBase_2, img_R204_1, img_R204_2, img_rOptional_4_5, img_R205_1, img_R206_1, img_R207_208_1, img_R209_1 };
			Steplist_R210 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R214_1, img_R214_2, img_rOptional_10_11, img_rOptional_10_12 };
			Steplist_R211 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R214_1, img_R214_2, img_rOptional_10_11 };
			Steplist_R212 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R214_1, img_R214_2, img_rOptional_10_11, img_rOptional_10_12, img_R212_1 };
			Steplist_R213 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R214_1, img_R214_2, img_rOptional_10_11, img_R213_1 };
			Steplist_R214 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R214_1, img_R214_2, img_R214_3 };
			Steplist_R215 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16, img_R215_1 };
			Steplist_R216 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17, img_rOptional_15_16 };
			Steplist_R217 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18, img_rOptional_16_17 };
			Steplist_R218 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19, img_rOptional_17_18 };
			Steplist_R219 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20, img_rOptional_18_19 };
			Steplist_R220 = new List<Image> { img_RightBase_1, img_RightBase_2, img_rOptional_19_20 };
			Steplist_R221 = new List<Image> { img_RightBase_1, img_RightBase_2, img_R221_1, img_R221_2, img_rOptional_21_23 };
			Steplist_R222 = new List<Image> { img_RightBase_1, img_RightBase_2, img_R221_1, img_R221_2, img_rOptional_21_23, img_R222_1, img_R222_2, img_R222_3, img_R222_4, img_R222_5 };
			Steplist_R223 = new List<Image> { img_RightBase_1, img_RightBase_2, img_R221_1, img_R221_2, img_rOptional_21_23, img_R223_1 };
			Steplist_Stairs_3f = new List<Image> { img_LeftBase_1, img_Stairs_3f_1,img_Stairs_3f_2};
			ButtonList = new List<Button> { btn_R201, btn_R202, btn_R203, btn_R204, btn_R205, btn_R206, btn_R207, btn_R208, btn_R209, btn_R210, btn_R211, btn_R212, btn_R213, btn_R214, btn_R215, btn_R216, btn_R217, btn_R218, btn_R219, btn_R220, btn_R221, btn_R222, btn_R223 };
		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			if (e.Parameter != null)
			{
				await Task.Delay(TimeSpan.FromSeconds(0.5));
				var room = (Global.Room)e.Parameter;
				if (room.Equals(Global.Room.R301) || room.Equals(Global.Room.R302) || room.Equals(Global.Room.R303) ||
					room.Equals(Global.Room.R304) || room.Equals(Global.Room.R305) || room.Equals(Global.Room.R306) ||
					room.Equals(Global.Room.R307) || room.Equals(Global.Room.R308) || room.Equals(Global.Room.R309) ||
					room.Equals(Global.Room.R310) || room.Equals(Global.Room.R311) || room.Equals(Global.Room.R312) || room.Equals(Global.Room.R312))
				{
					if (room.Equals(Global.Room.R301) || room.Equals(Global.Room.R302) || room.Equals(Global.Room.R303) || room.Equals(Global.Room.R304) || room.Equals(Global.Room.R305) || room.Equals(Global.Room.R306) || room.Equals(Global.Room.R307) || room.Equals(Global.Room.R308) || room.Equals(Global.Room.R309) || room.Equals(Global.Room.R310) || room.Equals(Global.Room.R311) || room.Equals(Global.Room.R312))
						await Room_Populator(Global.Room.Stairs_3F);
					else
						await Room_Populator(room);
					Global.IsClicked = false;
					this.Frame.Navigate(typeof(Map_3f), room);
				}
				else
				{
					await Room_Populator(room);
				}
			}
		}

		private void Timer_Tick(object sender, object e)
		{
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
		}

		private void fstFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_1f));
		}

		private void trdFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_3f));
		}

		private void Jobsbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(v_Job_Category));
		}

		private void Servicesbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Services));
		}

		private void Mapbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_1f));
		}

		private void Searchbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Search));
		}

		private void Eventbtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Event));
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Global.Button_Renaming(ButtonList);
			Global.Show_Hide_Image(Steplist_R201, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R202, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R203, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R204, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R205, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R206, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R207_208, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R209, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R210, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R211, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R212, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R213, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R214, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R215, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R216, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R217, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R218, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R219, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R220, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R221, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R222, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R223, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_Stairs_3f, Global.Img_Property.Collapsed);
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
			//Room_Populator(Global.Enum_Converter(clicked_Button.Name.Split('_')[1]));

			this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(clicked_Button.Name.Split('_')[1]));

			//if (clicked_Button.Name.Equals(btn_R201.Name)) { Step_Populator(Steplist_R201, Global.Room.R201); }
			//else if (clicked_Button.Name.Equals(btn_R202.Name)) { Step_Populator(Steplist_R202, Global.Room.R202); }
			//else if (clicked_Button.Name.Equals(btn_R203.Name)) { Step_Populator(Steplist_R203, Global.Room.R203); }
			//else if (clicked_Button.Name.Equals(btn_R204.Name)) { Step_Populator(Steplist_R204, Global.Room.R204); }
			//else if (clicked_Button.Name.Equals(btn_R205.Name)) { Step_Populator(Steplist_R205, Global.Room.R205); }
			//else if (clicked_Button.Name.Equals(btn_R206.Name)) { Step_Populator(Steplist_R206, Global.Room.R206); }
			//else if (clicked_Button.Name.Equals(btn_R207.Name)) { Step_Populator(Steplist_R207_208, Global.Room.R207); }
			//else if (clicked_Button.Name.Equals(btn_R208.Name)) { Step_Populator(Steplist_R207_208, Global.Room.R208); }
			//else if (clicked_Button.Name.Equals(btn_R209.Name)) { Step_Populator(Steplist_R209, Global.Room.R209); }
			//else if (clicked_Button.Name.Equals(btn_R210.Name)) { Step_Populator(Steplist_R210, Global.Room.R210); }
			//else if (clicked_Button.Name.Equals(btn_R211.Name)) { Step_Populator(Steplist_R211, Global.Room.R211); }
			//else if (clicked_Button.Name.Equals(btn_R212.Name)) { Step_Populator(Steplist_R212, Global.Room.R212); }
			//else if (clicked_Button.Name.Equals(btn_R213.Name)) { Step_Populator(Steplist_R213, Global.Room.R213); }
			//else if (clicked_Button.Name.Equals(btn_R214.Name)) { Step_Populator(Steplist_R214, Global.Room.R214); }
			//else if (clicked_Button.Name.Equals(btn_R215.Name)) { Step_Populator(Steplist_R215, Global.Room.R215); }
			//else if (clicked_Button.Name.Equals(btn_R216.Name)) { Step_Populator(Steplist_R216, Global.Room.R216); }
			//else if (clicked_Button.Name.Equals(btn_R217.Name)) { Step_Populator(Steplist_R217, Global.Room.R217); }
			//else if (clicked_Button.Name.Equals(btn_R218.Name)) { Step_Populator(Steplist_R218, Global.Room.R218); }
			//else if (clicked_Button.Name.Equals(btn_R219.Name)) { Step_Populator(Steplist_R219, Global.Room.R219); }
			//else if (clicked_Button.Name.Equals(btn_R220.Name)) { Step_Populator(Steplist_R220, Global.Room.R220); }
			//else if (clicked_Button.Name.Equals(btn_R221.Name)) { Step_Populator(Steplist_R221, Global.Room.R221); }
			//else if (clicked_Button.Name.Equals(btn_R222.Name)) { Step_Populator(Steplist_R222, Global.Room.R222); }
			//else if (clicked_Button.Name.Equals(btn_R223.Name)) { Step_Populator(Steplist_R223, Global.Room.R223); }
		}
		private async Task Step_Populator(List<Image> StepList, Global.Room room)
		{
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			Temp_ListSteps = StepList;
			Global.Enable_Disable_Button(Global.Button_Property.Disable, ButtonList);
			foreach (var step in StepList)
			{
				if (step.Equals(img_rOptional_1_3))
				{
					if (room.Equals(Global.Room.R203)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_1_2))
				{
					if (room.Equals(Global.Room.R201)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_4_5))
				{
					if (room.Equals(Global.Room.R204)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_7_8))
				{
					if (room.Equals(Global.Room.R203)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_19_20))
				{
					if (room.Equals(Global.Room.R220)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_18_19))
				{
					if (room.Equals(Global.Room.R219)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_17_18))
				{
					if (room.Equals(Global.Room.R218)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_16_17))
				{
					if (room.Equals(Global.Room.R217)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_15_16))
				{
					if (room.Equals(Global.Room.R216)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_10_11))
				{
					if (room.Equals(Global.Room.R211)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_10_12))
				{
					if (room.Equals(Global.Room.R210)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_21_23))
				{
					if (room.Equals(Global.Room.R221)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
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
			if (room.Equals(Global.Room.R201)) { await Step_Populator(Steplist_R201, room); }
			else if (room.Equals(Global.Room.R202)) { await Step_Populator(Steplist_R202, room); }
			else if (room.Equals(Global.Room.R203)) { await Step_Populator(Steplist_R203, room); }
			else if (room.Equals(Global.Room.R204)) { await Step_Populator(Steplist_R204, room); }
			else if (room.Equals(Global.Room.R205)) { await Step_Populator(Steplist_R205, room); }
			else if (room.Equals(Global.Room.R206)) { await Step_Populator(Steplist_R206, room); }
			else if (room.Equals(Global.Room.R207)) { await Step_Populator(Steplist_R207_208, room); }
			else if (room.Equals(Global.Room.R208)) { await Step_Populator(Steplist_R207_208, room); }
			else if (room.Equals(Global.Room.R209)) { await Step_Populator(Steplist_R209, room); }
			else if (room.Equals(Global.Room.R210)) { await Step_Populator(Steplist_R210, room); }
			else if (room.Equals(Global.Room.R211)) { await Step_Populator(Steplist_R211, room); }
			else if (room.Equals(Global.Room.R212)) { await Step_Populator(Steplist_R212, room); }
			else if (room.Equals(Global.Room.R213)) { await Step_Populator(Steplist_R213, room); }
			else if (room.Equals(Global.Room.R214)) { await Step_Populator(Steplist_R214, room); }
			else if (room.Equals(Global.Room.R215)) { await Step_Populator(Steplist_R215, room); }
			else if (room.Equals(Global.Room.R216)) { await Step_Populator(Steplist_R216, room); }
			else if (room.Equals(Global.Room.R217)) { await Step_Populator(Steplist_R217, room); }
			else if (room.Equals(Global.Room.R218)) { await Step_Populator(Steplist_R218, room); }
			else if (room.Equals(Global.Room.R219)) { await Step_Populator(Steplist_R219, room); }
			else if (room.Equals(Global.Room.R220)) { await Step_Populator(Steplist_R220, room); }
			else if (room.Equals(Global.Room.R221)) { await Step_Populator(Steplist_R221, room); }
			else if (room.Equals(Global.Room.R222)) { await Step_Populator(Steplist_R222, room); }
			else if (room.Equals(Global.Room.R223)) { await Step_Populator(Steplist_R223, room); }
			else if (room.Equals(Global.Room.Stairs_3F)) { await Step_Populator(Steplist_Stairs_3f, room); }
		}
	}
}
