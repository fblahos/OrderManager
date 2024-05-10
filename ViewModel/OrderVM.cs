using OrderManager.Model;
using OrderManager.ViewModel.Commands;
using OrderManager.ViewModel.Helpers;

namespace OrderManager.ViewModel
{
    public class OrderVM
    {
        public CreateOrderCommand CreateOrderCommand { get; set; }

        public OrderVM()
        {
            CreateOrderCommand = new CreateOrderCommand(this);
        }

        //Order
        public string? Name { get; set; }
        public string? Number { get; set; }

        //Supplier
        public string? SupplierCompany { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierStreet { get; set; }
        public string? SupplierZipCode { get; set; }
        public string? SupplierCity { get; set; }
        public string? SupplierCountry { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierIdentitycard { get; set; }
        public string? SupplierVatId { get; set; }

        //Distributor
        public string? DistributorCompany { get; set; }
        public string? DistributorName { get; set; }
        public string? DistributorStreet { get; set; }
        public string? DistributorZipCode { get; set; }
        public string? DistributorCity { get; set; }
        public string? DistributorCountry { get; set; }
        public string? DistributorPhone { get; set; }
        public string? DistributorEmail { get; set; }
        public string? DistributorIdentitycard { get; set; }
        public string? DistributorVatId { get; set; }

        //Delivery Address
        public string? DeliveryCompany { get; set; }
        public string? DeliveryName { get; set; }
        public string? DeliveryStreet { get; set; }
        public string? DeliveryZipCode { get; set; }
        public string? DeliveryCity { get; set; }
        public string? DeliveryCountry { get; set; }
        public string? DeliveryPhone { get; set; }
        public string? DeliveryEmail { get; set; }
        public string? DeliveryIdentitycard { get; set; }
        public string? DeliveryVatId { get; set; }

        //Platform
        public double Length { get; set; }
        public double Width { get; set; }
        public string? UpperRamp { get; set; }
        public string? LowerRamp { get; set; }
        public string? FrontRamp { get; set; }
        public bool IsFixedFront { get; set; }
        public bool IsFoldableFront { get; set; }
        public bool IsFrontRamp85Degrees { get; set; }
        public string? Seat { get; set; }
        public string? LoadingCapacity { get; set; }
        public bool IsAutomaticFolding { get; set; }
        public bool IsManualFolding { get; set; }


        public void CreateOrder()
        {

            Platform platform = new Platform
            {
                Length = this.Length,
                Width = this.Width,
                UpperRamp = this.UpperRamp,
                LowerRamp = this.LowerRamp,
                FrontRamp = this.FrontRamp,
                IsFixedFront = this.IsFixedFront,
                IsFoldableFront = this.IsFoldableFront,
                IsFrontRamp85Degrees = this.IsFrontRamp85Degrees,
                Seat = this.Seat,
                LoadingCapacity = this.LoadingCapacity,
                IsAutomaticFolding = this.IsAutomaticFolding,
                IsManualFolding = this.IsManualFolding
            };

            Supplier supplier = new Supplier
            {
                Company = this.SupplierCompany,
                Name = this.SupplierName,
                Street = this.SupplierStreet,
                ZipCode = this.SupplierZipCode,
                City = this.SupplierCity,
                Country = this.SupplierCountry,
                Phone = this.SupplierPhone,
                Email = this.SupplierEmail,
                Identitycard = this.SupplierIdentitycard,
                VatId = this.SupplierVatId,
            };

            Distributor distributor = new Distributor
            {
                Company = this.DistributorCompany,
                Name = this.DistributorName,
                Street = this.DistributorStreet,
                ZipCode = this.DistributorZipCode,
                City = this.DistributorCity,
                Country = this.DistributorCountry,
                Phone = this.DistributorPhone,
                Email = this.DistributorEmail,
                Identitycard = this.DistributorIdentitycard,
                VatId = this.DistributorVatId,
            };

            DeliveryAddress deliveryAddress = new DeliveryAddress
            {
                Company = this.DeliveryCompany,
                Name = this.DeliveryName,
                Street = this.DeliveryStreet,
                ZipCode = this.DeliveryZipCode,
                City = this.DeliveryCity,
                Country = this.DeliveryCountry,
                Phone = this.DeliveryPhone,
                Email = this.DeliveryEmail,
                Identitycard = this.DeliveryIdentitycard,
                VatId = this.DeliveryVatId
            };

            MaterialSurface materialSurface = new MaterialSurface
            {
                // zde budou vlastnosti materialu
            };




            DatabaseHelper.Insert(supplier);
            DatabaseHelper.Insert(distributor);
            DatabaseHelper.Insert(deliveryAddress);
            DatabaseHelper.Insert(platform);
            DatabaseHelper.Insert(materialSurface);


            Order order = new Order
            {
                Name = this.Name,
                Number = this.Number,
                Product = Order.Products.Stratos.GetDisplayValue(),
                Status = Order.Statuses.Zadano.GetDisplayValue(),
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                WeekOfManufacture = 1,
                Operation = Order.Operations.Vykresy.GetDisplayValue(),
                PlatformId = platform.Id,
                SupplierId = supplier.Id,
                DistributorId = distributor.Id,
                DeliveryAddressId = deliveryAddress.Id,
                MaterialSurfaceId = materialSurface.Id,
            };

            DatabaseHelper.Insert(order);
        }




    }

}

