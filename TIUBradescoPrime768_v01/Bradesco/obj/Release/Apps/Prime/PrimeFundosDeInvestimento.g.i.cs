﻿#pragma checksum "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1E0D46EFE19A333CD18BE9699B063769A598F373"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Forms.Integration;
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


namespace Bradesco.Apps.Prime {
    
    
    /// <summary>
    /// PrimeFundosDeInvestimento
    /// </summary>
    public partial class PrimeFundosDeInvestimento : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas scroll;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvasContent;
        
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
            System.Uri resourceLocater = new System.Uri("/Bradesco;component/apps/prime/primefundosdeinvestimento.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
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
            this.scroll = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.canvasContent = ((System.Windows.Controls.Canvas)(target));
            
            #line 18 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
            this.canvasContent.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.OnManipulationDelta);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
            this.canvasContent.ManipulationInertiaStarting += new System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs>(this.OnInertiaStarting);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
            this.canvasContent.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.OnManipulationStarting);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 23 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
            ((System.Windows.Controls.ContentControl)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.ContentControl_TouchDown);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\Apps\Prime\PrimeFundosDeInvestimento.xaml"
            ((System.Windows.Controls.ContentControl)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ContentControl_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
