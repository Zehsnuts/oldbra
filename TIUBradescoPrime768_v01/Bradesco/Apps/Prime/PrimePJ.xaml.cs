using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps.Prime
{
    /// <summary>
    /// Interaction logic for PrimePJ.xaml
    /// </summary>
    public partial class PrimePJ : UserControl
    {
        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;

        BradescoInfo bradescoInfo = new BradescoInfo("bradesco_tiu_versao.xml");

        public PrimePJ()
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

                    PrimePF w = new PrimePF();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;
                    tela.labelTitulo.Content = "Prime PF";

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
                    PrimeInformativoAoPublico w = new PrimeInformativoAoPublico();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Prime Informativo ao Público";

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
            var control = Controls.PrimePJLista;
            control.ScrollTo(scrollTo);
            Controls.MasterPage.SetContent(control, "Prime PJ", "Y", "");

        }

    }
}
