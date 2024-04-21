using System.Windows;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public OrderVM OrderVM { get; set; }
        public HomeVM homeVM { get; set; }
        public CreateOrderCommand(OrderVM orderVM)
        {
            OrderVM = orderVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OrderVM.CreateOrder();
            CloseWindow();
        }
        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                {
                    window.Close();
                    break;
                }
            }
        }
    }

}
