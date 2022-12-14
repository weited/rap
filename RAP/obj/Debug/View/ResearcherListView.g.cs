#pragma checksum "..\..\..\View\ResearcherListView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CCED857F3419DCD4A489C5797144183B5DB4F6B57D5D54167A3088DCB7619A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RAP.View;
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


namespace RAP.View {
    
    
    /// <summary>
    /// ResearcherListView
    /// </summary>
    public partial class ResearcherListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ResearcherNameList;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox emp_Level;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ResearchersName;
        
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
            System.Uri resourceLocater = new System.Uri("/RAP;component/view/researcherlistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ResearcherListView.xaml"
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
            this.ResearcherNameList = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.FilterName = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\View\ResearcherListView.xaml"
            this.FilterName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterByName);
            
            #line default
            #line hidden
            return;
            case 3:
            this.emp_Level = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\View\ResearcherListView.xaml"
            this.emp_Level.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.setEmpLevel);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ResearchersName = ((System.Windows.Controls.ListBox)(target));
            
            #line 51 "..\..\..\View\ResearcherListView.xaml"
            this.ResearchersName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 52 "..\..\..\View\ResearcherListView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Generate_Report_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

