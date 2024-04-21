using OrderManager.Model;
using OrderManager.ViewModel.Helpers;
using System.Windows;

namespace OrderManager.View
{

    public partial class Detail : Window
    {
        public Detail(Order selectedOrder)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            orderControl.DataContext = selectedOrder;
            platformControl.DataContext = DatabaseHelper.Read<Platform>().Where(x => x.Id == selectedOrder.PlatformId).First();
            supplierControl.DataContext = DatabaseHelper.Read<Supplier>().Where(x => x.Id == selectedOrder.SupplierId).First();
            deliveryAddressControl.DataContext = DatabaseHelper.Read<DeliveryAddress>().Where(x => x.Id == selectedOrder.DeliveryAddressId).First();
            distributorControl.DataContext = DatabaseHelper.Read<Distributor>().Where(x => x.Id == selectedOrder.DistributorId).First();
            materialControl.DataContext = DatabaseHelper.Read<MaterialSurface>().Where(x => x.Id == selectedOrder.MaterialSurfaceId).First();
            LockControls();
        }

        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Pohyb okna pomocí levého tlačítka myši
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        //Uzamčení UI
        private void LockControls()
        {
            orderControl.IsEnabled = false;
            supplierControl.IsEnabled = false;
            distributorControl.IsEnabled = false;
            deliveryAddressControl.IsEnabled = false;
            platformControl.IsEnabled = false;
            materialControl.IsEnabled = false;
        }
    }
}
