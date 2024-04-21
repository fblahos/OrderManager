using System.Windows;
using System.Windows.Controls;



namespace OrderManager.View
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        //Searching textBox visibility
        private void textBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            textBlockSearch.Visibility = Visibility.Hidden;
        }

        //Close window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Maximized window
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        //Minimize window
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                this.DragMove();
            }
        }






        //  private void ShowOrders(List<Order> orders, bool updateWeekList = true, int pageNumber = 1)
        //{
        //    int pageSize = 27;

        //    if (pageNumber <= 0) { pageNumber = 1; }
        //    if (pageNumber > Math.Ceiling((double)orders.Count / pageSize)) { pageNumber--; }

        //    // Vypočtěte, kolik záznamů máte přeskočit
        //    int itemsToSkip = (pageNumber - 1) * pageSize;

        //    // Získejte záznamy pro danou stránku
        //    orderDataGrid.ItemsSource = orders.Skip(itemsToSkip).Take(pageSize).ToList();


        //    NumberOfOrders = orders.Count;

        //    numberOfOrdersTextBlock.Text = NumberOfOrders.ToString();
        //    pageNumberTextBlock.Text = pageNumber.ToString();

        //    if (updateWeekList)
        //    {
        //        List<int?> weekOfManufacture = orders
        //            .OrderBy(o => o.WeekOfManufacture) // Seřadí hodnoty WeekOfManufacture
        //            .Select(o => o.WeekOfManufacture) // Vybere všechny hodnoty WeekOfManufacture
        //            .Where(week => week.HasValue && week.Value >= 1) // Filtruje pouze not null hodnoty větší než 1
        //            .Distinct() // Odstraní duplicity
        //            .ToList(); // Převede výsledek na seznam

        //        weekOfManufactureList.ItemsSource = weekOfManufacture;

        //        // Zavoláme metodu weekOfManufactureList_SelectionChanged, pokud je nějaká položka vybrána
        //        if (weekOfManufactureList.SelectedItems.Count != 0)
        //        {
        //            weekOfManufactureList_SelectionChanged(weekOfManufactureList, new SelectionChangedEventArgs(Selector.SelectionChangedEvent, weekOfManufactureList.SelectedItems, new List<object>()));
        //        }

        //    }
        //}
        private void weekOfManufactureList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //    selectedItemsOfWeekList.Clear(); // Vyprázdnění seznamu před přidáním nových položek

            //    foreach (var selectedItem in weekOfManufactureList.SelectedItems)
            //    {
            //        selectedItemsOfWeekList.Add(selectedItem.ToString()); // Přidání každé vybrané položky do listu selectedItemsOfWeekList
            //    }

            //    // Filtrujeme orders na základě výběru ve weekOfManufactureList a aktualizujeme zobrazení zakázek
            //    if (selectedItemsOfWeekList.Count > 0)
            //    {
            //        ShowOrders(orders.Where(week => selectedItemsOfWeekList.Contains(week.WeekOfManufacture.Value.ToString())).ToList(), false, int.Parse(pageNumberTextBlock.Text));
            //    }
            //    else
            //    {
            //        ShowOrders(orders);
            //    }
        }










    }
}