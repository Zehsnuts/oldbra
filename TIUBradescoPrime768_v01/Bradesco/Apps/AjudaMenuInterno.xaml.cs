using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco.Apps
{
    /// <summary>
    /// Interaction logic for AjudaMenuInterno.xaml
    /// </summary>
    public partial class AjudaMenuInterno : UserControl
    {
        public AjudaMenuInterno()
        {
            InitializeComponent();
        }
        private void Image_TouchDown(object sender, EventArgs e)
        {
			Controls.MasterPage.gridAjuda.Children.Clear();
			Controls.Home.gridAjuda.Children.Clear();
        }
    }
}
