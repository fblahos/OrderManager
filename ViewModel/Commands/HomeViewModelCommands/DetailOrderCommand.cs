using OrderManager.Model;
using OrderManager.View;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class DetailOrderCommand : ICommand
    {

        public HomeVM HomeVM { get; set; }

        public DetailOrderCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? selectedOrder)
        {
            if (selectedOrder == null)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public void Execute(object? selectedOrder)
        {
            Detail detailOrder = new Detail(selectedOrder as Order);
            detailOrder.Show();

        }
    }
}
