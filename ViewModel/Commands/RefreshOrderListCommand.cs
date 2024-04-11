using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class RefreshOrderListCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public RefreshOrderListCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public bool CanExecute(object? parameter)
        {

            return true;

        }

        public void Execute(object? parameter)
        {
            // ViewModel.RefreshOrders();
        }
    }


}
