using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using gifts_project.ViewModel;

namespace gifts_project.View
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            LoginViewModel lvm = new LoginViewModel(this);
            this.DataContext = lvm;
            InitializeComponent();
        }
        public void navigateToMainMenu() {
            NavigationService.Navigate(new Uri("/View/MainMenu.xaml", UriKind.Relative));
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/View/SignUp.xaml", UriKind.Relative));
        }
    }
}