using System.Windows;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public CreateOrderVM CreateOrderVM { get; set; }
        public CreateOrderCommand(CreateOrderVM orderVM)
        {
            CreateOrderVM = orderVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            CreateOrderVM.CreateOrder();
            CloseWindow();
            HomeVM.GetOrders();
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
