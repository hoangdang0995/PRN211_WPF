﻿#pragma checksum "..\..\..\..\popup\pop_HocKy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3275CDB51677228F848F074C6B862E3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
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


namespace GUI.popup {
    
    
    /// <summary>
    /// pop_HocKy
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class pop_HocKy : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\popup\pop_HocKy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mahocky;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\popup\pop_HocKy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_tenhocky;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\popup\pop_HocKy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mota;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\popup\pop_HocKy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_DongY;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\popup\pop_HocKy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_Exit;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/popup/pop_hocky.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\popup\pop_HocKy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\..\popup\pop_HocKy.xaml"
            ((GUI.popup.pop_HocKy)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\..\popup\pop_HocKy.xaml"
            ((GUI.popup.pop_HocKy)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_mahocky = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_tenhocky = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_mota = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cmd_DongY = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\popup\pop_HocKy.xaml"
            this.cmd_DongY.Click += new System.Windows.RoutedEventHandler(this.cmdDongY_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmd_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\popup\pop_HocKy.xaml"
            this.cmd_Exit.Click += new System.Windows.RoutedEventHandler(this.cmdExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
