using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco.Apps.Folhetos
{
    /// <summary>
    /// Interaction logic for FolhetosPF.xaml
    /// </summary>
    public partial class FolhetosPF : UserControl
    {
        public FolhetosPF()
        {
            InitializeComponent();
        }

        private void btn_TouchDown(object sender, EventArgs e)
        {
	        var nav = Controls.FolhetosNavegadorPF;
            var index = int.Parse(((ContentControl)sender).Tag.ToString());
	        nav.SetIndex(index);
            Controls.MasterPage.SetContent(nav, "Folhetos", "Y", "");
        }
    }
}
