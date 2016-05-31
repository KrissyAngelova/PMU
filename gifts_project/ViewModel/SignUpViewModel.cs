using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using gifts_project.View;
using System.Text.RegularExpressions;
using gifts_project.Helper;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using gifts_project.Model;
using Newtonsoft.Json;

namespace gifts_project.ViewModel
{
    class SignUpViewModel : INotifyPropertyChanged {

        SignUp suView;


        public SignUpViewModel(SignUp suView)
        {
            this.suView = suView;
            Submit = new RelayCommand(() => submitInfo());
        }
        private ICommand _Submit;
        public ICommand Submit
        {
            get
            {
                return _Submit;
            }
            set
            {
                _Submit = value;
            }
        }

        async void submitInfo()
        {
            //UserName Validation   

            if (!Regex.IsMatch(suView.TxtUserName.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))

            {

                MessageBox.Show("Invalid UserName");

            }



            //Password length Validation   

            else if (suView.TxtPwd.Password.Length < 6)

            {

                MessageBox.Show("Password length should be minimum of 6 characters!");

            }


            //Gender Selection Empty Validation   

            else if (suView.GenFeMale.IsChecked == false && suView.GenMale.IsChecked == false)

            {

                MessageBox.Show("Please select gender!");

            }



            //Phone Number Length Validation   

            else if (suView.TxtPhNo.Text.Length != 10)

            {

                MessageBox.Show("Invalid PhonNo");

            }



            //EmailID validation   

            else if (!Regex.IsMatch(suView.TxtEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))

            {

                MessageBox.Show("Invalid EmailId");

            }

            //After validation success ,store user detials in isolated storage   

            else if (suView.TxtUserName.Text != "" && suView.TxtPwd.Password != "" && suView.TxtEmail.Text != "" && (suView.GenFeMale.IsChecked == true || suView.GenMale.IsChecked == true) && suView.TxtPhNo.Text != "")
            {
                string content = await AccessTheWebAsync();
                RootObject jsonResponse = JsonConvert.DeserializeObject< RootObject>(content);
                bool isFree = true;
                foreach(var user in jsonResponse.users)
                {
                    if (user.username.Equals(suView.TxtUserName.Text))
                    {
                        isFree = false;
                        break;
                    }
                }
                if (!isFree)
                {
                    MessageBox.Show("Username already exists!" );
                }
                else
                {
                    User u = new User();
                    u.username = suView.TxtUserName.Text;
                    u.password = suView.TxtPwd.Password;
                    u.email = suView.TxtEmail.Text;
                    if(suView.GenFeMale.IsChecked == true)
                    {
                        u.isMale = "false";
                    }
                    else
                    {
                        u.isMale = "true";
                    }
                    u.phoneNum = suView.TxtPhNo.Text;
                    u.events = null;
                    jsonResponse.users.Add(u);
;                   var jsonConverted = JsonConvert.SerializeObject(jsonResponse, Formatting.Indented);

                    //butame go v jsona
                    //hell yeah
                }
            }

        }


        async Task<string> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask =  client.GetStringAsync("http://169.254.80.80:8888/data.json");
            string urlContents = await getStringTask;
            return urlContents;
        }

        async Task<string> sendJson(string obj)
        {
            Uri uri = new Uri("http://169.254.80.80:8888");
            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("obj",obj)

            });

            var response = await client.PostAsync(uri, content);

            return response.ToString();
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
