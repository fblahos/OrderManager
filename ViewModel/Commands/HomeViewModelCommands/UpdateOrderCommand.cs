using OrderManager.Model;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class UpdateOrderCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public UpdateOrderCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

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
            Update updateOrder = new Update(selectedOrder as Order);
            updateOrder.Show();

        }
    }
}
