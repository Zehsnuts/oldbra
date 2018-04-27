using System.Windows.Media.Animation;
using Bradesco.Apps.Prime;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Configuration;
using System;

namespace Bradesco.Apps.Folhetos
{
    /// <summary>
    /// Interaction logic for FolhetosIndice.xaml
    /// </summary>
    public partial class FolhetosIndice : UserControl
    {
	    private TouchPoint TouchStart;
	    private bool AlreadySwiped;
        public FolhetosIndice()
        {
            InitializeComponent();
            TouchDown += BasePage_TouchDown;
            TouchMove += BasePage_TouchMove;
        }

        void BasePage_TouchDown(object sender, TouchEventArgs e)
        {
			TouchStart = e.GetTouchPoint(this);
        }

	    private void SetContent(UIElement control, string title)
	    {
			Controls.MasterPage.labelTitulo.Content = title;
			Controls.MasterPage.gridPrincipal.Children.Clear();
			Controls.MasterPage.gridPrincipal.Children.Add(control);
			control.RenderTransform = new TranslateTransform {
				Y = 1400
			};
			var storyboard = FindResource("showItemsStoryboard") as Storyboard;
			if (storyboard != null) storyboard.Begin((FrameworkElement)control);
	    }

        private void ContentControl_TouchDown(object sender, EventArgs e)
        {
			SetContent(Controls.FolhetosPF, "Folhetos PF");
        }

        private void ContentControl_TouchDown_1(object sender, EventArgs e)
        {
			SetContent(Controls.FolhetosExclusive, "Folhetos Exclusive");
        }

        private void ContentControl_TouchDown_2(object sender, EventArgs e)
        {
			SetContent(Controls.FolhetosPJ, "Folhetos Empresas & Negócios");
        }

        void BasePage_TouchMove(object sender, TouchEventArgs e)
        {
            var i = e.OriginalSource as Image;

            if (i == null) return;

            var matrix = ((MatrixTransform)i.RenderTransform).Matrix;

            if (!AlreadySwiped && matrix.Determinant == 1 && TouchesOver.Count() == 1)
            {
                var tt = new TranslateTransform();

                var Touch = e.GetTouchPoint(this);
                //Swipe Left
                if (TouchStart != null && Touch.Position.X > (TouchStart.Position.X + 100))
                {
                    AlreadySwiped = true;

                    SCR w = new SCR();


                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "SCR";
                    if (tela.gridPrincipal.Children.Count > 0)
                    {
                        tela.gridPrincipal.Children.RemoveAt(0);
                    }

                    

                    tela.gridPrincipal.Children.Add(w);

                    tt.X = -300;
                    w.RenderTransform = tt;

                }
                //Swipe Right

                if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 100))
                {
                    AlreadySwiped = true;

                    string prime = ConfigurationManager.AppSettings["VersaoPrime"];

                    if (prime != "true")
                    {
                        //TarifasPF w = new TarifasPF();
                        TarifasPFVigencias w = new TarifasPFVigencias();

                        DependencyObject ucParent = this.Parent;

                        while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                        {
                            ucParent = LogicalTreeHelper.GetParent(ucParent);
                        }

                        Principal tela = (Principal)ucParent;

                        tela.labelTitulo.Content = "Tarifas PF - Vigências";

                        if (tela.gridPrincipal.Children.Count > 0)
                        {
                            tela.gridPrincipal.Children.RemoveAt(0);
                        }

                        tela.gridPrincipal.Children.Add(w);

                        tt.X = 300;
                        w.RenderTransform = tt;
                       
                    }
                    else
                    {

                        //PrimeMenu w = new PrimeMenu();
                        TarifasPFVigencias w = new TarifasPFVigencias();

                        DependencyObject ucParent = this.Parent;

                        while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                        {
                            ucParent = LogicalTreeHelper.GetParent(ucParent);
                        }

                        Principal tela = (Principal)ucParent;

                        tela.labelTitulo.Content = "Tarifas PF - Vigências";

                        if (tela.gridPrincipal.Children.Count > 0)
                        {
                            tela.gridPrincipal.Children.RemoveAt(0);
                        }



                        tela.gridPrincipal.Children.Add(w);

                        tt.X = 300;
                        w.RenderTransform = tt;

                      
                    }
                   



     
                }


            }

            e.Handled = true;

        }
    }
}
