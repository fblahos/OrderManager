using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    internal class RefreshOrderListCommand : ICommand
    {
        public OrderVM ViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public RefreshOrderListCommand(OrderVM vm)
        {
            ViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {

            return true;

        }

        public void Execute(object? parameter)
        {
            ViewModel.RefreshOrders();
        }
    }


}
