﻿#pragma checksum "..\..\..\Loaigv.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9950296114B09DCEB4EC4DA8C9B29A23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
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


namespace GUI {
    
    
    /// <summary>
    /// Loaigv
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Loaigv : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grbthongtinlgv;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_add;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_edit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_delete;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_export;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gctrlLoaiGV;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Loaigv.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView View;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/loaigv.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Loaigv.xaml"
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
            
            #line 7 "..\..\..\Loaigv.xaml"
            ((GUI.Loaigv)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grbthongtinlgv = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.cmd_add = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Loaigv.xaml"
            this.cmd_add.Click += new System.Windows.RoutedEventHandler(this.cmd_add_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmd_edit = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Loaigv.xaml"
            this.cmd_edit.Click += new System.Windows.RoutedEventHandler(this.cmd_edit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmd_delete = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Loaigv.xaml"
            this.cmd_delete.Click += new System.Windows.RoutedEventHandler(this.cmd_delete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmd_export = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Loaigv.xaml"
            this.cmd_export.Click += new System.Windows.RoutedEventHandler(this.cmd_export_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gctrlLoaiGV = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 8:
            this.View = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
