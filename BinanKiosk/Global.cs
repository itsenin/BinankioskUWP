using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BinanKiosk.Models
{
	public class Global
	{
		//Global variable which can be used in any forms;
		public static Boolean IsClicked = false;
		public static string language = "";
		public enum Room
		{
			R101, R102, R103, R104, R105, R106, R107, R108, R109, R110, R111, R112,
			R201, R202, R203, R204, R205, R206, R207, R208, R209, R210, R211, R212, R213, R214, R215, R216, R217, R218, R219, R220, R221, R222, R223,
			R301, R302, R303, R304, R305, R306, R307, R308, R309, R310, R311
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


	}
}
