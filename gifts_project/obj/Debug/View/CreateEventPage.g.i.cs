﻿#pragma checksum "C:\Users\Кристина\documents\visual studio 2015\Projects\gifts_project\gifts_project\View\CreateEventPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7B8CBCFD556512AEAFAC8EC3E9489D37"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace gifts_project.View {
    
    
    public partial class CreateEventPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox eventName;
        
        internal System.Windows.Controls.TextBox description;
        
        internal System.Windows.Controls.Button addEvent;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/gifts_project;component/View/CreateEventPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.eventName = ((System.Windows.Controls.TextBox)(this.FindName("eventName")));
            this.description = ((System.Windows.Controls.TextBox)(this.FindName("description")));
            this.addEvent = ((System.Windows.Controls.Button)(this.FindName("addEvent")));
        }
    }
}
