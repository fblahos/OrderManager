using OrderManager.View;
using System.Windows;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    internal class AddOrderCommand : ICommand
    {

        public OrderVM OrderVM { get; set; }

        public AddOrderCommand(OrderVM orderVM)
        {
            OrderVM = orderVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == "CreateWindow")
                {
                    return false;
                }
            }
            return true;
        }

        public void Execute(object? parameter)
        {

            Create createOrder = new Create();
            createOrder.Show();

        }
    }
}
