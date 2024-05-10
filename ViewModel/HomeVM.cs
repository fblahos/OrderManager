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
        private static List<int>? weeksOfManufacture;

        [ObservableProperty]
        private int pageNumber = 1;


        [ObservableProperty]
        private int allPagesCount;

        [ObservableProperty]
        private int ordersCount;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private Order? selectedOrder;


        [ObservableProperty]
        private int? selectedWeek;


        public HomeVM()
        {
            weeksOfManufacture = new List<int>();
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
            PageNumber = 1;

            if ((searchingText.Length > 5) || (searchingText.Length == 0))
            {
                GetOrders(searchingText, null);
            }
        }

        partial void OnSelectedWeekChanged(int? week)
        {
            PageNumber = 1;
            GetOrders(null, week);
        }


        public void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                DatabaseHelper.Delete(SelectedOrder);
                GetOrders();
            }
        }


        public void GetOrders(string? searchingText = null, int? week = null)
        {
            Orders?.Clear();
            OrdersForPage?.Clear();
            WeeksOfManufacture?.Clear();

            List<Order> ordersFromDatabase = DatabaseHelper.Read<Order>();
            ordersFromDatabase = ordersFromDatabase.OrderBy(o => o.WeekOfManufacture).ToList();

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
                WeeksOfManufacture?.Add((int)item.WeekOfManufacture);
            }

            if (week != null)
            {
                ordersFromDatabase = FilterHelper.FilterByWeeks(ordersFromDatabase, week);
            }

            foreach (var item in ordersFromDatabase)
            {
                Orders?.Add(item);
            }

            WeeksOfManufacture = WeeksOfManufacture?.OrderBy(o => o).ToList();
            WeeksOfManufacture = (WeeksOfManufacture?.Distinct().ToList());

            OrdersCount = Orders.Count;
            AllPagesCount = (int)Math.Ceiling((double)OrdersCount / ordersPerPageCount);

            if (OrdersCount == 0)
            {
                AllPagesCount = 1;

            }

            List<Order>? ordersPerPage = Orders?.Skip((PageNumber - 1) * ordersPerPageCount).Take(ordersPerPageCount).ToList();

            foreach (var item in ordersPerPage)
            {
                OrdersForPage?.Add(item);
            }

        }

        public void MoveToNextPage()
        {
            if (AllPagesCount > PageNumber)
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
            PageNumber = 1;

            GetOrders();
        }


        public void SetFiltersOff()
        {
            if (clickedButtons != null && clickedButtons.Count > 0)
            {
                for (int i = clickedButtons.Count - 1; i >= 0; i--)
                {
                    Button button = clickedButtons[i];
                    clickedButtons.RemoveAt(i);
                    ChangeButtonColor(button, true); // vypnutí tlačítka
                }
            }
            PageNumber = 1;
            SelectedWeek = null;

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

