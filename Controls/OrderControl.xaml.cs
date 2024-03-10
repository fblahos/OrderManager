using OrderManager.Model;
using System.Windows.Controls;

namespace OrderManager.Controls
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            Order order = new Order();
            DataContext = order;
            InitializeComponent();
        }
    }
}
