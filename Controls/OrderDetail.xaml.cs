using System.Windows.Controls;

namespace OrderManager.Controls
{
    /// <summary>
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : UserControl
    {
        public OrderDetail()
        {
            InitializeComponent();
            DataContext = this;
        }

    }
}
