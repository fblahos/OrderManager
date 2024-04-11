using OrderManager.Model;
using OrderManager.ViewModel.Commands;
using OrderManager.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrderManager.ViewModel
{
    public class HomeVM : INotifyPropertyChanged
    {
        public ObservableCollection<Order> Orders { get; set; }
        public CreateWindowCommand CreateWindowCommand { get; set; }
        public DeleteOrderCommand DeleteOrderCommand { get; set; }
        public EditOrderCommand EditOrderCommand { get; set; }
        public DetailOrderCommand DetailOrderCommand { get; set; }
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


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public HomeVM()
        {
            Orders = new ObservableCollection<Order>();
            CreateWindowCommand = new CreateWindowCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
            EditOrderCommand = new EditOrderCommand(this);
            RefreshOrderListCommand = new RefreshOrderListCommand(this);
            DetailOrderCommand = new DetailOrderCommand(this);
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
