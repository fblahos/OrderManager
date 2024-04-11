using OrderManager.Model;
using OrderManager.ViewModel.Commands;
using OrderManager.ViewModel.Helpers;

namespace OrderManager.ViewModel
{
    public class CreateOrderVM
    {
        public CreateOrderCommand CreateOrderCommand { get; set; }

        public string? Name { get; set; }
        public string? Number { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public CreateOrderVM()
        {
            CreateOrderCommand = new CreateOrderCommand(this);
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
        }







    }
}
