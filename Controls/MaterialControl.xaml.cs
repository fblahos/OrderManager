using OrderManager.Model;
using System.Windows.Controls;

namespace OrderManager.Controls
{
    /// <summary>
    /// Interaction logic for MaterialControl.xaml
    /// </summary>
    public partial class MaterialControl : UserControl
    {
        public MaterialControl()
        {
            MaterialSurface material = new MaterialSurface();
            DataContext = material;
            InitializeComponent();
        }
    }
}
