using System.Windows;

namespace Bradesco {
	/// <summary>
	/// Interaction logic for PDFViewer.xaml
	/// </summary>
	public partial class PDFViewer : Window {
		public PDFViewer() {
			InitializeComponent();
			Loaded += (s, e) => wbFolhetos.Navigate("file://empresario_area_saude.pdf");
		}
	}
}
