﻿#pragma checksum "..\..\..\..\popup\pop_LoaiGiangVien.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "570F7D9CB04A82E6F2B98CABCB4B9D3F"
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
    /// pop_LoaiGiangVien
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class pop_LoaiGiangVien : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_maloaigv;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_tenloaigv;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_DongY;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/popup/pop_loaigiangvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
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
            
            #line 4 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
            ((GUI.popup.pop_LoaiGiangVien)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
            ((GUI.popup.pop_LoaiGiangVien)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_maloaigv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_tenloaigv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmd_DongY = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
            this.cmd_DongY.Click += new System.Windows.RoutedEventHandler(this.cmd_DongY_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmd_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\popup\pop_LoaiGiangVien.xaml"
            this.cmd_Exit.Click += new System.Windows.RoutedEventHandler(this.cmd_Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

