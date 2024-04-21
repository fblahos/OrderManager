using OrderManager.ViewModel;
using System.Windows.Input;

public class DeleteOrderCommand : ICommand
{
    public HomeVM HomeVM { get; set; }

    public event EventHandler? CanExecuteChanged;

    public DeleteOrderCommand(HomeVM homeVM)
    {
        HomeVM = homeVM;
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
        HomeVM.DeleteOrder();
    }
}
