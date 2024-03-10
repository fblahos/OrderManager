using OrderManager.Model;
using System.Windows.Controls;

namespace OrderManager.Controls
{
    /// <summary>
    /// Interaction logic for PlatformControl.xaml
    /// </summary>
    public partial class PlatformControl : UserControl
    {
        public PlatformControl()
        {
            Platform platform = new Platform();
            DataContext = platform;
            InitializeComponent();
        }
    }
}
