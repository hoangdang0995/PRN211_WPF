﻿#pragma checksum "..\..\..\..\popup\pop_NhapDiem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "829C4C9E8CCFC7B560C8430D19FF09B9"
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
    /// pop_NhapDiem
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class pop_NhapDiem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\popup\pop_NhapDiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbo_TenSinhVien;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\popup\pop_NhapDiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbo_TenLop;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\popup\pop_NhapDiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbo_TenMonHoc;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\popup\pop_NhapDiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_diem;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\popup\pop_NhapDiem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_DongY;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\popup\pop_NhapDiem.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/popup/pop_nhapdiem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\popup\pop_NhapDiem.xaml"
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
            
            #line 4 "..\..\..\..\popup\pop_NhapDiem.xaml"
            ((GUI.popup.pop_NhapDiem)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbo_TenSinhVien = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cbo_TenLop = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbo_TenMonHoc = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txt_diem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmd_DongY = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\popup\pop_NhapDiem.xaml"
            this.cmd_DongY.Click += new System.Windows.RoutedEventHandler(this.cmdDongY_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmd_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\popup\pop_NhapDiem.xaml"
            this.cmd_Exit.Click += new System.Windows.RoutedEventHandler(this.cmdExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

