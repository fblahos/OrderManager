using System.Windows.Input;

namespace OrderManager.ViewModel.Commands
{
    public class RefreshOrdersCommand : ICommand
    {
        public HomeVM HomeVM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public RefreshOrdersCommand(HomeVM homeVM)
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
