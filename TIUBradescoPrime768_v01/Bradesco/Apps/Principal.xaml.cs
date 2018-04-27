using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace Bradesco.Apps
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : UserControl
    {
        BradescoInfo bradescoInfo = new BradescoInfo("bradesco_tiu_versao.xml");

        public Principal()
        {
            InitializeComponent();
            TouchDown += (s, e) => App.AppWindow.ResetScreensaverTimer();
            MouseDown += (s, e) => App.AppWindow.ResetScreensaverTimer();

            string prime = ConfigurationManager.AppSettings["VersaoPrime"];
            int offsetLeft = 32;

            if (prime != "true")
            {
                btnPrime.Visibility = System.Windows.Visibility.Hidden;
                btn1.Margin =  new Thickness() { Left = 6 + offsetLeft,   Bottom = 0, Right = 0, Top = 1237 };
                btn2.Margin =  new Thickness() { Left = 75 + offsetLeft,  Bottom = 0, Right = 0, Top = 1237 };
                btn3.Margin =  new Thickness() { Left = 144 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn4.Margin =  new Thickness() { Left = 213 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn5.Margin =  new Thickness() { Left = 282 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn6.Margin =  new Thickness() { Left = 351 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn7.Margin =  new Thickness() { Left = 420 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn8.Margin =  new Thickness() { Left = 489 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn9.Margin =  new Thickness() { Left = 558 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
                btn10.Margin = new Thickness() { Left = 627 + offsetLeft, Bottom = 0, Right = 0, Top = 1237 };
            }
        }

        internal void ResetAnimation()
        {
            RenderTransform = new TranslateTransform { Y = 1400 };
            btnVoltar.RenderTransform = new TranslateTransform { X = -200 };
            btnAjuda.RenderTransform = new TranslateTransform { X = 200 };
        }

        public void SetContent(UIElement control, string title, string direction, string orientation)
        {
            labelTitulo.Content = title;
            gridPrincipal.Children.Clear();
            gridPrincipal.Children.Add(control);
            int _orientation = orientation == "R" ? 300 : -300;

            if (direction == "A")
            {
                //control.Opacity = 0;
            }
            else if (direction == "Y")
            {
                control.RenderTransform = new TranslateTransform
                {
                    Y = 1400
                };
            }
            else
            {
                control.RenderTransform = new TranslateTransform
                {
                    X = _orientation
                };

            }
            var storyboard = FindResource("showItemsStoryboard") as Storyboard;
            if (storyboard != null) storyboard.Begin((FrameworkElement)control);
        }

        public void SetContentAjuda(UIElement control)
        {
            gridAjuda.Children.Clear();
            gridAjuda.Children.Add(control);
            control.RenderTransform = new TranslateTransform
            {
                Y = 1400
            };
            var storyboard = FindResource("showItemsStoryboard") as Storyboard;
            if (storyboard != null) storyboard.Begin((FrameworkElement)control);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.InformativoAoPublico, "Informativo ao Público", "Y", "");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.CanaisDeAcesso, "Canais de Acesso", "Y", "");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.TarifasPfVigencias, "Tarifas PF - Vigências", "Y", "");//-------------------------------------CHECK
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.TarifasPjVigencias, "Tarifas PJ - Vigências", "Y", "");//-------------------------------------CHECK
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Inss, "INSS", "Y", "");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.FundosDeInvestimento, "Fundos de Investimento", "Y", "");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Scr, "SCR", "Y", "");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Procon, "PROCON", "Y", "");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.ReclamacoesOuSugestoes, "Portabilidade", "Y", "");
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.FolhetosIndice, "Folhetos", "Y", "");
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.PrimeMenu, "Prime", "Y", "");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

            var tela = (UserControl)gridPrincipal.Children[0];
            string _tela = tela.Content.ToString();

            if (_tela == "System.Windows.Controls.Canvas" || (_tela == "System.Windows.Controls.ScrollViewer" && ((ScrollViewer)tela.Content).Name == "scrollTarifas"))
            {
                _tela = tela.ToString();
            }

            this.gridPrincipal.Children.Clear();

            switch (_tela)
            {
                case "Bradesco.Apps.TarifasPFLista"://-------------------------------------CHECK--PF
                    labelTitulo.Content = "Tarifas PF - a partir de " + bradescoInfo.VigenciaTarifaPFNew;
                    this.gridPrincipal.Children.Add(Controls.TarifasPF);
                    break;
                case "Bradesco.Apps.TarifasPFLista_old"://-------------------------------------CHECK--PF
                    labelTitulo.Content = "Tarifas PF - de " + bradescoInfo.VigenciaTarifaPFOld;
                    this.gridPrincipal.Children.Add(Controls.TarifasPF_old);
                    break;
                case "Bradesco.Apps.TarifasPF"://-------------------------------------CHECK--PF
                    labelTitulo.Content = "Vigências";
                    this.gridPrincipal.Children.Add(Controls.TarifasPfVigencias);
                    break;
                case "Bradesco.Apps.TarifasPF_old"://-------------------------------------CHECK--PF
                    labelTitulo.Content = "Vigências";
                    this.gridPrincipal.Children.Add(Controls.TarifasPfVigencias);
                    break; //------------------------------------------------------------------------------------------------------
                case "Bradesco.Apps.TarifasPJLista"://-------------------------------------CHECK--PJ
                    labelTitulo.Content = "Tarifas PJ - a partir de " + bradescoInfo.VigenciaTarifaPJNew;
                    this.gridPrincipal.Children.Add(Controls.TarifasPJ);
                    break;
                case "Bradesco.Apps.TarifasPJLista_old"://-------------------------------------CHECK--PJ
                    labelTitulo.Content = "Tarifas PJ - de " + bradescoInfo.VigenciaTarifaPJOld;
                    this.gridPrincipal.Children.Add(Controls.TarifasPJ_old);
                    break;
                case "Bradesco.Apps.TarifasPJ"://-------------------------------------CHECK--PJ
                    labelTitulo.Content = "Vigências";
                    this.gridPrincipal.Children.Add(Controls.TarifasPjVigencias);
                    break;
                case "Bradesco.Apps.TarifasPJ_old"://-------------------------------------CHECK--PJ
                    labelTitulo.Content = "Vigências";
                    this.gridPrincipal.Children.Add(Controls.TarifasPjVigencias);
                    break; //------------------------------------------------------------------------------------------------------
                case "Bradesco.Apps.Estados.AC":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.AL":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.AM":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.AP":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.BA":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.CE":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.DF":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.ES":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.GO":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.MA":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.MG":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.MS":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.MT":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.PA":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.PB":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.PE":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.PI":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.PR":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.RJ":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.RN":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.RO":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.RR":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.RS":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.SC":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.SE":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.SP":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;
                case "Bradesco.Apps.Estados.TO":
                    this.gridPrincipal.Children.Add(Controls.Procon);
                    break;

                // PRIME ------------------------------------------------------

                case "Bradesco.Apps.Prime.PrimePF"://-------------------------------------CHECK--Prime
                    this.gridPrincipal.Children.Add(Controls.PrimePfVigencias);
                    labelTitulo.Content = "Vigências";
                    break;
                case "Bradesco.Apps.Prime.PrimePF_old"://-------------------------------------CHECK--Prime
                    this.gridPrincipal.Children.Add(Controls.PrimePfVigencias);
                    labelTitulo.Content = "Vigências";
                    break;
                case "Bradesco.Apps.Prime.PrimePFVigencias"://-------------------------------------CHECK--Prime
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;
                case "Bradesco.Apps.Prime.PrimePJ":
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.PrimeInformativoAoPublico":
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.Folhetos":
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.PrimeFundosDeInvestimento":
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.PrimeSCR":
                    this.gridPrincipal.Children.Add(Controls.PrimeMenu);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.PrimePfLista"://-------------------------------------CHECK--Prime
                    this.gridPrincipal.Children.Add(Controls.PrimePF);
                    labelTitulo.Content = "Prime PF - a partir de " + bradescoInfo.VigenciaTarifaPrimePFNew;
                    break;

                case "Bradesco.Apps.Prime.PrimePfLista_old"://-------------------------------------CHECK--Prime
                    this.gridPrincipal.Children.Add(Controls.PrimePF_old);
                    labelTitulo.Content = "Prime PF - de " + bradescoInfo.VigenciaTarifaPrimePFOld;
                    break;

                case "Bradesco.Apps.Prime.PrimePjLista":
                    this.gridPrincipal.Children.Add(Controls.PrimePJ);
                    labelTitulo.Content = "Prime";
                    break;

                case "Bradesco.Apps.Prime.FolhetosNavegador":
                    this.gridPrincipal.Children.Add(Controls.PrimeFolhetos);
                    labelTitulo.Content = "Prime";
                    break;

                // FOLHETOS ------------------------------------------------------

                case "Bradesco.Apps.Folhetos.FolhetosNavegador":
                    this.gridPrincipal.Children.Add(Controls.FolhetosIndice);
                    labelTitulo.Content = "Folhetos";
                    break;

                case "Bradesco.Apps.Folhetos.FolhetosEmpresasNegocios":
                    this.gridPrincipal.Children.Add(Controls.FolhetosIndice);
                    labelTitulo.Content = "Folhetos";
                    break;

                case "Bradesco.Apps.Folhetos.FolhetosPF":
                    this.gridPrincipal.Children.Add(Controls.FolhetosIndice);
                    labelTitulo.Content = "Folhetos";
                    break;

                case "Bradesco.Apps.Folhetos.FolhetosExclusive":
                    this.gridPrincipal.Children.Add(Controls.FolhetosIndice);
                    labelTitulo.Content = "Folhetos";
                    break;

                default:
                    Controls.Home.ResetAnimation();
                    App.AppWindow.ChangeContent(Controls.Home);
                    break;

            }

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var tela = (UserControl)gridPrincipal.Children[0];
            string _tela = tela.Content.ToString();

            if (_tela == "System.Windows.Controls.Canvas" || (_tela == "System.Windows.Controls.ScrollViewer" && ((ScrollViewer)tela.Content).Name == "scrollTarifas"))
            {
                _tela = tela.ToString();
            }

            if (_tela == "Bradesco.Apps.Prime.PrimeMenu")
            {
                SetContentAjuda(Controls.AjudaMenuPrincipal);
            }
            else
            {
                SetContentAjuda(Controls.AjudaMenuInterno);
            }

        }
    }
}
