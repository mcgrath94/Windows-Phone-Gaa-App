using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace GaaQuiz
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SelectCategory.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Configure message box 
            string message = "How To Play";
            string caption = "Click on Start Quiz in the Menu, then choose which quiz you want to do and your quiz will begin. You will be given 15 questions at random, simply choose the answer you think is correct and your score will be displayed on screen when you finish. Enjoy the quiz!";
            MessageBoxButton buttons = MessageBoxButton.OK;
            // Show message box
            MessageBoxResult result = MessageBox.Show(caption, message, buttons);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // Configure message box 
            string message = "About";
            string caption = "The GAA Football quiz is a fun quiz with general knowledge questions about the GAA. Disclaimer: This app is an unofficial GAA App and does not own the Logo or any other copyrighted content included in the app.                                                                                                                                                Version 1.2    PrestigeWorldwideApps@live.com                                                            Prestige Worldwide-wide";
            MessageBoxButton buttons = MessageBoxButton.OK;
            // Show message box
            MessageBoxResult result = MessageBox.Show(caption, message, buttons);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            new Microsoft.Xna.Framework.Game().Exit();
        }
    }
}