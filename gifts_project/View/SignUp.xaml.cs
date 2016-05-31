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
    public partial class SignUp : PhoneApplicationPage
    {
        public SignUp()
        {
            SignUpViewModel suvm = new SignUpViewModel(this);
            this.DataContext = suvm;
            InitializeComponent();
        }
    }
}