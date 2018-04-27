using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco.Apps.Folhetos
{
    /// <summary>
    /// Interaction logic for FolhetosExclusive.xaml
    /// </summary>
    public partial class FolhetosExclusive : UserControl
    {
        public FolhetosExclusive()
        {
            InitializeComponent();
        }

        private void btn1_TouchDown(object sender, EventArgs e)
        {
			var nav = Controls.FolhetosNavegadorExclusive;
			var index = int.Parse(((ContentControl)sender).Tag.ToString());
			nav.SetIndex(index);
			Controls.MasterPage.SetContent(nav, "Folhetos","Y","");
        }
    }
}
