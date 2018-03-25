using BinanKiosk.Enums;
using BinanKiosk.Repository;
using BinanKiosk.Service_Folder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace BinanKiosk.Models
{
	public class Global
	{
		public const string BASE_ADDRESS = "http://localhost:8080/api/";
		public const string BASE_ADDRESS_DEBUG = "http://localhost:8080/api/";
		//public const string BASE_ADDRESS_DEBUG = "http://localhost:8080/api/";
		//Global variable which can be used in any forms;
		public static Boolean IsClicked = false;
		public static string language = "";
		public enum Room
		{
			R101, R102, R103, R104, R105, R106, R107, R108, R109, R110, R111, R112, Stairs_Left_2F, Stairs_Right_2F,
			R201, R202, R203, R204, R205, R206, R207, R208, R209, R210, R211, R212, R213, R214, R215, R216, R217, R218, R219, R220, R221, R222, R223, Stairs_3F,
			R301, R302, R303, R304, R305, R306, R307, R308, R309, R310, R311, R312
		}
		
		
		public enum Img_Property { Visible, Collapsed };
		public enum Button_Property { Enable, Disable };

		public static void Enable_Disable_Button(Button_Property _Property, List<Button> ButtonList)
		{
			foreach (var button in ButtonList)
			{
				switch (_Property)
				{
					case Button_Property.Enable:
						button.IsEnabled = true;
						break;
					case Button_Property.Disable:
						button.IsEnabled = false;
						break;
				}
				button.Background = new SolidColorBrush(Colors.Transparent);
			}
		}

		public static void Show_Hide_Image(List<Image> StepList, Img_Property _Property)
		{
			foreach (var step in StepList)
			{
				switch (_Property)
				{
					case Img_Property.Collapsed:
						step.Visibility = Visibility.Collapsed;
						break;
					case Img_Property.Visible:
						step.Visibility = Visibility.Visible;
						break;
				}

			}
		}

		public static BitmapImage AsBitmapImage(byte[] byteArray)
		{
			if (byteArray != null)
			{
				using (var stream = new InMemoryRandomAccessStream())
				{
					stream.WriteAsync(byteArray.AsBuffer()).GetResults();
					// I made this one synchronous on the UI thread;
					// this is not a best practice.
					var image = new BitmapImage();
					stream.Seek(0);
					image.SetSource(stream);
					return image;
				}
			}

			return null;
		}

		public static Picture GetPic(string path)
		{
			ServiceClientWrapper client = new ServiceClientWrapper();
#if DEBUG
			var Address = Global.BASE_ADDRESS_DEBUG + "Image/GetPicture";
#else
            var Address = Global.BASE_ADDRESS + "Image/GetPicture";
#endif
			var Params = new Dictionary<string, string>
			{
				{ "path", path }
			};

			var result = client.Send(new ServiceRequest { BaseAddress = Address, HttpProtocol = Protocols.HTTP_GET, RequestParameters = Params });
			var picture = JsonConvert.DeserializeObject<Picture>(result.Response);

			return picture;
		}

		public static Room Enum_Converter(string p_Room)
		{
			foreach (Room room in Enum.GetValues(typeof(Room)))
			{
				if (p_Room.ToLower().Equals(room.ToString().ToLower()))
					return room;
			}
			return 0;
		}
		public static void Button_Renaming(List<Button> ButtonList)
		{
			OfficeRepository officeRepository = new OfficeRepository();
			foreach (Button button in ButtonList)
			{
				foreach (var office in officeRepository.GetAll_Office())
				{
					if (button.Name.Split('_')[1].ToLower().Equals(office.Room_Name.ToLower()))
					{
						var temp_Content = button.Content;
						if ((temp_Content as TextBlock) != null)
						{
							(temp_Content as TextBlock).Text = office.Office_Name;
							break;
						}
						else
						{
							temp_Content = office.Office_Name;
							break;
						}
							
						
					}
				}
			}
		}

		public static async Task Show_Ripple(Point touchPosition, Image MyImage)
		{

			MyImage.Margin = new Thickness(touchPosition.X - MyImage.Width / 2, touchPosition.Y - MyImage.Height / 2, 0, 0);
			MyImage.Visibility = Visibility.Visible;
			await Task.Delay(TimeSpan.FromSeconds(0.2));
			MyImage.Visibility = Visibility.Collapsed;
		}

		public static void Goto_Idle_Page(int time, Page page)
		{
			if (time >= 10)
				page.Frame.Navigate(typeof(Idle_Page));
		}
		public static void Timer_Stopper(List<DispatcherTimer> timers)
		{
			foreach (var timer in timers)
			{
				timer.Stop();
			}
		}
		public static void Entrance_Transition(Page page,E_Transitions transitions)
		{
			TransitionCollection collection = new TransitionCollection();
			NavigationThemeTransition theme = new NavigationThemeTransition();

			switch(transitions)
			{
				case E_Transitions.Continuum:
					var continuum = new ContinuumNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = continuum;
					break;
				case E_Transitions.Drilln:
					var drilln = new DrillInNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = drilln;
					break;
				case E_Transitions.Entrance:
					var entrance = new EntranceNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = entrance;
					break;
				case E_Transitions.Slide:
					var slide = new SlideNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = slide;
					break;
				case E_Transitions.Suppress:
					var suppress = new SuppressNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = suppress;
					break;
				case E_Transitions.Common:
					var common = new CommonNavigationTransitionInfo();
					theme.DefaultNavigationTransitionInfo = common;
					break;

			}
			collection.Add(theme);
			page.Transitions = collection;
		}
		public static void GoBack(Page page)
		{
			if (page.Frame != null && page.Frame.CanGoBack)
			{
				page.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
				page.Frame.GoBack();
			}
		}

		public static void GoForward(Page page)
		{
			if (page.Frame != null && page.Frame.CanGoForward) page.Frame.GoForward();
		}
	}
}
