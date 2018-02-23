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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BinanKiosk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Language : Page
    {
        public Language()
        {
            this.InitializeComponent();
        }

        private void EnglishButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Home));
        }
        private void FilipinoButton_Click(object sender, RoutedEventArgs e)
        {
            Global.language = "Filipino";
            Frame.Navigate(typeof(Home));
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    Storyboard1.Begin();
        //}
    }
}
