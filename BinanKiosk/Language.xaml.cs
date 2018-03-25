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
using BinanKiosk.Enums;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Language : Page
    {
		int counter = 0;
		DispatcherTimer Timer;
		public Language()
        {
            this.InitializeComponent();
			
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			this.NavigationCacheMode = NavigationCacheMode.Disabled;
			Global.Entrance_Transition(this, E_Transitions.Drilln);
			Timer = new DispatcherTimer();
			Timer.Tick += Timer_Tick;
			Timer.Interval = new TimeSpan(0, 0, 1);
			Timer.Start();
		}
		private void Timer_Tick(object sender, object e)
		{
			counter += 1;
			if (counter >= 7)
			{
				Timer.Stop();
				Frame.Navigate(typeof(Idle_Page));
			}

		}
        private void FilipinoButton_Click(object sender, RoutedEventArgs e)
        {
			Timer.Stop();
			Global.language = "Filipino";
            Frame.Navigate(typeof(Search));
        }

		private async void MyGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			counter = 0;
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
		}

		private async void btEnglish_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			Frame.Navigate(typeof(Search));
		}

		private async void btFilipino_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Timer.Stop();
			await Global.Show_Ripple(e.GetPosition(MyGrid), MyImage);
			Frame.Navigate(typeof(Search));
		}
		
	}
}
