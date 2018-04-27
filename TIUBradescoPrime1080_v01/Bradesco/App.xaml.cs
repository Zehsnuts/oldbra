using System.Windows;

namespace Bradesco
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
	    private static MainWindow _appWindow;
		internal static MainWindow AppWindow
	    {
		    get
		    {
			    return _appWindow ?? (_appWindow = new MainWindow());
		    }
	    }

        public App()
        {
			InitializeComponent();
	        Startup += OnStart;
	        Exit += (s, e) => AppWindow.Dispose();
        }

	    private void OnStart(object sender, StartupEventArgs e)
	    {
			AppWindow.Show();
		    //new PDFViewer().Show();
	    }
    }
}
