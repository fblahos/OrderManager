using OrderManager.View;
using System.Windows;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class CreateWindowCommand : ICommand
    {

        public HomeVM HomeVM { get; set; }

        public CreateWindowCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
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
