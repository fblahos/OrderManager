using System.Windows.Input;

namespace OrderManager.ViewModel.Commands.HomeViewModelCommands
{
    public class PreviousPageCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public PreviousPageCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            HomeVM.MoveToPreviousPage();

        }
    }
}
