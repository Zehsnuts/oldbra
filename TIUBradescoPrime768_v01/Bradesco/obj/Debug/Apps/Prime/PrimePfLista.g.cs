﻿#pragma checksum "..\..\..\..\Apps\Prime\PrimePfLista.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "510B54DEE3194837C417D7A7CE9567B0DF92B27A"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
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
    /// PrimePfLista
    /// </summary>
    public partial class PrimePfLista : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Bradesco.Apps.Prime.PrimePfLista PrimeTarifaPFLista;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollTarifas;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid scroll;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageLista;
        
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
            System.Uri resourceLocater = new System.Uri("/Bradesco;component/apps/prime/primepflista.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
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
            this.PrimeTarifaPFLista = ((Bradesco.Apps.Prime.PrimePfLista)(target));
            return;
            case 2:
            this.scrollTarifas = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 3:
            this.scroll = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.ImageLista = ((System.Windows.Controls.Image)(target));
            
            #line 21 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
            this.ImageLista.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.OnManipulationDelta);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
            this.ImageLista.ManipulationInertiaStarting += new System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs>(this.OnInertiaStarting);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\Apps\Prime\PrimePfLista.xaml"
            this.ImageLista.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.OnManipulationStarting);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

