﻿#pragma checksum "..\..\..\frm_Tongiao.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2BECF56BBF82E519DF1DF7673F5181ECFCE6DF64B7C6EE5A8BBADADF1E558A6F"
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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
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
    /// frm_Tongiao
    /// </summary>
    public partial class frm_Tongiao : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grbthongtintongiao;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_add;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_edit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmd_delete;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdexport;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gctrl_TonGiao;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\frm_Tongiao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView View;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/frm_tongiao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\frm_Tongiao.xaml"
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
            
            #line 7 "..\..\..\frm_Tongiao.xaml"
            ((GUI.frm_Tongiao)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grbthongtintongiao = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.cmd_add = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\frm_Tongiao.xaml"
            this.cmd_add.Click += new System.Windows.RoutedEventHandler(this.cmd_add_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmd_edit = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\frm_Tongiao.xaml"
            this.cmd_edit.Click += new System.Windows.RoutedEventHandler(this.cmd_edit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmd_delete = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\frm_Tongiao.xaml"
            this.cmd_delete.Click += new System.Windows.RoutedEventHandler(this.cmd_delete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdexport = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\frm_Tongiao.xaml"
            this.cmdexport.Click += new System.Windows.RoutedEventHandler(this.cmdexport_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gctrl_TonGiao = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 8:
            this.View = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
