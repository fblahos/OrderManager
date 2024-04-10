using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    class EditOrderCommand : ICommand
    {
        public OrderVM ViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public EditOrderCommand(OrderVM vm)
        {
            ViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

        }
    }
}
