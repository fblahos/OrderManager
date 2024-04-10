using System.Windows;
using System.Windows.Controls;



namespace OrderManager.View
{
    public partial class Home : Window
    {
        //List<Order> orders;
        //List<Button> clickedButtons;
        //List<string?> selectedItemsOfWeekList;
        //public int? NumberOfOrders { get; set; }
        public Home()
        {
            //  orders = new List<Order>();
            //clickedButtons = new List<Button>();
            //selectedItemsOfWeekList = new List<string?>();
            InitializeComponent();


        }

        //Searching
        private void textBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            textBlockSearch.Visibility = Visibility.Hidden;
        }

        //Maximized, Minimized, Close
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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

        //Database connection
        public void ReadDatabase()
        {
            //    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            //    {
            //        connection.CreateTable<Address>();
            //        connection.CreateTable<Customer>();
            //        connection.CreateTable<DeliveryAdress>();
            //        connection.CreateTable<Distributor>();
            //        connection.CreateTable<Platform>();
            //        connection.CreateTable<MaterialSurface>();
            //        connection.CreateTable<Order>();

            //        orders = connection.Table<Order>().ToList().OrderBy(c => c.Id).ToList();
            //    }
            //    if (orders != null)
            //    {
            //        ShowOrders(orders);
            //    }
        }









        ////**************************************************FILTRACE*************************************************//

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            //    ChangeColorOfButton(sender);

            //    // Získání obsahu všech stisknutých tlačítek
            //    List<string?> productButtonTexts = clickedButtons.Where(button => button.Tag.Equals("Product")).Select(button => button.Content.ToString()).ToList();
            //    List<string?> operationButtonTexts = clickedButtons.Where(button => button.Tag.Equals("Operation")).Select(button => button.Content.ToString()).ToList();



            //    if (productButtonTexts.Any() || operationButtonTexts.Any())
            //    {
            //        using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            //        {
            //            // Použití logického operátoru AND pro kombinaci filtrů
            //            orders = connection.Table<Order>().ToList().OrderByDescending(o => o.WeekOfManufacture).Where(o =>
            //                (productButtonTexts.Count == 0 || productButtonTexts.Contains(o.Product.ToString())) &&
            //                (operationButtonTexts.Count == 0 || operationButtonTexts.Contains(o.Operation.ToString()))
            //            ).ToList();

            //            if (operationButtonTexts.Contains("Výkresy"))
            //            {
            //                orders = orders.OrderBy(o => o.WeekOfManufacture).ToList();
            //            }

            //        }

            //        // Aktualizace zobrazených dat v DataGrid
            //        ShowOrders(orders);
            //    }
            //    else
            //    {
            //        // Pokud není vybráno žádné tlačítko, zobrazíme všechny položky
            //        ReadDatabase();
            //    }
        }


        private void ChangeColorOfButton(object sender)
        {
            //    Button? clickedButton = sender as Button;
            //    if (clickedButton != null)
            //    {
            //        if (clickedButtons.Contains(clickedButton))
            //        {
            //            //Pokud je tlačítko již v seznamu, to znamená, že je stisknuté tak aktivuj původní styl
            //            clickedButton.Style = (Style)FindResource("filterButtonStyle");
            //            clickedButtons.Remove(clickedButton);
            //        }
            //        else
            //        {
            //            // Pokud tlačítko není v seznamu, přidej ho a aktivuj nový styl
            //            clickedButtons.Add(clickedButton);
            //            clickedButton.Style = (Style)FindResource("filterButtonStyleClicked");
            //        }
            //    }
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

        private void allFiltersOffButton_Click(object sender, RoutedEventArgs e)
        {
            //    weekOfManufactureList.SelectedIndex = -1;

            //    if (clickedButtons.Count > 0)
            //    {
            //        for (int i = clickedButtons.Count - 1; i >= 0; i--)
            //        {
            //            var item = clickedButtons[i];
            //            item.Style = (Style)FindResource("filterButtonStyle");
            //            clickedButtons.Remove(item);
            //        }

            //    }
            //    ReadDatabase();

        }

        ////**************************************************FILTRACE*************************************************//


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //    TextBox? searchTextBox = sender as TextBox;

            //    var filteredList = orders.Where(c => c.Number.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            //    ShowOrders(filteredList, true);

        }

        private void pagePlus_Click(object sender, RoutedEventArgs e)
        {
            //    // Získání aktuálního pageNumber a přičtení 1
            //    int currentPageNumber = int.Parse(pageNumberTextBlock.Text);
            //    ShowOrders(orders, true, currentPageNumber + 1);
        }

        private void pageMinus_Click(object sender, RoutedEventArgs e)
        {
            //    // Získání aktuálního pageNumber a odečtení 1
            //    int currentPageNumber = int.Parse(pageNumberTextBlock.Text);
            //    // Ujistěte se, že pageNumber není menší než 1
            //    if (currentPageNumber > 1)
            //    {
            //        ShowOrders(orders, true, currentPageNumber - 1);
            //    }
            //    else
            //    {
            //        pageNumberTextBlock.Text = 1.ToString();
            //    }
        }

        private void orderDataGrid_RightClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            //    Order? selectedOrder = orderDataGrid.SelectedItem as Order;

            //    if (selectedOrder != null)
            //    {
            //        // Vytvoření instance okna Update
            //        Detail detailOrder = new Detail(selectedOrder);


            //    }

        }


        private void updateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //    //Order? selectedOrder = orderDataGrid.SelectedItem as Order;


            //    //using SQLiteConnection connection = new SQLiteConnection(App.databasePath);

            //    //if (selectedOrder != null)
            //    //{
            //    //    // Vytvoření instance okna Update
            //    //    Update updateOrder = new Update(selectedOrder);
            //    //    updateOrder.ShowDialog();
            //    //}
        }

        private void deleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //    //Order? selectedOrder = orderDataGrid.SelectedItem as Order;

            //    //using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            //    //{
            //    //    if (selectedOrder != null)
            //    //    {
            //    //        connection.CreateTable<Order>();
            //    //        connection.Delete(selectedOrder);
            //    //    }
            //    //}

            //    //ReadDatabase();
        }
    }
}