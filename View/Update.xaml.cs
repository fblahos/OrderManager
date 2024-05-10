using OrderManager.Model;
using OrderManager.ViewModel.Helpers;
using System.Windows;

namespace OrderManager
{

    public partial class Update : Window
    {
        Order UpdatedOrder { get; set; }
        Platform UpdatedPlatform { get; set; }
        Supplier UpdatedSupplier { get; set; }
        Distributor UpdatedDistributor { get; set; }
        DeliveryAddress UpdatedDelivery { get; set; }
        MaterialSurface UpdatedMaterial { get; set; }

        Order OldOrder { get; set; }
        Platform OldPlatform { get; set; }
        Supplier OldSupplier { get; set; }
        Distributor OldDistributor { get; set; }
        DeliveryAddress OldDelivery { get; set; }
        MaterialSurface OldMaterial { get; set; }

        bool IsOrderUpdated { get; set; }
        bool IsPlatformUpdated { get; set; }
        bool IsSupplierUpdated { get; set; }
        bool IsDistributorUpdated { get; set; }
        bool IsDeliveryUpdated { get; set; }
        bool IsMaterialUpdated { get; set; }

        public Update(Order selectedOrder)
        {
            UpdatedOrder = selectedOrder;
            UpdatedPlatform = DatabaseHelper.Read<Platform>().Where(x => x.Id == selectedOrder.PlatformId).First();
            UpdatedSupplier = DatabaseHelper.Read<Supplier>().Where(x => x.Id == selectedOrder.SupplierId).First();
            UpdatedDistributor = DatabaseHelper.Read<Distributor>().Where(x => x.Id == selectedOrder.DistributorId).First();
            UpdatedDelivery = DatabaseHelper.Read<DeliveryAddress>().Where(x => x.Id == selectedOrder.DeliveryAddressId).First();
            UpdatedMaterial = DatabaseHelper.Read<MaterialSurface>().Where(x => x.Id == selectedOrder.MaterialSurfaceId).First();

            OldOrder = UpdatedOrder;
            OldPlatform = UpdatedPlatform;
            OldSupplier = UpdatedSupplier;
            OldDistributor = UpdatedDistributor;
            OldDelivery = UpdatedDelivery;
            OldMaterial = UpdatedMaterial;


            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            orderControl.DataContext = selectedOrder;
            platformControl.DataContext = UpdatedPlatform;
            supplierControl.DataContext = UpdatedSupplier;
            deliveryAddressControl.DataContext = UpdatedDelivery;
            distributorControl.DataContext = UpdatedDistributor;
            materialControl.DataContext = UpdatedMaterial;
        }
        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            IsOrderUpdated = DatabaseHelper.Update(UpdatedOrder);
            IsPlatformUpdated = DatabaseHelper.Update(UpdatedPlatform);
            IsSupplierUpdated = DatabaseHelper.Update(UpdatedSupplier);
            IsDistributorUpdated = DatabaseHelper.Update(UpdatedDistributor);
            IsDeliveryUpdated = DatabaseHelper.Update(UpdatedDelivery);
            IsMaterialUpdated = DatabaseHelper.Update(UpdatedMaterial);

            InsertChangesToDatabase();
            this.Close();
        }

        private void InsertChangesToDatabase()
        {
            if (IsOrderUpdated)
            {
                List<PropertyChange> OrderChanges = GetChangedProperties(OldOrder, UpdatedOrder);
            }

            if (IsPlatformUpdated)
            {
                List<PropertyChange> PlatformChanges = GetChangedProperties(OldPlatform, UpdatedPlatform);
            }

            if (IsSupplierUpdated)
            {
                List<PropertyChange> SupplierChanges = GetChangedProperties(OldSupplier, UpdatedSupplier);
            }

            if (IsDistributorUpdated)
            {
                List<PropertyChange> DistributorChanges = GetChangedProperties(OldDistributor, UpdatedDistributor);
            }

            if (IsDeliveryUpdated)
            {
                List<PropertyChange> DeliveryChanges = GetChangedProperties(OldDelivery, UpdatedDelivery);
            }

            if (IsMaterialUpdated)
            {
                List<PropertyChange> MaterialChanges = GetChangedProperties(OldMaterial, UpdatedMaterial);
            }

        }



        public class PropertyChange
        {
            public string Name { get; set; }
            public object OldValue { get; set; }
            public object NewValue { get; set; }
        }

        public List<PropertyChange> GetChangedProperties<T>(T obj1, T obj2)
        {
            var properties = typeof(T).GetProperties();
            var changedProperties = new List<PropertyChange>();

            foreach (var property in properties)
            {
                var oldValue = property.GetValue(obj1);
                var newValue = property.GetValue(obj2);

                // Porovnání hodnot dané vlastnosti v obou instancích
                if (!Equals(oldValue, newValue))
                {
                    // Pokud jsou hodnoty různé, přidejte změněnou vlastnost do seznamu
                    changedProperties.Add(new PropertyChange
                    {
                        Name = property.Name,
                        OldValue = oldValue,
                        NewValue = newValue
                    });
                }
            }

            return changedProperties;
        }




















        //Akce po kliknutím levým tlačítkem myši
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
