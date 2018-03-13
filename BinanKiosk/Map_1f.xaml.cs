using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BinanKiosk.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_1f : Page
	{

		List<Image> Steplist_R101, Steplist_R102, Steplist_R103_R104_R105, Steplist_R106,
			Steplist_R107_R110, Steplist_R108_R109, Steplist_R111, Steplist_R112, Temp_ListSteps;
		List<Button> ButtonList;

		DispatcherTimer Timer = new DispatcherTimer();
		public Map_1f()
		{
			this.InitializeComponent();
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			Steplist_R101 = new List<Image> { img_Base, img_rOptional_1_2, img_r101_1, img_r101_2, img_r101_3, img_r101_4 };
			Steplist_R102 = new List<Image> { img_Base, img_rOptional_1_2, img_r102_1, img_r102_2, img_r102_3, img_r102_4, img_r102_5, img_r102_6, img_r102_7, img_r102_8, img_r102_9 };
			Steplist_R103_R104_R105 = new List<Image> { img_Base, img_rOptional_1_2, img_r102_1, img_r102_2, img_r102_3, img_r102_4, img_r102_5, img_r102_6, img_r102_7, img_r102_8, img_r103_104_105_1, img_rOptional_3_4_5_6, img_rOptional_3_4_5 };
			Steplist_R106 = new List<Image> { img_Base, img_rOptional_1_2, img_r102_1, img_r102_2, img_r102_3, img_r102_4, img_r102_5, img_r102_6, img_r102_7, img_r102_8, img_r103_104_105_1, img_rOptional_3_4_5_6, img_r106_1, img_r106_2, img_r106_3 };
			Steplist_R107_R110 = new List<Image> { img_Base, img_r112_1, img_r112_2, img_r112_3, img_r112_4, img_r112_5, img_r111_1, img_r111_2, img_r111_3, img_r111_4, img_r111_5, img_r111_6, img_r111_7, img_r107_110_1, img_r107_110_2, img_rOptional_7_8_9_10 };
			Steplist_R108_R109 = new List<Image> { img_Base, img_r112_1, img_r112_2, img_r112_3, img_r112_4, img_r112_5, img_r111_1, img_r111_2, img_r111_3, img_r111_4, img_r111_5, img_r111_6, img_r111_7, img_r107_110_1, img_r107_110_2, img_rOptional_7_8_9_10, img_rOptional_8_9 };
			Steplist_R111 = new List<Image> { img_Base, img_r112_1, img_r112_2, img_r112_3, img_r112_4, img_r112_5, img_r111_1, img_r111_2, img_r111_3, img_r111_4, img_r111_5, img_r111_6, img_r111_7, img_r111_8 };
			Steplist_R112 = new List<Image> { img_Base, img_r112_1, img_r112_2, img_r112_3, img_r112_4, img_r112_5, img_r112_6, img_r112_7, img_r112_8 };
			ButtonList = new List<Button> { btn_r101, btn_r102, btn_r103, btn_r104, btn_r105, btn_r106, btn_r107, btn_r108, btn_r109, btn_r110, btn_r111, btn_r112 };
		}

		private void Room_Click(object sender, RoutedEventArgs e)
		{
			var clicked_Button = e.OriginalSource as Button;
			if (clicked_Button.Name.Equals(btn_r101.Name)) { Step_Populator(Steplist_R101, Global.Room.R101); }
			else if (clicked_Button.Name.Equals(btn_r102.Name)) { Step_Populator(Steplist_R102, Global.Room.R102); }
			else if (clicked_Button.Name.Equals(btn_r103.Name)) { Step_Populator(Steplist_R103_R104_R105, Global.Room.R103); }
			else if (clicked_Button.Name.Equals(btn_r104.Name)) { Step_Populator(Steplist_R103_R104_R105, Global.Room.R104); }
			else if (clicked_Button.Name.Equals(btn_r105.Name)) { Step_Populator(Steplist_R103_R104_R105, Global.Room.R105); }
			else if (clicked_Button.Name.Equals(btn_r106.Name)) { Step_Populator(Steplist_R106, Global.Room.R106); }
			else if (clicked_Button.Name.Equals(btn_r107.Name)) { Step_Populator(Steplist_R107_R110, Global.Room.R107); }
			else if (clicked_Button.Name.Equals(btn_r108.Name)) { Step_Populator(Steplist_R108_R109, Global.Room.R108); }
			else if (clicked_Button.Name.Equals(btn_r109.Name)) { Step_Populator(Steplist_R108_R109, Global.Room.R109); }
			else if (clicked_Button.Name.Equals(btn_r110.Name) || clicked_Button.Name.Equals(btn_r110_1.Name) || clicked_Button.Name.Equals(btn_r110_2.Name)) { Step_Populator(Steplist_R107_R110, Global.Room.R110); }
			else if (clicked_Button.Name.Equals(btn_r111.Name)) { Step_Populator(Steplist_R111, Global.Room.R111); }
			else if (clicked_Button.Name.Equals(btn_r112.Name)) { Step_Populator(Steplist_R112, Global.Room.R112); }
		}

		private void Timer_Tick(object sender, object e)
		{
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
		}

		private void Homebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Home));
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

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Global.Show_Hide_Image(Steplist_R101, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R102, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R103_R104_R105, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R106, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R107_R110, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R108_R109, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R111, Global.Img_Property.Collapsed);
			Global.Show_Hide_Image(Steplist_R112, Global.Img_Property.Collapsed);
			if (Global.language == "Filipino")
			{
				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Trabaho";

				//sFlr.Label = "Pangalawang Palapag";

				MainTitle.Text = "MAPA";
			}
			ContentDialog InstructionDialog = new ContentDialog()
			{
				Title = "Tap the Rooms",
				Content = new Image
				{
					Source = new BitmapImage(new Uri("ms-appx:///Assets/tapping.gif"))
				},
				CloseButtonText = "Ok"
			};

			await InstructionDialog.ShowAsync();


		}

		private void sndFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_2f));
		}

		private void trdFlr_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Map_3f));
		}

		private async void Step_Populator(List<Image> StepList, Global.Room room)
		{
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			Temp_ListSteps = StepList;
			Global.Enable_Disable_Button(Global.Button_Property.Disable, ButtonList);
			foreach (var step in StepList)
			{
				if (step.Equals(img_Base))
				{
					if (room.Equals(Global.Room.R107) || room.Equals(Global.Room.R108) || room.Equals(Global.Room.R109) || room.Equals(Global.Room.R110) || room.Equals(Global.Room.R111) || room.Equals(Global.Room.R112))
					{
						step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png"));
					}
					else
						step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png"));
				}
				if (step.Equals(img_rOptional_1_2))
				{
					if (room.Equals(Global.Room.R101)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/downrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
				}
				if (step.Equals(img_rOptional_3_4_5_6))
				{
					if (room.Equals(Global.Room.R106)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_3_4_5))
				{
					if (room.Equals(Global.Room.R103)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else if (room.Equals(Global.Room.R104)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
					else if (room.Equals(Global.Room.R105)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
				}
				if (step.Equals(img_rOptional_7_8_9_10))
				{
					if (room.Equals(Global.Room.R107)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
					else if (room.Equals(Global.Room.R110)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/rightrow.png")); }
					else { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/uprow.png")); }
				}
				if (step.Equals(img_rOptional_8_9))
				{
					if (room.Equals(Global.Room.R108)) { step.Source = new BitmapImage(new Uri("ms-appx:///Assets/leftrow.png")); }
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
	}
}
