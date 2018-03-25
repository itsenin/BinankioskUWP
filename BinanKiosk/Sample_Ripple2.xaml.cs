using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Sample_Ripple2 : Page
    {
		int counter = 0;
		DispatcherTimer Timer = new DispatcherTimer();
		public Sample_Ripple2()
        {
            this.InitializeComponent();
			// For the timer
			//MyTextBlock.Text = counter.ToString();
			//Timer.Tick += Timer_Tick;
			//Timer.Interval = new TimeSpan(0, 0, 1);
			//Timer.Start();
		}
		private void Timer_Tick(object sender, object e)
		{
			//counter += 1;
			//if (counter >= 10)
			//{
			//	Timer.Stop();
			//	this.Frame.Navigate(typeof(Idle_Page));
			//}
				
		}

		private async void MyBorder_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Point touchPosition = e.GetPosition(MyGrid);
			await Global.Show_Ripple(e.GetPosition(MyGrid),MyImage);
		}

		private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			Point touchPosition = e.GetPosition(MyGrid);
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			//MyTextBlock.Text = counter.ToString();
		}

		private async void MyCanvas_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Point touchPosition = e.GetPosition(MyCanvas);
			await Global.Show_Ripple(e.GetPosition(MyCanvas), MyImage);
		}

		private void MyGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			counter = 0;
			//MyTextBlock.Text = counter.ToString();
		}
	}
}
