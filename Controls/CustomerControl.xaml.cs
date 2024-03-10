using OrderManager.Model;
using System.Windows.Controls;

namespace OrderManager.Controls
{
    /// <summary>
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        public CustomerControl()
        {
            Customer customer = new Customer();
            DataContext = customer;
            InitializeComponent();
        }
    }
}
