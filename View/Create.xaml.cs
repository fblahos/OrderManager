using OrderManager.Model;
using SQLite;
using System.Windows;
namespace OrderManager.View
{


    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }


        // Vytvoření nové objednávky
        private void createOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order()
            {
                Name = orderControl.orderNameTextBox.Text,
                Number = orderControl.orderNumberTextBox.Text,
                Product = Order.Products.Stratos.GetDisplayValue(),
                Status = Order.Statuses.Zadano.GetDisplayValue(),
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                WeekOfManufacture = 1,
                Operation = Order.Operations.Zastavba.GetDisplayValue(),


            };
            Platform platform = new Platform()
            {
            };

            Customer customer = new Customer()
            {
                Firma = customerControl.firmaTextBox.Text,

            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                if (string.IsNullOrEmpty(order.Name) || string.IsNullOrEmpty(order.Number))
                {
                    MessageBox.Show("Nemůžu vytvořit zakázku, která nemá číslo nebo název.");
                }
                else
                {
                    connection.Insert(platform);
                    connection.Insert(customer);
                    order.PlatformId = platform.Id;
                    order.CustomerId = customer.Id;
                    connection.Insert(order);
                }
            }
            Close(); //zavření okna
        }





        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Akce po kliknutí levým tlačítkem
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }


}

