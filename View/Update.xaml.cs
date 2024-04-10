using OrderManager.Model;
using System.Windows;

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {

        public Update(Order selectedOrder)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            orderControl.DataContext = selectedOrder;

            //UpdateDatabase(selectedOrder);


        }

        //Aktualizace
        //private void UpdateDatabase(Order selectedOrder)
        //{

        //    using SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath);

        //    connection.Update(selectedOrder);
        //}


        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Akce po kliknutím levým tlačítkem myši
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
