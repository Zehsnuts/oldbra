﻿#pragma checksum "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FDDD8AA933E08AA3FD6C71785C1FA089F7190192"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Bradesco;
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
    /// PrimeInformativoAoPublico
    /// </summary>
    public partial class PrimeInformativoAoPublico : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas scroll;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Bradesco;component/apps/prime/primeinformativoaopublico.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
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
            
            #line 31 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            this.canvasContent.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.OnManipulationDelta);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            this.canvasContent.ManipulationInertiaStarting += new System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs>(this.OnInertiaStarting);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            this.canvasContent.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.OnManipulationStarting);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 36 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            ((System.Windows.Controls.ContentControl)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.ContentControl_TouchDown);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            ((System.Windows.Controls.ContentControl)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ContentControl_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 37 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            ((System.Windows.Controls.ContentControl)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.ContentControl_TouchDown_1);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\..\..\Apps\Prime\PrimeInformativoAoPublico.xaml"
            ((System.Windows.Controls.ContentControl)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ContentControl_TouchDown_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
