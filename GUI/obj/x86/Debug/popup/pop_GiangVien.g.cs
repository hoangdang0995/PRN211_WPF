﻿#pragma checksum "..\..\..\..\popup\pop_GiangVien.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C4BBC4418C7AFB14F7B64D90BF835E3F8E4552FB8C7A5953375D06CCAB7308DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
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
    /// pop_GiangVien
    /// </summary>
    public partial class pop_GiangVien : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_magiangvien;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_tengiangvien;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_gtNam;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_gtNu;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_diachi;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_sodienthoai;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_hocvihocham;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_loaigv;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_DongY;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\popup\pop_GiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_Exit;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/popup/pop_giangvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\popup\pop_GiangVien.xaml"
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
            
            #line 4 "..\..\..\..\popup\pop_GiangVien.xaml"
            ((GUI.popup.pop_GiangVien)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\..\popup\pop_GiangVien.xaml"
            ((GUI.popup.pop_GiangVien)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_magiangvien = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_tengiangvien = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rdb_gtNam = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rdb_gtNu = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.txt_diachi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_sodienthoai = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\..\popup\pop_GiangVien.xaml"
            this.txt_sodienthoai.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_sodienthoai_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cbx_hocvihocham = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cbx_loaigv = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.txt_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.cmd_DongY = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\popup\pop_GiangVien.xaml"
            this.cmd_DongY.Click += new System.Windows.RoutedEventHandler(this.cmd_DongY_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.cmd_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\popup\pop_GiangVien.xaml"
            this.cmd_Exit.Click += new System.Windows.RoutedEventHandler(this.cmd_Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

