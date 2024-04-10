using OrderManager.ViewModel;
using System.Windows.Input;

class DeleteOrderCommand : ICommand
{
    public OrderVM ViewModel { get; set; }

    public event EventHandler? CanExecuteChanged;

    public DeleteOrderCommand(OrderVM vm)
    {
        ViewModel = vm;
    }

    public bool CanExecute(object? parameter)
    {
        if (parameter == null)
        {
            return false;
        }
        else
        {

            return true;
        }
    }

    public void Execute(object? parameter)
    {
        ViewModel.DeleteOrder();
    }
}
