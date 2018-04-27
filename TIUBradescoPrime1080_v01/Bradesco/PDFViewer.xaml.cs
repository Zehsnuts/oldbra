using System.Windows;

namespace Bradesco {
	/// <summary>
	/// Interaction logic for PDFViewer.xaml
	/// </summary>
	public partial class PDFViewer : Window {
		public PDFViewer() {
			InitializeComponent();
			Loaded += (s, e) => wbFolhetos.Navigate("file://credito_e_financiamento_pj.pdf");
		}
	}
}
