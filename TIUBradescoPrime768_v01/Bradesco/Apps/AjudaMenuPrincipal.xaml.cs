using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco.Apps
{
    /// <summary>
    /// Interaction logic for AjudaMenuPrincipal.xaml
    /// </summary>
    public partial class AjudaMenuPrincipal : UserControl
    {
        public AjudaMenuPrincipal()
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
