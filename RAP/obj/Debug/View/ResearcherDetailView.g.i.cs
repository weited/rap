﻿#pragma checksum "..\..\..\View\ResearcherDetailView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B4BCC33C5BF70DC4F11F722E0759B7A98A9C287FF654D42E215196E01029E51C"
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
    /// ResearcherDetailView
    /// </summary>
    public partial class ResearcherDetailView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\View\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ResearcherDetails;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Publication_Count;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\View\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Show_Studentname;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\View\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lvUsers;
        
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
            System.Uri resourceLocater = new System.Uri("/RAP;component/view/researcherdetailview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ResearcherDetailView.xaml"
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
            this.ResearcherDetails = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.Publication_Count = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\View\ResearcherDetailView.xaml"
            this.Publication_Count.Click += new System.Windows.RoutedEventHandler(this.Publication_Count_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Show_Studentname = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\View\ResearcherDetailView.xaml"
            this.Show_Studentname.Click += new System.Windows.RoutedEventHandler(this.Show_Studentname_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvUsers = ((System.Windows.Controls.ListBox)(target));
            
            #line 155 "..\..\..\View\ResearcherDetailView.xaml"
            this.lvUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.showPublicationDetail);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

