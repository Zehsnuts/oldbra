using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps.Prime
{
    /// <summary>
    /// Interaction logic for Folhetos.xaml
    /// </summary>
    public partial class Folhetos : UserControl
    {


        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;
        private readonly Stopwatch _doubleTapStopwatch = new Stopwatch();

        public Folhetos()
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

                    //PrimeInformativoAoPublico w = new PrimeInformativoAoPublico();
                    PrimeSCR w = new PrimeSCR();

                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }


                    Principal tela = (Principal)ucParent;
                    tela.labelTitulo.Content = "Prime SCR";

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
                    PrimeFundosDeInvestimento w = new PrimeFundosDeInvestimento();



                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Prime Fundos de Investimento";

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


        private void btn_TouchDown(object sender, EventArgs e)
        {
            try
            {
                var index = int.Parse(((ContentControl)sender).Tag.ToString());

                FolhetosNavegador w = new FolhetosNavegador(index);

                DependencyObject ucParent = this.Parent;

                while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                {
                    ucParent = LogicalTreeHelper.GetParent(ucParent);
                }

                Principal tela = (Principal)ucParent;

                tela.labelTitulo.Content = "Prime Folhetos";//Canais de Serviços de Conveniência

                if (tela.gridPrincipal.Children.Count > 0)
                {
                    tela.gridPrincipal.Children.RemoveAt(0);
                }

                tela.gridPrincipal.Children.Add(w);
            }
            catch
            {
               
            }
   

        }

       
    }
}
