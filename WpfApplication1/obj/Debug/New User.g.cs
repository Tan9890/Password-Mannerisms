﻿#pragma checksum "..\..\New User.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EB0D3615B3FF09D5392CBF79E053306E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApplication1;


namespace WpfApplication1 {
    
    
    /// <summary>
    /// New_User
    /// </summary>
    public partial class New_User : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernameinput;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Attempt_no;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_New_User;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ret_to_Login;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Username;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Password;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\New User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label count;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/new%20user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\New User.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\New User.xaml"
            ((WpfApplication1.New_User)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.usernameinput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 11 "..\..\New User.xaml"
            this.passwordBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.passwordBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Attempt_no = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\New User.xaml"
            this.Attempt_no.Click += new System.Windows.RoutedEventHandler(this.Attempt_no_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Add_New_User = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\New User.xaml"
            this.Add_New_User.Click += new System.Windows.RoutedEventHandler(this.Add_New_User_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Ret_to_Login = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\New User.xaml"
            this.Ret_to_Login.Click += new System.Windows.RoutedEventHandler(this.Ret_to_Login_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Username = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Password = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.count = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

