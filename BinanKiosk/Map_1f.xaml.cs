using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BinanKiosk.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using BinanKiosk.Repository;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Input;
using BinanKiosk.Enums;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Map_1f : Page
	{
		int counter = 0;
		List<Rectangle> Steplist_R101, Steplist_R102, Steplist_R103, Steplist_R104, Steplist_R105, Steplist_R106,
			Steplist_R107,Steplist_R110, Steplist_R108,Steplist_R109, Steplist_R111, Steplist_R112, Steplist_Stairs_Left, Steplist_Stairs_Right, Temp_ListSteps;
		List<Button> ButtonList;

		DispatcherTimer Timer = new DispatcherTimer();
		public Map_1f()
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
			Steplist_R101 = new List<Rectangle> { rect_r101_1, rect_r101_2, rect_r101_3, rect_r101_4, rect_r101_5, rect_r101_6, rect_r101_7, rect_r101_8, rect_r101_9, rect_r101_10, rect_r101_11, rect_r101_12, rect_r101_13, rect_r101_14, rect_r101_15, rect_r101_16, rect_r101_17, rect_r101_18, rect_r101_19, rect_r101_20, rect_r101_21, rect_r101_22, rect_r101_23, rect_r101_24, rect_r101_25, rect_r101_26, rect_r101_27, rect_r101_28, rect_r101_29, rect_r101_30, rect_r101_31, rect_r101_32, rect_r101_33, rect_r101_34 };
			Steplist_R102 = new List<Rectangle> { rect_r102_1, rect_r102_2, rect_r102_3, rect_r102_4, rect_r102_5, rect_r102_6, rect_r102_7, rect_r102_8, rect_r102_9, rect_r102_10, rect_r102_11, rect_r102_12, rect_r102_13, rect_r102_14, rect_r102_15, rect_r102_16, rect_r102_17, rect_r102_18, rect_r102_19, rect_r102_20, rect_r102_21, rect_r102_22, rect_r102_23, rect_r102_24, rect_r102_25, rect_r102_26, rect_r102_27, rect_r102_28, rect_r102_29, rect_r102_30, rect_r102_31, rect_r102_32, rect_r102_33, rect_r102_34, rect_r102_35, rect_r102_36, rect_r102_37, rect_r102_38, rect_r102_39, rect_r102_40, rect_r102_41, rect_r102_42, rect_r102_43, rect_r102_44, rect_r102_45, rect_r102_46, rect_r102_47, rect_r102_48 };
			Steplist_R103 = new List<Rectangle> { rect_r103_1, rect_r103_2, rect_r103_3, rect_r103_4, rect_r103_5, rect_r103_6, rect_r103_7, rect_r103_8, rect_r103_9, rect_r103_10, rect_r103_11, rect_r103_12, rect_r103_13, rect_r103_14, rect_r103_15, rect_r103_16, rect_r103_17, rect_r103_18, rect_r103_19, rect_r103_20, rect_r103_21, rect_r103_22, rect_r103_23, rect_r103_24, rect_r103_25, rect_r103_26, rect_r103_27, rect_r103_28, rect_r103_29, rect_r103_30, rect_r103_31, rect_r103_32, rect_r103_33, rect_r103_34, rect_r103_35, rect_r103_36, rect_r103_37, rect_r103_38, rect_r103_39, rect_r103_40, rect_r103_41, rect_r103_42, rect_r103_43, rect_r103_44, rect_r103_45, rect_r103_46, rect_r103_47, rect_r103_48, rect_r103_49, rect_r103_50, rect_r103_51, rect_r103_52, rect_r103_53, rect_r103_54 };
			Steplist_R104 = new List<Rectangle> { rect_r104_1, rect_r104_2, rect_r104_3, rect_r104_4, rect_r104_5, rect_r104_6, rect_r104_7, rect_r104_8, rect_r104_9, rect_r104_10, rect_r104_11, rect_r104_12, rect_r104_13, rect_r104_14, rect_r104_15, rect_r104_16, rect_r104_17, rect_r104_18, rect_r104_19, rect_r104_20, rect_r104_21, rect_r104_22, rect_r104_23, rect_r104_24, rect_r104_25, rect_r104_26, rect_r104_27, rect_r104_28, rect_r104_29, rect_r104_30, rect_r104_31, rect_r104_32, rect_r104_33, rect_r104_34, rect_r104_35, rect_r104_36, rect_r104_37, rect_r104_38, rect_r104_39, rect_r104_40, rect_r104_41, rect_r104_42, rect_r104_43, rect_r104_44, rect_r104_45, rect_r104_46, rect_r104_47, rect_r104_48, rect_r104_49, rect_r104_50, rect_r104_51, rect_r104_52, rect_r104_53, rect_r104_54 };
			Steplist_R105 = new List<Rectangle> { rect_r105_1, rect_r105_2, rect_r105_3, rect_r105_4, rect_r105_5, rect_r105_6, rect_r105_7, rect_r105_8, rect_r105_9, rect_r105_10, rect_r105_11, rect_r105_12, rect_r105_13, rect_r105_14, rect_r105_15, rect_r105_16, rect_r105_17, rect_r105_18, rect_r105_19, rect_r105_20, rect_r105_21, rect_r105_22, rect_r105_23, rect_r105_24, rect_r105_25, rect_r105_26, rect_r105_27, rect_r105_28, rect_r105_29, rect_r105_30, rect_r105_31, rect_r105_32, rect_r105_33, rect_r105_34, rect_r105_35, rect_r105_36, rect_r105_37, rect_r105_38, rect_r105_39, rect_r105_40, rect_r105_41, rect_r105_42, rect_r105_43, rect_r105_44, rect_r105_45, rect_r105_46, rect_r105_47, rect_r105_48, rect_r105_49, rect_r105_50, rect_r105_51, rect_r105_52 };
			Steplist_R106 = new List<Rectangle> { rect_r106_1, rect_r106_2, rect_r106_3, rect_r106_4, rect_r106_5, rect_r106_6, rect_r106_7, rect_r106_8, rect_r106_9, rect_r106_10, rect_r106_11, rect_r106_12, rect_r106_13, rect_r106_14, rect_r106_15, rect_r106_16, rect_r106_17, rect_r106_18, rect_r106_19, rect_r106_20, rect_r106_21, rect_r106_22, rect_r106_23, rect_r106_24, rect_r106_25, rect_r106_26, rect_r106_27, rect_r106_28, rect_r106_29, rect_r106_30, rect_r106_31, rect_r106_32, rect_r106_33, rect_r106_34, rect_r106_35, rect_r106_36, rect_r106_37, rect_r106_38, rect_r106_39, rect_r106_40, rect_r106_41, rect_r106_42, rect_r106_43, rect_r106_44, rect_r106_45, rect_r106_46, rect_r106_47, rect_r106_48, rect_r106_49, rect_r106_50, rect_r106_51, rect_r106_52, rect_r106_53, rect_r106_54, rect_r106_55, rect_r106_56, rect_r106_57, rect_r106_58, rect_r106_59, rect_r106_60, rect_r106_61, rect_r106_62 };
			Steplist_R107 = new List<Rectangle> { rect_r107_1, rect_r107_2, rect_r107_3, rect_r107_4, rect_r107_5, rect_r107_6, rect_r107_7, rect_r107_8, rect_r107_9, rect_r107_10, rect_r107_11, rect_r107_12, rect_r107_13, rect_r107_14, rect_r107_15, rect_r107_16, rect_r107_17, rect_r107_18, rect_r107_19, rect_r107_20, rect_r107_21, rect_r107_22, rect_r107_23, rect_r107_24, rect_r107_25, rect_r107_26, rect_r107_27, rect_r107_28, rect_r107_29, rect_r107_30, rect_r107_31, rect_r107_32, rect_r107_33, rect_r107_34, rect_r107_35, rect_r107_36, rect_r107_37, rect_r107_38, rect_r107_39, rect_r107_40, rect_r107_41, rect_r107_42, rect_r107_43, rect_r107_44, rect_r107_45, rect_r107_46, rect_r107_47, rect_r107_48, rect_r107_49, rect_r107_50, rect_r107_51, rect_r107_52, rect_r107_53, rect_r107_54, rect_r107_55, rect_r107_56, rect_r107_57, rect_r107_58, rect_r107_59, rect_r107_60, rect_r107_61, rect_r107_62, rect_r107_63 };
			Steplist_R108 = new List<Rectangle> { rect_r108_1, rect_r108_2, rect_r108_3, rect_r108_4, rect_r108_5, rect_r108_6, rect_r108_7, rect_r108_8, rect_r108_9, rect_r108_10, rect_r108_11, rect_r108_12, rect_r108_13, rect_r108_14, rect_r108_15, rect_r108_16, rect_r108_17, rect_r108_18, rect_r108_19, rect_r108_20, rect_r108_21, rect_r108_22, rect_r108_23, rect_r108_24, rect_r108_25, rect_r108_26, rect_r108_27, rect_r108_28, rect_r108_29, rect_r108_30, rect_r108_31, rect_r108_32, rect_r108_33, rect_r108_34, rect_r108_35, rect_r108_36, rect_r108_37, rect_r108_38, rect_r108_39, rect_r108_40, rect_r108_41, rect_r108_42, rect_r108_43, rect_r108_44, rect_r108_45, rect_r108_46, rect_r108_47, rect_r108_48, rect_r108_49, rect_r108_50, rect_r108_51, rect_r108_52, rect_r108_53, rect_r108_54, rect_r108_55, rect_r108_56, rect_r108_57, rect_r108_58, rect_r108_59, rect_r108_60, rect_r108_61, rect_r108_62, rect_r108_63, rect_r108_64, rect_r108_65, rect_r108_66, rect_r108_67, rect_r108_68 };
			Steplist_R109 = new List<Rectangle> { rect_r109_1, rect_r109_2, rect_r109_3, rect_r109_4, rect_r109_5, rect_r109_6, rect_r109_7, rect_r109_8, rect_r109_9, rect_r109_10, rect_r109_11, rect_r109_12, rect_r109_13, rect_r109_14, rect_r109_15, rect_r109_16, rect_r109_17, rect_r109_18, rect_r109_19, rect_r109_20, rect_r109_21, rect_r109_22, rect_r109_23, rect_r109_24, rect_r109_25, rect_r109_26, rect_r109_27, rect_r109_28, rect_r109_29, rect_r109_30, rect_r109_31, rect_r109_32, rect_r109_33, rect_r109_34, rect_r109_35, rect_r109_36, rect_r109_37, rect_r109_38, rect_r109_39, rect_r109_40, rect_r109_41, rect_r109_42, rect_r109_43, rect_r109_44, rect_r109_45, rect_r109_46, rect_r109_47, rect_r109_48, rect_r109_49, rect_r109_50, rect_r109_51, rect_r109_52, rect_r109_53, rect_r109_54, rect_r109_55, rect_r109_56, rect_r109_57, rect_r109_58, rect_r109_59, rect_r109_60, rect_r109_61, rect_r109_62, rect_r109_63, rect_r109_64, rect_r109_65, rect_r109_66, rect_r109_67, rect_r109_68 };
			Steplist_R110 = new List<Rectangle> { rect_r110_1, rect_r110_2, rect_r110_3, rect_r110_4, rect_r110_5, rect_r110_6, rect_r110_7, rect_r110_8, rect_r110_9, rect_r110_10, rect_r110_11, rect_r110_12, rect_r110_13, rect_r110_14, rect_r110_15, rect_r110_16, rect_r110_17, rect_r110_18, rect_r110_19, rect_r110_20, rect_r110_21, rect_r110_22, rect_r110_23, rect_r110_24, rect_r110_25, rect_r110_26, rect_r110_27, rect_r110_28, rect_r110_29, rect_r110_30, rect_r110_31, rect_r110_32, rect_r110_33, rect_r110_34, rect_r110_35, rect_r110_36, rect_r110_37, rect_r110_38, rect_r110_39, rect_r110_40, rect_r110_41, rect_r110_42, rect_r110_43, rect_r110_44, rect_r110_45, rect_r110_46, rect_r110_47, rect_r110_48, rect_r110_49, rect_r110_50, rect_r110_51, rect_r110_52, rect_r110_53, rect_r110_54, rect_r110_55, rect_r110_56, rect_r110_57, rect_r110_58, rect_r110_59, rect_r110_60, rect_r110_61, rect_r110_62, rect_r110_63, rect_r110_64, rect_r110_65 };
			Steplist_R111 = new List<Rectangle> { rect_r111_1, rect_r111_2, rect_r111_3, rect_r111_4, rect_r111_5, rect_r111_6, rect_r111_7, rect_r111_8, rect_r111_9, rect_r111_10, rect_r111_11, rect_r111_12, rect_r111_13, rect_r111_14, rect_r111_15, rect_r111_16, rect_r111_17, rect_r111_18, rect_r111_19, rect_r111_20, rect_r111_21, rect_r111_22, rect_r111_23, rect_r111_24, rect_r111_25, rect_r111_26, rect_r111_27, rect_r111_28, rect_r111_29, rect_r111_30, rect_r111_31, rect_r111_32, rect_r111_33, rect_r111_34, rect_r111_35, rect_r111_36, rect_r111_37, rect_r111_38, rect_r111_39, rect_r111_40, rect_r111_41, rect_r111_42, rect_r111_43, rect_r111_44, rect_r111_45, rect_r111_46, rect_r111_47, rect_r111_48, rect_r111_49, rect_r111_50, rect_r111_51, rect_r111_52, rect_r111_53, rect_r111_54 };
			Steplist_R112 = new List<Rectangle> { rect_r112_1, rect_r112_2, rect_r112_3, rect_r112_4, rect_r112_5, rect_r112_6, rect_r112_7, rect_r112_8, rect_r112_9, rect_r112_10, rect_r112_11, rect_r112_12, rect_r112_13, rect_r112_14, rect_r112_15, rect_r112_16, rect_r112_17, rect_r112_18, rect_r112_19, rect_r112_20, rect_r112_21, rect_r112_22, rect_r112_23, rect_r112_24, rect_r112_25, rect_r112_26, rect_r112_27, rect_r112_28, rect_r112_29, rect_r112_30, rect_r112_31, rect_r112_32, rect_r112_33, rect_r112_34, rect_r112_35, rect_r112_36, rect_r112_37, rect_r112_38, rect_r112_39, rect_r112_40, rect_r112_41, rect_r112_42 };
			Steplist_Stairs_Left = new List<Rectangle> { rect_LeftStairs_1, rect_LeftStairs_2, rect_LeftStairs_3, rect_LeftStairs_4, rect_LeftStairs_5, rect_LeftStairs_6, rect_LeftStairs_7, rect_LeftStairs_8, rect_LeftStairs_9, rect_LeftStairs_10, rect_LeftStairs_11, rect_LeftStairs_12, rect_LeftStairs_13 };
			Steplist_Stairs_Right = new List<Rectangle> { rect_RightStairs_1, rect_RightStairs_2, rect_RightStairs_3, rect_RightStairs_4, rect_RightStairs_5, rect_RightStairs_6, rect_RightStairs_7, rect_RightStairs_8, rect_RightStairs_9, rect_RightStairs_10, rect_RightStairs_11, rect_RightStairs_12, rect_RightStairs_13 };

			ButtonList = new List<Button> { btn_r101, btn_r102, btn_r103, btn_r104, btn_r105, btn_r106, btn_r107, btn_r108, btn_r109, btn_r110, btn_r111, btn_r112 };
			#endregion
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			Global.IsClicked = false;
			if(e.Parameter != null && !e.Parameter.Equals(""))
			{
				Timer.Stop();
				var room = (Global.Room)e.Parameter;
				if (room.Equals(Global.Room.R101) || room.Equals(Global.Room.R102) || room.Equals(Global.Room.R103) ||
					room.Equals(Global.Room.R104) || room.Equals(Global.Room.R105) || room.Equals(Global.Room.R106) ||
					room.Equals(Global.Room.R107) || room.Equals(Global.Room.R108) || room.Equals(Global.Room.R109) ||
					room.Equals(Global.Room.R110) || room.Equals(Global.Room.R111) || room.Equals(Global.Room.R112)){

					await Room_Populator(room);
					ContentDialog InstructionDialog = new ContentDialog()
					{
						Title = "NOTIFICATION",
						Content = "You have reached the destination!",
						CloseButtonText = "Ok"
					};
					await InstructionDialog.ShowAsync();
				}
				else {
					if (room.Equals(Global.Room.R201) || room.Equals(Global.Room.R202) || room.Equals(Global.Room.R203) ||
					room.Equals(Global.Room.R204) || room.Equals(Global.Room.R205) || room.Equals(Global.Room.R206) ||
					room.Equals(Global.Room.R207) || room.Equals(Global.Room.R208) || room.Equals(Global.Room.R209) ||
					room.Equals(Global.Room.R301) || room.Equals(Global.Room.R302) || room.Equals(Global.Room.R303) ||
					room.Equals(Global.Room.R304) || room.Equals(Global.Room.R305) || room.Equals(Global.Room.R306) ||
					room.Equals(Global.Room.R307) || room.Equals(Global.Room.R308))
						await Room_Populator(Global.Room.Stairs_Left_2F);
					else
						await Room_Populator(Global.Room.Stairs_Right_2F);
					this.NavigationCacheMode = NavigationCacheMode.Disabled;
					await Task.Delay(TimeSpan.FromSeconds(0.5));
					this.Frame.Navigate(typeof(Map_2f), room);
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
			Global.Button_Renaming(ButtonList);
			if (Global.language == "Filipino")
			{
				MainTitle.Text = "MGA MAPA";
				Searchbtn.Label = "Hanapin";
				Mapbtn.Label = "Mapa";
				Servicesbtn.Label = "Mga Serbisyo";
				Jobsbtn.Label = "Mga Kategorya ng Trabaho";
				Eventbtn.Label = "Mga Darating na Kaganapan";
				var secondFloor_btn = (sndFlr.Content as Grid).Children[1] as TextBlock;
				secondFloor_btn.Text = "Ikalawang Palapag";
				var thirdFloor_btn = (trdFlr.Content as Grid).Children[1] as TextBlock;
				thirdFloor_btn.Text = "Ikatlong Palapag";
				lb_currentFloor.Text = "Unang Palapag";
			}
			//ContentDialog InstructionDialog = new ContentDialog()
			//{
			//	Title = "Tap the Rooms",
			//	Content = new Image
			//	{
			//		Source = new BitmapImage(new Uri("ms-appx:///Assets/tapping.gif"))
			//	},
			//	CloseButtonText = "Ok"
			//};

			//await InstructionDialog.ShowAsync();
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
			//	counter = 0;
			//}
			Global.Enable_Disable_Button(Global.Button_Property.Enable, ButtonList);
			Global.IsClicked = true;
			await Task.Delay(TimeSpan.FromSeconds(1));
			counter = 0;
		}

		private async Task Room_Populator(Global.Room room)
		{
			if (room.Equals(Global.Room.R101)) { await Step_Populator(Steplist_R101, room); }
			else if (room.Equals(Global.Room.R102)) { await Step_Populator(Steplist_R102, room); }
			else if (room.Equals(Global.Room.R103)) { await Step_Populator(Steplist_R103, room); }
			else if (room.Equals(Global.Room.R104)) { await Step_Populator(Steplist_R104, room); }
			else if (room.Equals(Global.Room.R105)) { await Step_Populator(Steplist_R105, room); }
			else if (room.Equals(Global.Room.R106)) { await Step_Populator(Steplist_R106, room); }
			else if (room.Equals(Global.Room.R107)) { await Step_Populator(Steplist_R107, room); }
			else if (room.Equals(Global.Room.R108)) { await Step_Populator(Steplist_R108, room); }
			else if (room.Equals(Global.Room.R109)) { await Step_Populator(Steplist_R109, room); }
			else if (room.Equals(Global.Room.R110)) { await Step_Populator(Steplist_R110, room); }
			else if (room.Equals(Global.Room.R111)) { await Step_Populator(Steplist_R111, room); }
			else if (room.Equals(Global.Room.R112)) { await Step_Populator(Steplist_R112, room); }
			else if (room.Equals(Global.Room.Stairs_Left_2F)) { await Step_Populator(Steplist_Stairs_Left, room); }
			else if (room.Equals(Global.Room.Stairs_Right_2F)) { await Step_Populator(Steplist_Stairs_Right, room); }
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
		private async void Room_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			string button_Name = (sender as Button).Name;
			if (button_Name != null)
			{
				Timer.Stop();
				await Room_Populator(Global.Enum_Converter(button_Name.Split('_')[1]));
			}
		}
		private async void sndFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_2f));
		}

		private async  void trdFlr_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			if (Global.IsClicked) { Global.Show_Hide_Image(Temp_ListSteps, Global.Img_Property.Collapsed); }
			this.Frame.Navigate(typeof(Map_3f));
		}
	}
}
