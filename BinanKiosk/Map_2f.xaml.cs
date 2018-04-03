using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BinanKiosk.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_2f : Page
	{
		List<Rectangle> Steplist_R201, Steplist_R202, Steplist_R203, Steplist_R204, Steplist_R205, Steplist_R206,
			Steplist_R207, Steplist_R208, Steplist_R209, Steplist_R210, Steplist_R211, Steplist_R212, Steplist_R213,
			Steplist_R214, Steplist_R215, Steplist_R216, Steplist_R217, Steplist_R218, Steplist_R219,
			Steplist_R220, Steplist_R221, Steplist_R222, Steplist_Stairs_3f, Temp_ListSteps;

		List<Button> ButtonList;
		DispatcherTimer Timer = new DispatcherTimer();
		int counter = 0;
		public Map_2f()
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
			//For the Timer
			Timer.Tick += Timer_Tick;
			Time.Text = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM dd, yyyy") + System.Environment.NewLine + DateTime.Now.ToString("h:mm:ss tt");
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
			//Population of list
			Steplist_R201 = new List<Rectangle> { rect_r201_1, rect_r201_2, rect_r201_3, rect_r201_4, rect_r201_5, rect_r201_6, rect_r201_7, rect_r201_8, rect_r201_9, rect_r201_10, rect_r201_11, rect_r201_12, rect_r201_13, rect_r201_14, rect_r201_15, rect_r201_16, rect_r201_17, rect_r201_18, rect_r201_19, rect_r201_20, rect_r201_21, rect_r201_22, rect_r201_23, rect_r201_24, rect_r201_25, rect_r201_26, rect_r201_27, rect_r201_28 };
			Steplist_R202 = new List<Rectangle> { rect_r202_1, rect_r202_2, rect_r202_3, rect_r202_4, rect_r202_5, rect_r202_6, rect_r202_7, rect_r202_8, rect_r202_9, rect_r202_10, rect_r202_11, rect_r202_12, rect_r202_13, rect_r202_14, rect_r202_15, rect_r202_16, rect_r202_17, rect_r202_18, rect_r202_19, rect_r202_20, rect_r202_21, rect_r202_22, rect_r202_23, rect_r202_24, rect_r202_25, rect_r202_26, rect_r202_27, rect_r202_28, rect_r202_29, rect_r202_30, rect_r202_31, rect_r202_32, rect_r202_33, rect_r202_34, rect_r202_35, rect_r202_36, rect_r202_37, rect_r202_38, rect_r202_39, rect_r202_40, rect_r202_41 };
			Steplist_R203 = new List<Rectangle> { rect_r203_1, rect_r203_2, rect_r203_3, rect_r203_4, rect_r203_5, rect_r203_6, rect_r203_7, rect_r203_8, rect_r203_9, rect_r203_10, rect_r203_11, rect_r203_12, rect_r203_13, rect_r203_14, rect_r203_15, rect_r203_16, rect_r203_17, rect_r203_18, rect_r203_19, rect_r203_20, rect_r203_21, rect_r203_22, rect_r203_23, rect_r203_24 };
			Steplist_R204 = new List<Rectangle> { rect_r204_1, rect_r204_2, rect_r204_3, rect_r204_4, rect_r204_5, rect_r204_6, rect_r204_7, rect_r204_8, rect_r204_9, rect_r204_10, rect_r204_11, rect_r204_12, rect_r204_13, rect_r204_14, rect_r204_15, rect_r204_16, rect_r204_17, rect_r204_18, rect_r204_19, rect_r204_20, rect_r204_21, rect_r204_22 };
			Steplist_R205 = new List<Rectangle> { rect_r205_1, rect_r205_2, rect_r205_3, rect_r205_4, rect_r205_5, rect_r205_6, rect_r205_7, rect_r205_8, rect_r205_9, rect_r205_10, rect_r205_11, rect_r205_12, rect_r205_13, rect_r205_14, rect_r205_15, rect_r205_16, rect_r205_17, rect_r205_18, rect_r205_19, rect_r205_20, rect_r205_21, rect_r205_22, rect_r205_23, rect_r205_24, rect_r205_25, rect_r205_26, rect_r205_27, rect_r205_28 };
			Steplist_R206 = new List<Rectangle> { rect_r206_1, rect_r206_2, rect_r206_3, rect_r206_4, rect_r206_5, rect_r206_6, rect_r206_7, rect_r206_8, rect_r206_9, rect_r206_10, rect_r206_11, rect_r206_12, rect_r206_13, rect_r206_14, rect_r206_15, rect_r206_16, rect_r206_17, rect_r206_18, rect_r206_19, rect_r206_20, rect_r206_21, rect_r206_22, rect_r206_23, rect_r206_24, rect_r206_25, rect_r206_26, rect_r206_27, rect_r206_28, rect_r206_29, rect_r206_30, rect_r206_31 };
			Steplist_R207 = new List<Rectangle> { rect_r207_1, rect_r207_2, rect_r207_3, rect_r207_4, rect_r207_5, rect_r207_6, rect_r207_7, rect_r207_8, rect_r207_9, rect_r207_10, rect_r207_11, rect_r207_12, rect_r207_13, rect_r207_14, rect_r207_15, rect_r207_16, rect_r207_17, rect_r207_18, rect_r207_19, rect_r207_20, rect_r207_21, rect_r207_22, rect_r207_23, rect_r207_24, rect_r207_25, rect_r207_26, rect_r207_27, rect_r207_28, rect_r207_29, rect_r207_30, rect_r207_31, rect_r207_32, rect_r207_33, rect_r207_34 };
			Steplist_R208 = new List<Rectangle> { rect_r208_1, rect_r208_2, rect_r208_3, rect_r208_4, rect_r208_5, rect_r208_6, rect_r208_7, rect_r208_8, rect_r208_9, rect_r208_10, rect_r208_11, rect_r208_12, rect_r208_13, rect_r208_14, rect_r208_15, rect_r208_16, rect_r208_17, rect_r208_18, rect_r208_19, rect_r208_20, rect_r208_21, rect_r208_22, rect_r208_23, rect_r208_24, rect_r208_25, rect_r208_26, rect_r208_27, rect_r208_28, rect_r208_29, rect_r208_30, rect_r208_31, rect_r208_32, rect_r208_33, rect_r208_34 };
			Steplist_R209 = new List<Rectangle> { rect_r209_1, rect_r209_2, rect_r209_3, rect_r209_4, rect_r209_5, rect_r209_6, rect_r209_7, rect_r209_8, rect_r209_9, rect_r209_10, rect_r209_11, rect_r209_12, rect_r209_13, rect_r209_14, rect_r209_15, rect_r209_16, rect_r209_17, rect_r209_18, rect_r209_19, rect_r209_20, rect_r209_21, rect_r209_22, rect_r209_23, rect_r209_24, rect_r209_25, rect_r209_26, rect_r209_27, rect_r209_28, rect_r209_29, rect_r209_30, rect_r209_31, rect_r209_32, rect_r209_33, rect_r209_34, rect_r209_35, rect_r209_36, rect_r209_37, rect_r209_38, rect_r209_39, rect_r209_40, rect_r209_41, rect_r209_42, rect_r209_43, rect_r209_44, rect_r209_45, rect_r209_46 };
			Steplist_R210 = new List<Rectangle> { rect_r210_1, rect_r210_2, rect_r210_3, rect_r210_4, rect_r210_5, rect_r210_6, rect_r210_7, rect_r210_8, rect_r210_9, rect_r210_10, rect_r210_11, rect_r210_12, rect_r210_13, rect_r210_14, rect_r210_15, rect_r210_16, rect_r210_17, rect_r210_18, rect_r210_19, rect_r210_20, rect_r210_21, rect_r210_22, rect_r210_23, rect_r210_24, rect_r210_25, rect_r210_26, rect_r210_27, rect_r210_28, rect_r210_29, rect_r210_30, rect_r210_31, rect_r210_32, rect_r210_33, rect_r210_34, rect_r210_35, rect_r210_36, rect_r210_37, rect_r210_38, rect_r210_39, rect_r210_40, rect_r210_41 };
			Steplist_R211 = new List<Rectangle> { rect_r211_1, rect_r211_2, rect_r211_3, rect_r211_4, rect_r211_5, rect_r211_6, rect_r211_7, rect_r211_8, rect_r211_9, rect_r211_10, rect_r211_11, rect_r211_12, rect_r211_13, rect_r211_14, rect_r211_15, rect_r211_16, rect_r211_17, rect_r211_18, rect_r211_19, rect_r211_20, rect_r211_21, rect_r211_22, rect_r211_23, rect_r211_24, rect_r211_25, rect_r211_26, rect_r211_27, rect_r211_28, rect_r211_29, rect_r211_30, rect_r211_31, rect_r211_32, rect_r211_33, rect_r211_34, rect_r211_35, rect_r211_36, rect_r211_37, rect_r211_38, rect_r211_39, rect_r211_40, rect_r211_41, rect_r211_42, rect_r211_43, rect_r211_44, rect_r211_45, rect_r211_46 };
			Steplist_R212 = new List<Rectangle> { rect_r212_1, rect_r212_2, rect_r212_3, rect_r212_4, rect_r212_5, rect_r212_6, rect_r212_7, rect_r212_8, rect_r212_9, rect_r212_10, rect_r212_11, rect_r212_12, rect_r212_13, rect_r212_14, rect_r212_15, rect_r212_16, rect_r212_17, rect_r212_18, rect_r212_19, rect_r212_20, rect_r212_21, rect_r212_22, rect_r212_23, rect_r212_24, rect_r212_25, rect_r212_26, rect_r212_27, rect_r212_28, rect_r212_29, rect_r212_30, rect_r212_31, rect_r212_32, rect_r212_33, rect_r212_34, rect_r212_35, rect_r212_36, rect_r212_37, rect_r212_38, rect_r212_39, rect_r212_40, rect_r212_41, rect_r212_42 };
			Steplist_R213 = new List<Rectangle> { rect_r213_1, rect_r213_2, rect_r213_3, rect_r213_4, rect_r213_5, rect_r213_6, rect_r213_7, rect_r213_8, rect_r213_9, rect_r213_10, rect_r213_11, rect_r213_12, rect_r213_13, rect_r213_14, rect_r213_15, rect_r213_16, rect_r213_17, rect_r213_18, rect_r213_19, rect_r213_20, rect_r213_21, rect_r213_22, rect_r213_23, rect_r213_24, rect_r213_25, rect_r213_26, rect_r213_27, rect_r213_28, rect_r213_29, rect_r213_30, rect_r213_31, rect_r213_32, rect_r213_33, rect_r213_34, rect_r213_35, rect_r213_36, rect_r213_37, rect_r213_38, rect_r213_39 };
			Steplist_R214 = new List<Rectangle> { rect_r214_1, rect_r214_2, rect_r214_3, rect_r214_4, rect_r214_5, rect_r214_6, rect_r214_7, rect_r214_8, rect_r214_9, rect_r214_10, rect_r214_11, rect_r214_12, rect_r214_13, rect_r214_14, rect_r214_15, rect_r214_16, rect_r214_17, rect_r214_18, rect_r214_19, rect_r214_20, rect_r214_21, rect_r214_22, rect_r214_23, rect_r214_24, rect_r214_25, rect_r214_26, rect_r214_27, rect_r214_28, rect_r214_29, rect_r214_30, rect_r214_31, rect_r214_32 };
			Steplist_R215 = new List<Rectangle> { rect_r215_1, rect_r215_2, rect_r215_3, rect_r215_4, rect_r215_5, rect_r215_6, rect_r215_7, rect_r215_8, rect_r215_9, rect_r215_10, rect_r215_11, rect_r215_12, rect_r215_13, rect_r215_14, rect_r215_15, rect_r215_16, rect_r215_17, rect_r215_18, rect_r215_19, rect_r215_20, rect_r215_21, rect_r215_22, rect_r215_23, rect_r215_24, rect_r215_25, rect_r215_26, rect_r215_27, rect_r215_28, rect_r215_29 };
			Steplist_R216 = new List<Rectangle> { rect_r216_1, rect_r216_2, rect_r216_3, rect_r216_4, rect_r216_5, rect_r216_6, rect_r216_7, rect_r216_8, rect_r216_9, rect_r216_10, rect_r216_11, rect_r216_12, rect_r216_13, rect_r216_14, rect_r216_15, rect_r216_16, rect_r216_17, rect_r216_18, rect_r216_19, rect_r216_20, rect_r216_21, rect_r216_22, rect_r216_23, rect_r216_24, rect_r216_25, rect_r216_26 };
			Steplist_R217 = new List<Rectangle> { rect_r217_1, rect_r217_2, rect_r217_3, rect_r217_4, rect_r217_5, rect_r217_6, rect_r217_7, rect_r217_8, rect_r217_9, rect_r217_10, rect_r217_11, rect_r217_12, rect_r217_13, rect_r217_14, rect_r217_15, rect_r217_16, rect_r217_17, rect_r217_18, rect_r217_19, rect_r217_20, rect_r217_21, rect_r217_22, rect_r217_23 };
			Steplist_R218 = new List<Rectangle> { rect_r218_1, rect_r218_2, rect_r218_3, rect_r218_4, rect_r218_5, rect_r218_6, rect_r218_7, rect_r218_8, rect_r218_9, rect_r218_10, rect_r218_11, rect_r218_12, rect_r218_13, rect_r218_14, rect_r218_15, rect_r218_16, rect_r218_17, rect_r218_18, rect_r218_19 };
			Steplist_R219 = new List<Rectangle> { rect_r219_1, rect_r219_2, rect_r219_3, rect_r219_4, rect_r219_5, rect_r219_6, rect_r219_7, rect_r219_8, rect_r219_9, rect_r219_10, rect_r219_11, rect_r219_12, rect_r219_13, rect_r219_14, rect_r219_15, rect_r219_16, rect_r219_17 };
			Steplist_R220 = new List<Rectangle> { rect_r220_1, rect_r220_2, rect_r220_3, rect_r220_4, rect_r220_5, rect_r220_6, rect_r220_7, rect_r220_8, rect_r220_9, rect_r220_10, rect_r220_11, rect_r220_12, rect_r220_13, rect_r220_14, rect_r220_15, rect_r220_16, rect_r220_17, rect_r220_18, rect_r220_19, rect_r220_20, rect_r220_21, rect_r220_22, rect_r220_23, rect_r220_24, rect_r220_25, rect_r220_26 };
			Steplist_R221 = new List<Rectangle> { rect_r221_1, rect_r221_2, rect_r221_3, rect_r221_4, rect_r221_5, rect_r221_6, rect_r221_7, rect_r221_8, rect_r221_9, rect_r221_10, rect_r221_11, rect_r221_12, rect_r221_13, rect_r221_14, rect_r221_15, rect_r221_16, rect_r221_17, rect_r221_18, rect_r221_19, rect_r221_20, rect_r221_21, rect_r221_22, rect_r221_23, rect_r221_24, rect_r221_25, rect_r221_26, rect_r221_27, rect_r221_28, rect_r221_29, rect_r221_30, rect_r221_31, rect_r221_32, rect_r221_33, rect_r221_34, rect_r221_35, rect_r221_36, rect_r221_37, rect_r221_38, rect_r221_39, rect_r221_40, rect_r221_41, rect_r221_42, rect_r221_43, rect_r221_44, rect_r221_45 };
			Steplist_R222 = new List<Rectangle> { rect_r222_1, rect_r222_2, rect_r222_3, rect_r222_4, rect_r222_5, rect_r222_6, rect_r222_7, rect_r222_8, rect_r222_9, rect_r222_10, rect_r222_11, rect_r222_12, rect_r222_13, rect_r222_14, rect_r222_15, rect_r222_16, rect_r222_17, rect_r222_18, rect_r222_19, rect_r222_20, rect_r222_21, rect_r222_22, rect_r222_23, rect_r222_24, rect_r222_25, rect_r222_26, rect_r222_27, rect_r222_28, rect_r222_29 };
			Steplist_Stairs_3f = new List<Rectangle> { rect_LeftStairs_1, rect_LeftStairs_2, rect_LeftStairs_3, rect_LeftStairs_4, rect_LeftStairs_5, rect_LeftStairs_6, rect_LeftStairs_7, rect_LeftStairs_8, rect_LeftStairs_9, rect_LeftStairs_10 };
			//Steplist_RightStairs_3f = new List<Rectangle> { rect_RightStairs_1, rect_RightStairs_2, rect_RightStairs_3, rect_RightStairs_4, rect_RightStairs_5, rect_RightStairs_6, rect_RightStairs_7, rect_RightStairs_8, rect_RightStairs_9, rect_RightStairs_10, rect_RightStairs_11, rect_RightStairs_12, rect_RightStairs_13, rect_RightStairs_14, rect_RightStairs_15, rect_RightStairs_16 };
			ButtonList = new List<Button> { btn_R201, btn_R202, btn_R203, btn_R204, btn_R205, btn_R206, btn_R207, btn_R208, btn_R209, btn_R210, btn_R211, btn_R212, btn_R213, btn_R214, btn_R215, btn_R216, btn_R217, btn_R218, btn_R219, btn_R220, btn_R221, btn_R222 };
			#endregion
			Global.Button_Renaming(ButtonList);
			Global.IsClicked = false;
			if (e.Parameter != null && !e.Parameter.Equals(""))
			{
				Timer.Stop();
				await Task.Delay(TimeSpan.FromSeconds(0.5));
				var room = (Global.Room)e.Parameter;
				//remove first floor from the stack of frame
				this.Frame.BackStack.RemoveAt(this.Frame.BackStackDepth - 1);
				//going to third floor
				if (room.Equals(Global.Room.R301) || room.Equals(Global.Room.R302) || room.Equals(Global.Room.R303) ||
					room.Equals(Global.Room.R304) || room.Equals(Global.Room.R305) || room.Equals(Global.Room.R306) ||
					room.Equals(Global.Room.R307) || room.Equals(Global.Room.R308) || room.Equals(Global.Room.R309) ||
					room.Equals(Global.Room.R310) || room.Equals(Global.Room.R311) || room.Equals(Global.Room.R312))
				{
					this.NavigationCacheMode = NavigationCacheMode.Disabled;
					await Room_Populator(Global.Room.Stairs_3F);
					await Task.Delay(TimeSpan.FromSeconds(0.5));
					this.Frame.Navigate(typeof(Map_3f), room);
				}
				//to the second floor
				else
				{
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
				var thirdFloor_btn = (trdFlr.Content as Grid).Children[1] as TextBlock;
				thirdFloor_btn.Text = "Ikatlong Palapag";
				lb_currentFloor.Text = "Ikalawang Palapag";
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
				counter = 0;
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
			if (room.Equals(Global.Room.R201)) { await Step_Populator(Steplist_R201, room); }
			else if (room.Equals(Global.Room.R202)) { await Step_Populator(Steplist_R202, room); }
			else if (room.Equals(Global.Room.R203)) { await Step_Populator(Steplist_R203, room); }
			else if (room.Equals(Global.Room.R204)) { await Step_Populator(Steplist_R204, room); }
			else if (room.Equals(Global.Room.R205)) { await Step_Populator(Steplist_R205, room); }
			else if (room.Equals(Global.Room.R206)) { await Step_Populator(Steplist_R206, room); }
			else if (room.Equals(Global.Room.R207)) { await Step_Populator(Steplist_R207, room); }
			else if (room.Equals(Global.Room.R208)) { await Step_Populator(Steplist_R208, room); }
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
			else if (room.Equals(Global.Room.Stairs_3F)) { await Step_Populator(Steplist_Stairs_3f, room); }
		}

		private async void Goto_OtherForm(TappedRoutedEventArgs e)
		{
			Timer.Stop();
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
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

		private async void trdFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_3f));
		}

		private async void fstFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_1f));
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
				//ContentDialog InstructionDialog = new ContentDialog()
				//{
				//	Title = "Instruction",
				//	Content = "You have reached the destination!",
				//	CloseButtonText = "Ok"
				//};
				//await InstructionDialog.ShowAsync();
			}
		}
	}
}
