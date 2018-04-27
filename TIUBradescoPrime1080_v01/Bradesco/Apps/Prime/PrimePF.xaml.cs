using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps.Prime
{
    /// <summary>
    /// Interaction logic for PrimePF.xaml
    /// </summary>
    public partial class PrimePF : UserControl
    {
        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;

        BradescoInfo bradescoInfo = new BradescoInfo("bradesco_tiu_versao.xml");

        public PrimePF()
        {
            InitializeComponent();
            this.TouchDown += new EventHandler<TouchEventArgs>(BasePage_TouchDown);
            this.TouchMove += new EventHandler<TouchEventArgs>(BasePage_TouchMove);
            LerTextoTarifas();

        }

        private void LerTextoTarifas()
        {
            txtTarifas.Text = bradescoInfo.TaxaJurosPrimePFNew;
            txtVigencia.Text = bradescoInfo.VigenciaTarifaPrimePFNew;
        }


        void BasePage_TouchDown(object sender, TouchEventArgs e)
        {
            TouchStart = e.GetTouchPoint(this);
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
                if (TouchStart != null && Touch.Position.X > (TouchStart.Position.X + 200))
                {
                    AlreadySwiped = true;

                    //PrimeSCR w = new PrimeSCR();
                    PrimePF_old w = new PrimePF_old();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;
                    tela.labelTitulo.Content = "Prime PF - de " + bradescoInfo.VigenciaTarifaPrimePFOld;

                    if (tela.gridPrincipal.Children.Count > 0)
                    {
                        tela.gridPrincipal.Children.RemoveAt(0);
                    }

                    tela.gridPrincipal.Children.Add(w);

                    tt.X = -300;
                    w.RenderTransform = tt;

                }
                //Swipe Right

                if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 200))
                {
                    AlreadySwiped = true;
                    //PrimePJ w = new PrimePJ();
                    PrimePF_old w = new PrimePF_old();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Prime PF - de " + bradescoInfo.VigenciaTarifaPrimePFOld;

                    if (tela.gridPrincipal.Children.Count > 0)
                    {
                        tela.gridPrincipal.Children.RemoveAt(0);
                    }

                    tela.gridPrincipal.Children.Add(w);

                    tt.X = 300;
                    w.RenderTransform = tt;
                }

            }

            e.Handled = true;

        }

        private void ContentControl_TouchDown(object sender, EventArgs e)
        {
            var scrollTo = int.Parse(((ContentControl)sender).Tag.ToString());
            var control = Controls.PrimePFLista;
            control.ScrollTo(scrollTo);
            Controls.MasterPage.SetContent(control, "Prime PF - a partir de " + bradescoInfo.VigenciaTarifaPrimePFNew, "Y", "");
        }
    }

}
