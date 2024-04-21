using System.Windows.Input;

namespace OrderManager.ViewModel.Commands.HomeViewModelCommands
{
    public class NextPageCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public NextPageCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            HomeVM.MoveToNextPage();

        }
    }
}
