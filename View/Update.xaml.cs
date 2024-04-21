using OrderManager.Model;
using OrderManager.ViewModel.Helpers;
using System.Windows;

namespace OrderManager
{

    public partial class Update : Window
    {
        Order UpdatedOrder { get; set; }

        public Update(Order selectedOrder)
        {
            UpdatedOrder = selectedOrder;
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            orderControl.DataContext = selectedOrder;
            platformControl.DataContext = DatabaseHelper.Read<Platform>().Where(x => x.Id == selectedOrder.PlatformId).First();
            supplierControl.DataContext = DatabaseHelper.Read<Supplier>().Where(x => x.Id == selectedOrder.SupplierId).First();
            deliveryAddressControl.DataContext = DatabaseHelper.Read<DeliveryAddress>().Where(x => x.Id == selectedOrder.DeliveryAddressId).First();
            distributorControl.DataContext = DatabaseHelper.Read<Distributor>().Where(x => x.Id == selectedOrder.DistributorId).First();
            materialControl.DataContext = DatabaseHelper.Read<MaterialSurface>().Where(x => x.Id == selectedOrder.MaterialSurfaceId).First();
        }
        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper.Update(UpdatedOrder);
            this.Close();
        }

        //Akce po kliknutím levým tlačítkem myši
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
