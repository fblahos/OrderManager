using System.Windows.Controls;
using System.Windows.Input;

namespace OrderManager.ViewModel.Commands.HomeViewModelCommands
{
    public class FilterOnCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public FilterOnCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is Button)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object? parameter)
        {
            Button button = parameter as Button;

            HomeVM.AddClickedButton(button);

        }
    }
}
