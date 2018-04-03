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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_3f : Page
	{
		List<Rectangle> Steplist_R301, Steplist_R302, Steplist_R303, Steplist_R304, Steplist_R305, Steplist_R306,
			Steplist_R307, Steplist_R308, Steplist_R309, Steplist_R310, Steplist_R311, Steplist_R312, Temp_ListSteps;
		List<Button> ButtonList;
		DispatcherTimer Timer = new DispatcherTimer();
		int counter = 0;
		public Map_3f()
		{
			this.InitializeComponent();
		}
		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			counter = 0;
			base.OnNavigatedTo(e);
			#region INITIALIZATION
			Global.IsClicked = false;
			DataContext = this;
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			Steplist_R301 = new List<Rectangle> { rect_r301_1, rect_r301_2, rect_r301_3, rect_r301_4, rect_r301_5, rect_r301_6, rect_r301_7, rect_r301_8, rect_r301_9, rect_r301_10, rect_r301_11, rect_r301_12, rect_r301_13, rect_r301_14, rect_r301_15, rect_r301_16, rect_r301_17, rect_r301_18 };
			Steplist_R302 = new List<Rectangle> { rect_r302_1, rect_r302_2, rect_r302_3, rect_r302_4, rect_r302_5, rect_r302_6, rect_r302_7, rect_r302_8, rect_r302_9, rect_r302_10, rect_r302_11, rect_r302_12 };
			Steplist_R303 = new List<Rectangle> { rect_r303_1, rect_r303_2, rect_r303_3, rect_r303_4, rect_r303_5, rect_r303_6, rect_r303_7, rect_r303_8, rect_r303_9, rect_r303_10, rect_r303_11, rect_r303_12, rect_r303_13, rect_r303_14, rect_r303_15, rect_r303_16, rect_r303_17, rect_r303_18, rect_r303_19, rect_r303_20, rect_r303_21, rect_r303_22, rect_r303_23, rect_r303_24, rect_r303_25, rect_r303_26, rect_r303_27, rect_r303_28, rect_r303_29, rect_r303_30, rect_r303_31 };
			Steplist_R304 = new List<Rectangle> { rect_r304_1, rect_r304_2, rect_r304_3, rect_r304_4, rect_r304_5, rect_r304_6, rect_r304_7, rect_r304_8, rect_r304_9, rect_r304_10, rect_r304_11, rect_r304_12, rect_r304_13, rect_r304_14, rect_r304_15, rect_r304_16, rect_r304_17, rect_r304_18, rect_r304_19, rect_r304_20, rect_r304_21, rect_r304_22, rect_r304_23, rect_r304_24, rect_r304_25, rect_r304_26, rect_r304_27, rect_r304_28, rect_r304_29 };
			Steplist_R305 = new List<Rectangle> { rect_r305_1, rect_r305_2, rect_r305_3, rect_r305_4, rect_r305_5, rect_r305_6, rect_r305_7 };
			Steplist_R306 = new List<Rectangle> { rect_r306_1, rect_r306_2, rect_r306_3, rect_r306_4, rect_r306_5, rect_r306_6, rect_r306_7, rect_r306_8, rect_r306_9, rect_r306_10, rect_r306_11, rect_r306_12, rect_r306_13, rect_r306_14, rect_r306_15, rect_r306_16, rect_r306_17, rect_r306_18, rect_r306_19, rect_r306_20, rect_r306_21, rect_r306_22, rect_r306_23, rect_r306_24, rect_r306_25, rect_r306_26, rect_r306_27, rect_r306_28 };
			Steplist_R307 = new List<Rectangle> { rect_r307_1, rect_r307_2, rect_r307_3, rect_r307_4, rect_r307_5, rect_r307_6, rect_r307_7, rect_r307_8, rect_r307_9, rect_r307_10, rect_r307_11, rect_r307_12, rect_r307_13, rect_r307_14, rect_r307_15, rect_r307_16, rect_r307_17, rect_r307_18, rect_r307_19, rect_r307_20, rect_r307_21, rect_r307_22, rect_r307_23, rect_r307_24, rect_r307_25, rect_r307_26, rect_r307_27, rect_r307_28, rect_r307_29, rect_r307_30, rect_r307_31, rect_r307_32, rect_r307_33, rect_r307_34, rect_r307_35, rect_r307_36, rect_r307_37, rect_r307_38 };

			Steplist_R308 = new List<Rectangle> { rect_r308_1, rect_r308_2, rect_r308_3, rect_r308_4, rect_r308_5, rect_r308_6, rect_r308_7, rect_r308_8, rect_r308_9, rect_r308_10, rect_r308_11, rect_r308_12, rect_r308_13, rect_r308_14, rect_r308_15, rect_r308_16, rect_r308_17, rect_r308_18, rect_r308_19, rect_r308_20, rect_r308_21, rect_r308_22, rect_r308_23, rect_r308_24, rect_r308_25, rect_r308_26, rect_r308_27, rect_r308_28, rect_r308_29, rect_r308_30, rect_r308_31, rect_r308_32, rect_r308_33, rect_r308_34, rect_r308_35, rect_r308_36, rect_r308_37, rect_r308_38, rect_r308_39, rect_r308_40, rect_r308_41 };
			Steplist_R309 = new List<Rectangle> { rect_r309_1, rect_r309_2, rect_r309_3, rect_r309_4, rect_r309_5, rect_r309_6, rect_r309_7, rect_r309_8, rect_r309_9, rect_r309_10, rect_r309_11, rect_r309_12, rect_r309_13, rect_r309_14, rect_r309_15, rect_r309_16, rect_r309_17, rect_r309_18, rect_r309_19, rect_r309_20 };
			Steplist_R310 = new List<Rectangle> { rect_r310_1, rect_r310_2, rect_r310_3, rect_r310_4, rect_r310_5, rect_r310_6, rect_r310_7, rect_r310_8, rect_r310_9, rect_r310_10, rect_r310_11, rect_r310_12, rect_r310_13, rect_r310_14, rect_r310_15, rect_r310_16, rect_r310_17, rect_r310_18, rect_r310_19, rect_r310_20, rect_r310_21, rect_r310_22 };
			Steplist_R311 = new List<Rectangle> { rect_r311_1, rect_r311_2, rect_r311_3, rect_r311_4, rect_r311_5, rect_r311_6, rect_r311_7, rect_r311_8, rect_r311_9, rect_r311_10, rect_r311_11, rect_r311_12, rect_r311_13, rect_r311_14, rect_r311_15, rect_r311_16, rect_r311_17, rect_r311_18, rect_r311_19, rect_r311_20, rect_r311_21, rect_r311_22, rect_r311_23, rect_r311_24, rect_r311_25, rect_r311_26, rect_r311_27, rect_r311_28 };
			Steplist_R312 = new List<Rectangle> { rect_r312_1, rect_r312_2, rect_r312_3, rect_r312_4, rect_r312_5, rect_r312_6, rect_r312_7, rect_r312_8, rect_r312_9, rect_r312_10, rect_r312_11, rect_r312_12, rect_r312_13, rect_r312_14, rect_r312_15, rect_r312_16, rect_r312_17, rect_r312_18, rect_r312_19, rect_r312_20, rect_r312_21, rect_r312_22, rect_r312_23, rect_r312_24, rect_r312_25, rect_r312_26, rect_r312_27, rect_r312_28, rect_r312_29, rect_r312_30, rect_r312_31, rect_r312_32, rect_r312_33, rect_r312_34, rect_r312_35, rect_r312_36, rect_r312_37, rect_r312_38 };
			ButtonList = new List<Button> { btn_R301, btn_R302, btn_R303, btn_R304, btn_R305, btn_R306, btn_R307, btn_R308, btn_R309, btn_R310, btn_R311, btn_R312 };
			#endregion
			Global.Button_Renaming(ButtonList);
			if (e.Parameter != null && !e.Parameter.Equals(""))
			{
				//removes the second floor to the stack
				this.Frame.BackStack.RemoveAt(this.Frame.BackStackDepth - 1);
				Timer.Stop();
				var room = (Global.Room)e.Parameter;
				await Room_Populator(room);
				ContentDialog InstructionDialog = new ContentDialog()
				{
					Title = "NOTIFICATION",
					Content = "You have reached the destination!",
					CloseButtonText = "Ok"
				};
				await InstructionDialog.ShowAsync();
			}
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
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			
			if (Global.language == "Filipino")
			{
				MainTitle.Text = "MGA MAPA";

				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
				var firstFloor_btn = (fstFlr.Content as Grid).Children[1] as TextBlock;
				firstFloor_btn.Text = "Unang Palapag";
				var secondFloor_btn = (sndFlr.Content as Grid).Children[1] as TextBlock;
				secondFloor_btn.Text = "Ikalawang Palapag";
				lb_currentFloor.Text = "Ikatlong Palapag";
			}

		}

		private async Task Step_Populator(List<Rectangle> StepList, Global.Room room)
		{
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			Temp_ListSteps = StepList;
			Global.Enable_Disable_Button(Global.Button_Property.Disable, ButtonList);
			foreach (var step in StepList)
			{
				step.Visibility = Visibility.Visible;
				await Task.Delay(TimeSpan.FromSeconds(0.05));
			}
			//Number of Blinks after showing the arrows
			//for (int i = 0; i < 4; i++)
			//{
			//	Global.Show_Hide_Image(StepList, Global.Img_Property.Collapsed);
			//	await Task.Delay(TimeSpan.FromSeconds(0.5));
			//	Global.Show_Hide_Image(StepList, Global.Img_Property.Visible);
			//	await Task.Delay(TimeSpan.FromSeconds(0.5));
			//}
			Global.Enable_Disable_Button(Global.Button_Property.Enable, ButtonList);
			Global.IsClicked = true;
		}
		private async Task Room_Populator(Global.Room room)
		{
			if (room.Equals(Global.Room.R301)) { await Step_Populator(Steplist_R301, room); }
			else if (room.Equals(Global.Room.R302)) { await Step_Populator(Steplist_R302, room); }
			else if (room.Equals(Global.Room.R303)) { await Step_Populator(Steplist_R303, room); }
			else if (room.Equals(Global.Room.R304)) { await Step_Populator(Steplist_R304, room); }
			else if (room.Equals(Global.Room.R305)) { await Step_Populator(Steplist_R305, room); }
			else if (room.Equals(Global.Room.R306)) { await Step_Populator(Steplist_R306, room); }
			else if (room.Equals(Global.Room.R307)) { await Step_Populator(Steplist_R307, room); }
			else if (room.Equals(Global.Room.R308)) { await Step_Populator(Steplist_R308, room); }
			else if (room.Equals(Global.Room.R309)) { await Step_Populator(Steplist_R309, room); }
			else if (room.Equals(Global.Room.R310)) { await Step_Populator(Steplist_R310, room); }
			else if (room.Equals(Global.Room.R311)) { await Step_Populator(Steplist_R311, room); }
			else if (room.Equals(Global.Room.R312)) { await Step_Populator(Steplist_R312, room); }
		}
		private void Room_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			string button_Name = (sender as Button).Name;
			if (button_Name != null)
			{
				Timer.Stop();
				this.Frame.Navigate(typeof(Map_1f), Global.Enum_Converter(button_Name.Split('_')[1]));
				//await Room_Populator(Global.Enum_Converter(button_Name.Split('_')[1]));
				
			}
		}
		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private void btn_Back_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			counter = 0;
			Global.GoBack(this);
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

		private async void fstFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_1f));
		}

		private async void sndFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_2f));
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
