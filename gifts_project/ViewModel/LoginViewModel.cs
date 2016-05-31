using gifts_project.Helper;
using gifts_project.Model;
using gifts_project.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace gifts_project.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        LoginPage lp;

        public LoginViewModel(LoginPage lp)
        {
            this.lp = lp;
            Login = new RelayCommand(() => login());
            
        }
        public static string Username;
        public static string Password;

        private ICommand _Login;
        public ICommand Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }

        async void login()
        {
            string username = lp.username.Text;
            string password = lp.password.Password;

            if (!Regex.IsMatch(username.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))

            {

                MessageBox.Show("Invalid UserName");

            }
            else if (password.Length < 6)

            {

                MessageBox.Show("Too short password");

            }
            else
            {
                string content = await AccessTheWebAsync();
                RootObject jsonResponse = JsonConvert.DeserializeObject<RootObject>(content);
                bool exist = false;
                foreach (var user in jsonResponse.users)
                {
                    if (user.username.Equals(username) && user.password.Equals(password))
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    //navigate to the next page
                    MainMenuViewModel mmvm = new MainMenuViewModel();
                    MainMenu mm = new MainMenu();
                    mm.DataContext = mmvm;
                    Type mainMenuType = mm.GetType();
                    


                    lp.navigateToMainMenu();
                    
                }
                else
                {
                    MessageBox.Show("No such user");
                }

            }
        }

            async Task< string > AccessTheWebAsync()
                {
                HttpClient client = new HttpClient();
                Task<string> getStringTask = client.GetStringAsync("http://169.254.80.80:8888/data.json");
                string urlContents = await getStringTask;
                return urlContents;
            }


        #region  NotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
