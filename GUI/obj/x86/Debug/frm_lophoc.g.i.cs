#pragma checksum "..\..\..\frm_lophoc.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "32F32BBC8608B932AE7AC17F7D9ED6C5662E219C775762ED93D4B19801C92A4D"
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
    /// frm_lophoc
    /// </summary>
    public partial class frm_lophoc : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grbthongtin;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdadd;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdedit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmddelete;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdexport;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\frm_lophoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gctrl_lophoc;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\frm_lophoc.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/frm_lophoc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\frm_lophoc.xaml"
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
            
            #line 7 "..\..\..\frm_lophoc.xaml"
            ((GUI.frm_lophoc)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grbthongtin = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.cmdadd = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\frm_lophoc.xaml"
            this.cmdadd.Click += new System.Windows.RoutedEventHandler(this.cmdadd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdedit = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\frm_lophoc.xaml"
            this.cmdedit.Click += new System.Windows.RoutedEventHandler(this.cmdedit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmddelete = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\frm_lophoc.xaml"
            this.cmddelete.Click += new System.Windows.RoutedEventHandler(this.cmddelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdexport = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\frm_lophoc.xaml"
            this.cmdexport.Click += new System.Windows.RoutedEventHandler(this.cmdexport_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gctrl_lophoc = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 8:
            this.View = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

