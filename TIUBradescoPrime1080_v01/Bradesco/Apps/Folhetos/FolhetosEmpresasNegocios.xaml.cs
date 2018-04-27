using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco.Apps.Folhetos
{
    /// <summary>
    /// Interaction logic for FolhetosEmpresasNegocios.xaml
    /// </summary>
    public partial class FolhetosEmpresasNegocios : UserControl
    {
        public FolhetosEmpresasNegocios()
        {
            InitializeComponent();
        }

        private void btn1_TouchDown(object sender, EventArgs e)
        {
			var nav = Controls.FolhetosNavegadorPJ;
			var index = int.Parse(((ContentControl)sender).Tag.ToString());
			nav.SetIndex(index);
            Controls.MasterPage.SetContent(nav, "Folhetos", "Y", "");
        }
    }
}
