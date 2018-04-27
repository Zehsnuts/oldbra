using System.Windows.Media.Animation;
using Bradesco.Apps.Folhetos;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bradesco.Apps.Prime
{
    /// <summary>
    /// Interaction logic for PrimeMenu.xaml
    /// </summary>
    public partial class PrimeMenu : UserControl
    {
        protected TouchPoint TouchStart;
        protected bool AlreadySwiped;
        public PrimeMenu()
        {

            InitializeComponent();
            TouchDown += BasePage_TouchDown;
            //TouchMove += BasePage_TouchMove;
        }

        void BasePage_TouchDown(object sender, TouchEventArgs e)
        {
			TouchStart = e.GetTouchPoint(this);
        }

		private void SetContent(UIElement control, string title) {
			Controls.MasterPage.labelTitulo.Content = title;
			Controls.MasterPage.gridPrincipal.Children.Clear();
			Controls.MasterPage.gridPrincipal.Children.Add(control);
			control.RenderTransform = new TranslateTransform {
				Y = 1400
			};
			var storyboard = FindResource("showItemsStoryboard") as Storyboard;
			if (storyboard != null) storyboard.Begin((FrameworkElement)control);
		}

        private void btn3_Click(object sender, RoutedEventArgs e)
		{
			SetContent(Controls.PrimeInformativoAoPublico, "Prime Informativo ao Público");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
		{
			SetContent(Controls.PrimeFolhetos, "Prime Folhetos");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
			SetContent(Controls.PrimeFundosDeInvestimento, "Prime Fundo de Investimentos");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
			SetContent(Controls.PrimeSCR, "Prime SCR");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.PrimePfVigencias, "Prime PF - Vigências");//--------------------------------------------CHECK
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
			SetContent(Controls.PrimePJ, "Prime PJ");
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

                    FolhetosIndice w = new FolhetosIndice();


                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Folhetos";
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
                    TarifasPF w = new TarifasPF();



                    DependencyObject ucParent = this.Parent;

                    while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
                    {
                        ucParent = LogicalTreeHelper.GetParent(ucParent);
                    }

                    Principal tela = (Principal)ucParent;

                    tela.labelTitulo.Content = "Tarifas PF";

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
    }
}
