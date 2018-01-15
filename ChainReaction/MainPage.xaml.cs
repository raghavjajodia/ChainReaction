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
using System.Net;
using System.Windows;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ChainReaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

     /*   private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        */
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage1));
        }
        /*
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page1), tex1.Text + ",2");    
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page1), tex1.Text + ",3");   
        }
      */  
        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private async void MessageBoxDisplay_Click(object sender, RoutedEventArgs e)
        {

            MessageDialog msgbox = new MessageDialog("Insufficient Parameters");
            await msgbox.ShowAsync();


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

           string a;

           if (((ComboBoxItem)Players.SelectedItem) != null && ((ComboBoxItem)Grid.SelectedItem) != null)
           {
               a = "" + ((ComboBoxItem)Grid.SelectedItem).Name.ToString()[1];
               if(a.CompareTo("1")==0)
               Frame.Navigate(typeof(Page1), ((ComboBoxItem)Players.SelectedItem).Content.ToString() + "," + ((ComboBoxItem)Grid.SelectedItem).Name.ToString()[1]);
               else
                   Frame.Navigate(typeof(Page4), ((ComboBoxItem)Players.SelectedItem).Content.ToString() + "," + ((ComboBoxItem)Grid.SelectedItem).Name.ToString()[1]);

           }
           else
           {
               var dialog = new MessageDialog("Insufficient parameters");
               await dialog.ShowAsync();
           }
            //catch(Exception eerrr)
            //{
              //  var dialog = new MessageDialog("Insufficient parameters");
               // await dialog.ShowAsync();
            //}

           
                    }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       

    }
}
