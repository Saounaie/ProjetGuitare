﻿#pragma checksum "..\..\AddBoisWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C9B19882082CF2EB28A01D8BC69AF11A96B765525141A891841BEFBC39182D0A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Fabrication_IHM;
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


namespace Fabrication_IHM {
    
    
    /// <summary>
    /// AddBoisWindow
    /// </summary>
    public partial class AddBoisWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nomBoisTBX;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox poidsBoisTBX;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox régionBoisTBX;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stockBoisTBX;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelAddBoisBTN;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddBoisWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBoisBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/Fabrication_IHM;component/addboiswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddBoisWindow.xaml"
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
            this.nomBoisTBX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.poidsBoisTBX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.régionBoisTBX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.stockBoisTBX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cancelAddBoisBTN = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AddBoisWindow.xaml"
            this.cancelAddBoisBTN.Click += new System.Windows.RoutedEventHandler(this.cancelAddBoisBTN_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addBoisBTN = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AddBoisWindow.xaml"
            this.addBoisBTN.Click += new System.Windows.RoutedEventHandler(this.addBoisBTN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

