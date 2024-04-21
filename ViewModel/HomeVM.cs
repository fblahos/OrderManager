using CommunityToolkit.Mvvm.ComponentModel;
using OrderManager.Model;
using OrderManager.ViewModel.Commands;
using OrderManager.ViewModel.Commands.HomeViewModelCommands;
using OrderManager.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OrderManager.ViewModel
{
    public partial class HomeVM : ObservableObject
    {
        public static ObservableCollection<Order>? Orders { get; set; }
        public static ObservableCollection<Order>? OrdersForPage { get; set; }

        public static List<Button>? clickedButtons;
        public CreateWindowCommand CreateWindowCommand { get; set; }
        public DeleteOrderCommand DeleteOrderCommand { get; set; }
        public UpdateOrderCommand UpdateOrderCommand { get; set; }
        public DetailOrderCommand DetailOrderCommand { get; set; }
        public RefreshOrdersCommand RefreshOrdersCommand { get; set; }
        public FilterOnCommand FilterOnCommand { get; set; }
        public FilterOffCommand FilterOffCommand { get; set; }
        public PreviousPageCommand PreviousPageCommand { get; set; }
        public NextPageCommand NextPageCommand { get; set; }

        private static readonly int ordersPerPageCount = 27;

        [ObservableProperty]
        private int pageNumber = 1;

        [ObservableProperty]
        private int ordersCount;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private Order? selectedOrder;

        public HomeVM()
        {
            clickedButtons = new List<Button>();
            Orders = new ObservableCollection<Order>();
            OrdersForPage = new ObservableCollection<Order>();
            CreateWindowCommand = new CreateWindowCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
            UpdateOrderCommand = new UpdateOrderCommand(this);
            RefreshOrdersCommand = new RefreshOrdersCommand(this);
            FilterOnCommand = new FilterOnCommand(this);
            FilterOffCommand = new FilterOffCommand(this);
            DetailOrderCommand = new DetailOrderCommand(this);
            PreviousPageCommand = new PreviousPageCommand(this);
            NextPageCommand = new NextPageCommand(this);
            GetOrders();
        }

        partial void OnSearchTextChanged(string searchingText)
        {
            if (searchingText.Length > 5)
            {
                GetOrders(true, searchingText);

            }
        }

        public void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                DatabaseHelper.Delete(SelectedOrder);
                GetOrders();
            }
        }


        public void GetOrders(bool IsSearchTextActive = false, string? searchingText = null)
        {
            Orders?.Clear();
            OrdersForPage?.Clear();

            List<Order> ordersFromDatabase = DatabaseHelper.Read<Order>();

            if (clickedButtons?.Count > 0)
            {
                ordersFromDatabase = FilterHelper.FilterByButtons(ordersFromDatabase, clickedButtons);

            }

            if (!string.IsNullOrWhiteSpace(searchingText))
            {
                ordersFromDatabase = FilterHelper.FilterBySearchingText(ordersFromDatabase, searchingText);
            }

            foreach (var item in ordersFromDatabase)
            {
                Orders?.Add(item);
            }

            OrdersCount = Orders.Count;

            List<Order>? ordersPerPage = Orders?.Skip((PageNumber - 1) * ordersPerPageCount).Take(ordersPerPageCount).ToList();

            foreach (var item in ordersPerPage)
            {
                OrdersForPage?.Add(item);
            }

        }

        public void MoveToNextPage()
        {
            if (Math.Ceiling((double)Orders.Count / ordersPerPageCount) > PageNumber)
            {
                PageNumber++;
                GetOrders();
            }
        }

        public void MoveToPreviousPage()
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                GetOrders();
            }
        }

        public void AddClickedButton(Button button)
        {
            if (clickedButtons.Contains(button))
            {
                clickedButtons?.Remove(button);
                ChangeButtonColor(button, true); // tlačítko je zapnuté, tak ho vypneme
            }

            else
            {
                clickedButtons?.Add(button);
                ChangeButtonColor(button, false); // tlačítko je vypnuté, tak ho zapneme
            }

            GetOrders();
        }


        public void SetFiltersOff()
        {
            foreach (Button button in clickedButtons)
            {
                clickedButtons?.Remove(button);
                ChangeButtonColor(button, true); //vypnutí tlačítka
            }
            GetOrders();
        }

        public static void ChangeButtonColor(Button button, bool isClickedButtonOn)
        {
            var appResources = Application.Current.Resources;

            if (isClickedButtonOn)
            {
                // Pokud je tlačítko již v seznamu, to znamená, že je stisknuté tak aktivuj vypnutý styl
                if (appResources["filterButtonStyle"] is Style filterButtonStyle)
                {
                    button.Style = filterButtonStyle;
                }
            }
            else
            {
                // Pokud tlačítko není v seznamu, přidej ho a aktivuj nový styl
                if (appResources["filterButtonStyleClicked"] is Style filterButtonStyleClicked)
                {
                    button.Style = filterButtonStyleClicked;
                }
            }
        }


    }
}

