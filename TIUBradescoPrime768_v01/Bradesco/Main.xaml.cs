using System.Windows.Media.Animation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Configuration;

namespace Bradesco
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        BradescoInfo bradescoInfo = new BradescoInfo("bradesco_tiu_versao.xml");

        public Main()
        {
            InitializeComponent();

            mediaElementBackGround.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Bradesco_InfoUteis\\Videos\\Part_Display_Bradesco_fundo.mp4");

            TouchDown += (s, e) => App.AppWindow.ResetScreensaverTimer();
            MouseDown += (s, e) => App.AppWindow.ResetScreensaverTimer();

            string prime = ConfigurationManager.AppSettings["VersaoPrime"];

            if (prime != "true")
            {
                btnPrime.Visibility = System.Windows.Visibility.Hidden;
                btnAjuda.Margin = new Thickness() { Left = 325, Top = 1006, Right = 325, Bottom = 178 };
            }

            LabelVersionApp.Content = bradescoInfo.VersionApp;
            LabelVersionContent.Content = bradescoInfo.VersionContent;

        }

        internal void ResetAnimation()
        {
            btnTarifasPF.RenderTransform = new TranslateTransform { X = -500 };
            btnTarifasPJ.RenderTransform = new TranslateTransform { X = -600 };
            btnInss.RenderTransform = new TranslateTransform { X = -700 };
            btnCanaisAcesso.RenderTransform = new TranslateTransform { X = -500 };
            btnFundosInvestimento.RenderTransform = new TranslateTransform { X = -600 };
            btnInformativoPublico.RenderTransform = new TranslateTransform { X = -700 };
            btnPortabilidade.RenderTransform = new TranslateTransform { X = -500 };
            btnProcon.RenderTransform = new TranslateTransform { X = -600 };
            btnInfoCredito.RenderTransform = new TranslateTransform { X = -700 };
            btnFolheto.RenderTransform = new TranslateTransform { X = -500 };
            btnPrime.RenderTransform = new TranslateTransform { X = -600 };
            btnAjuda.RenderTransform = new TranslateTransform { X = -700 };
        }

        private void SetContent(UIElement control, string title)
        {
            //gridPopupTarifasPF.Visibility = Visibility.Hidden;

            Controls.MasterPage.labelTitulo.Content = title;
            Controls.MasterPage.gridPrincipal.Children.Clear();
            Controls.MasterPage.gridPrincipal.Children.Add(control);
            Controls.MasterPage.ResetAnimation();

            App.AppWindow.ChangeContent(Controls.MasterPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.FundosDeInvestimento, "Fundos de Investimento");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Inss, "INSS");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.TarifasPfVigencias, "Vigências");//--------------------------------CHECK
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.TarifasPjVigencias, "Vigências");//--------------------------------CHECK
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.InformativoAoPublico, "Informativo ao Público");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.CanaisDeAcesso, "Canais de Acesso");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Scr, "SCR");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.Procon, "PROCON");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.ReclamacoesOuSugestoes, "Portabilidade");
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.PrimeMenu, "Bradesco Prime");
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            SetContent(Controls.FolhetosIndice, "Folhetos");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var control = Controls.AjudaMenuPrincipal;

            gridAjuda.Children.Clear();
            gridAjuda.Children.Add(control);

            control.RenderTransform = new TranslateTransform
            {
                Y = 1400
            };
            var storyboard = FindResource("showItemsStoryboard") as Storyboard;
            if (storyboard != null) storyboard.Begin((FrameworkElement)control);
        }

        private void mediaElementBackGround_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElementBackGround.UnloadedBehavior = MediaState.Manual;
            mediaElementBackGround.Position = new TimeSpan(0, 0, 1);
            mediaElementBackGround.Play();
        }

    }
}
