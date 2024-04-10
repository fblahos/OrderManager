using System.Windows;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    class NewOrderCommand : ICommand
    {
        public OrderVM OrderVM { get; set; }
        public NewOrderCommand(OrderVM orderVM)
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
