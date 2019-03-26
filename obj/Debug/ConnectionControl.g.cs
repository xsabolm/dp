﻿#pragma checksum "..\..\ConnectionControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8EE1BB376150EEB283471E72BC135A267BDA9931"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DP_WpfApp;
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


namespace connection {
    
    
    /// <summary>
    /// ConnectionControl
    /// </summary>
    public partial class ConnectionControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl connection;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConnectToDatabase;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxMeranie;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textView;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpenFile;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxOpenFile;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ConnectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnACKOpenFile;
        
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
            System.Uri resourceLocater = new System.Uri("/DP_WpfApp;component/connectioncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectionControl.xaml"
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
            this.connection = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.btnConnectToDatabase = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ConnectionControl.xaml"
            this.btnConnectToDatabase.Click += new System.Windows.RoutedEventHandler(this.btnConnectToDataBase_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxMeranie = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\ConnectionControl.xaml"
            this.comboBoxMeranie.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxMeranie_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textView = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnOpenFile = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ConnectionControl.xaml"
            this.btnOpenFile.Click += new System.Windows.RoutedEventHandler(this.btnOpenFile_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtBoxOpenFile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnACKOpenFile = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ConnectionControl.xaml"
            this.btnACKOpenFile.Click += new System.Windows.RoutedEventHandler(this.btnACKOpenFile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

