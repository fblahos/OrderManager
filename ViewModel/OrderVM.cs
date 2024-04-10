using OrderManager.Model;
using OrderManager.ViewModel.Commands;
using OrderManager.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrderManager.ViewModel
{
    class OrderVM : INotifyPropertyChanged
    {

        public ObservableCollection<Order> Orders { get; set; }
        public NewOrderCommand NewOrderCommand { get; set; }
        public AddOrderCommand AddOrderCommand { get; set; }
        public DeleteOrderCommand DeleteOrderCommand { get; set; }
        public EditOrderCommand EditOrderCommand { get; set; }
        public ReadOrderCommand ReadOrderCommand { get; set; }
        public RefreshOrderListCommand RefreshOrderListCommand { get; set; }

        private Order? selectedOrder;
        public Order? SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public OrderVM()
        {
            Orders = new ObservableCollection<Order>();
            NewOrderCommand = new NewOrderCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
            AddOrderCommand = new AddOrderCommand(this);
            RefreshOrderListCommand = new RefreshOrderListCommand(this);
            //EditOrderCommand = new EditOrderCommand();
            //ReadOrderCommand = new ReadOrderCommand();
            GetOrders();
        }


        public void RefreshOrders()
        {
            GetOrders();
        }

        public void CreateOrder()
        {
            Platform platform = new Platform
            {
                Length = this.Length,
                Width = this.Width,
            };

            DatabaseHelper.Insert(platform);

            Order order = new Order
            {
                Name = this.Name,
                Number = this.Number,
                Product = Order.Products.Stratos.GetDisplayValue(),
                Status = Order.Statuses.Zadano.GetDisplayValue(),
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                WeekOfManufacture = 1,
                Operation = Order.Operations.Zastavba.GetDisplayValue(),
                PlatformId = platform.Id,
            };

            DatabaseHelper.Insert(order);
            GetOrders();
        }



        public void DeleteOrder()
        {
            if (selectedOrder != null)
            {
                DatabaseHelper.Delete(selectedOrder);
                GetOrders();
            }
        }

        private void GetOrders()
        {
            Orders.Clear();
            var orders = DatabaseHelper.Read<Order>();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }




    }
}
