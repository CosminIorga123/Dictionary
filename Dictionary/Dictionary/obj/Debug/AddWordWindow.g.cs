﻿#pragma checksum "..\..\AddWordWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "02BC13F8A11F2E4CACDFA554189D275306E213A57E4201BA828B1E0DE0F94EE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dictionary;
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


namespace Dictionary {
    
    
    /// <summary>
    /// AddWordWindow
    /// </summary>
    public partial class AddWordWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Dictionary;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NewWordLabel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WordName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WordDescription;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewCategory;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WordCategory;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ImageBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AddLbl;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddWordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ImgSource;
        
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
            System.Uri resourceLocater = new System.Uri("/Dictionary;component/addwordwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddWordWindow.xaml"
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
            this.Dictionary = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.NewWordLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.WordName = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\AddWordWindow.xaml"
            this.WordName.MouseEnter += new System.Windows.Input.MouseEventHandler(this.WordName_MouseEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\AddWordWindow.xaml"
            this.WordName.MouseLeave += new System.Windows.Input.MouseEventHandler(this.WordName_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WordDescription = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\AddWordWindow.xaml"
            this.WordDescription.MouseEnter += new System.Windows.Input.MouseEventHandler(this.WordDescription_MouseEnter);
            
            #line default
            #line hidden
            
            #line 28 "..\..\AddWordWindow.xaml"
            this.WordDescription.MouseLeave += new System.Windows.Input.MouseEventHandler(this.WordDescription_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NewCategory = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\AddWordWindow.xaml"
            this.NewCategory.MouseEnter += new System.Windows.Input.MouseEventHandler(this.NewCategory_MouseEnter);
            
            #line default
            #line hidden
            
            #line 29 "..\..\AddWordWindow.xaml"
            this.NewCategory.MouseLeave += new System.Windows.Input.MouseEventHandler(this.NewCategory_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WordCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\AddWordWindow.xaml"
            this.WordCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WordCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AddWordWindow.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\AddWordWindow.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            
            #line 33 "..\..\AddWordWindow.xaml"
            this.AddBtn.MouseMove += new System.Windows.Input.MouseEventHandler(this.AddBtn_MouseMove);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AddWordWindow.xaml"
            this.ImageBtn.Click += new System.Windows.RoutedEventHandler(this.ImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AddLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ImgSource = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

