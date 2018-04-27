using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps
{
    /// <summary>
    /// Interaction logic for Procon.xaml
    /// </summary>
    public partial class Procon : UserControl
    {
        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;

        public Procon()
        {
            InitializeComponent();
            this.TouchDown += new EventHandler<TouchEventArgs>(BasePage_TouchDown);
            this.TouchMove += new EventHandler<TouchEventArgs>(BasePage_TouchMove);
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
                    ReclamacoesOuSugestoes w = new ReclamacoesOuSugestoes();
                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Portabilidade de Operações de Crédito";

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
                    tt.X = 300;
                    w.RenderTransform = tt;
                }
            }

            e.Handled = true;

        }

        private void ContentControl_TouchDown(object sender, EventArgs e)
        {
            ContentControl estado = (ContentControl)sender;

            switch (estado.Tag.ToString())
            {
                case "AL":
                    Controls.MasterPage.SetContent(Controls.StateAL, "PROCON", "Y", "");
                    break;

                case "AM":
                    Controls.MasterPage.SetContent(Controls.StateAM, "PROCON", "Y", "");
                    break;

                case "CE":
                    Controls.MasterPage.SetContent(Controls.StateCE, "PROCON", "Y", "");
                    break;

                case "ES":
                    Controls.MasterPage.SetContent(Controls.StateES, "PROCON", "Y", "");
                    break;

                case "GO":
                    Controls.MasterPage.SetContent(Controls.StateGO, "PROCON", "Y", "");
                    break;

                case "MA":
                    Controls.MasterPage.SetContent(Controls.StateMA, "PROCON", "Y", "");
                    break;

                case "MT":
                    Controls.MasterPage.SetContent(Controls.StateMT, "PROCON", "Y", "");
                    break;

                case "PA":
                    Controls.MasterPage.SetContent(Controls.StatePA, "PROCON", "Y", "");
                    break;

                case "PE":
                    Controls.MasterPage.SetContent(Controls.StatePE, "PROCON", "Y", "");
                    break;

                case "PI":
                    Controls.MasterPage.SetContent(Controls.StatePI, "PROCON", "Y", "");
                    break;

                case "RN":
                    Controls.MasterPage.SetContent(Controls.StateRN, "PROCON", "Y", "");
                    break;

                case "RR":
                    Controls.MasterPage.SetContent(Controls.StateRR, "PROCON", "Y", "");
                    break;

                case "TO":
                    Controls.MasterPage.SetContent(Controls.StateTO, "PROCON", "Y", "");
                    break;

                case "BA":
                    Controls.MasterPage.SetContent(Controls.StateBA, "PROCON", "Y", "");
                    break;

                case "DF":
                    Controls.MasterPage.SetContent(Controls.StateDF, "PROCON", "Y", "");
                    break;

                case "MG":
                    Controls.MasterPage.SetContent(Controls.StateMG, "PROCON", "Y", "");
                    break;
                              
                case "MS":
                    Controls.MasterPage.SetContent(Controls.StateMS, "PROCON", "Y", "");
                    break;

                case "PR":
                    Controls.MasterPage.SetContent(Controls.StatePR, "PROCON", "Y", "");
                    break;

                case "RJ":
                    Controls.MasterPage.SetContent(Controls.StateRJ, "PROCON", "Y", "");
                    break;

                case "RS":
                    Controls.MasterPage.SetContent(Controls.StateRS, "PROCON", "Y", "");
                    break;

                case "SC":
                    Controls.MasterPage.SetContent(Controls.StateSC, "PROCON", "Y", "");
                    break;

                case "SP":
                    Controls.MasterPage.SetContent(Controls.StateSP, "PROCON", "Y", "");
                    break;

            }
        }

    }
}
