using System.Windows.Input;

namespace OrderManager.ViewModel.Commands.HomeViewModelCommands
{
    public class FilterOffCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public FilterOffCommand(HomeVM homeVM)
        {
            HomeVM = homeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            HomeVM.SetFiltersOff();
        }
    }
}
