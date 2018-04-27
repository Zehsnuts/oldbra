using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps
{
    /// <summary>
    /// Interaction logic for TarifasPJVigencias.xaml
    /// </summary>
    public partial class TarifasPJVigencias : UserControl
    {
        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;
        private readonly Stopwatch _doubleTapStopwatch = new Stopwatch();
        private Point _lastTapLocation;

        BradescoInfo bradescoInfo = new BradescoInfo("bradesco_tiu_versao.xml");

        public TarifasPJVigencias()
        {
            InitializeComponent();
            this.TouchDown += new EventHandler<TouchEventArgs>(BasePage_TouchDown);
            this.TouchMove += new EventHandler<TouchEventArgs>(BasePage_TouchMove);

            this.vigPJNewText.Text = bradescoInfo.VigenciaTarifaPJNewVerbose;
            this.vigPJOldText.Text = bradescoInfo.VigenciaTarifaPJOldVerbose;
        }

        private bool IsDoubleTap(TouchEventArgs e)
        {
            Point currentTapPosition = e.GetTouchPoint(this).Position;
            bool tapsAreCloseInDistance = Point.Subtract(currentTapPosition, _lastTapLocation).Length < 30;
            _lastTapLocation = currentTapPosition;

            TimeSpan elapsed = _doubleTapStopwatch.Elapsed;
            _doubleTapStopwatch.Restart();
            bool tapsAreCloseInTime = (elapsed != TimeSpan.Zero && elapsed < TimeSpan.FromSeconds(0.7));

            return tapsAreCloseInDistance && tapsAreCloseInTime;
        }

        void BasePage_TouchDown(object sender, TouchEventArgs e)
        {

            if (IsDoubleTap(e))
            {
                Mouse_DoubleTouch(sender, e);
            }
            else
            {
                TouchStart = e.GetTouchPoint(this);
            }

        }

        void Mouse_DoubleTouch(object sender, TouchEventArgs e)
        {
            var i = e.OriginalSource as Image;

            if (i == null) return;

            var matrix = ((MatrixTransform)i.RenderTransform).Matrix;

            matrix.M11 = 1;
            matrix.M22 = 1;
            matrix.OffsetX = 0;
            matrix.OffsetY = 0;
            i.RenderTransform = new MatrixTransform(matrix);
            e.Handled = true;

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

                    tt.X = -300;
                    w.RenderTransform = tt;

                }
                //Swipe Right

                if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 200))
                {
                    AlreadySwiped = true;
                    //INSS w = new INSS();
                    INSS w = new INSS();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "INSS";

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

        private void OpenTarifasPJ(object sender, EventArgs e)
        {
            Controls.MasterPage.SetContent(Controls.TarifasPJ, "Tarifas PJ - a partir de " + bradescoInfo.VigenciaTarifaPJNew, "Y", "");
        }

        private void OpenTarifasPJ_old(object sender, EventArgs e)
        {
            Controls.MasterPage.SetContent(Controls.TarifasPJ_old, "Tarifas PJ - de " + bradescoInfo.VigenciaTarifaPJOld, "Y", "");
        }

    }
}