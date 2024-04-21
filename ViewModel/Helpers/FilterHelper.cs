using OrderManager.Model;
using System.Windows.Controls;

namespace OrderManager.ViewModel.Helpers
{
    class FilterHelper
    {

        public static List<Order> FilterByButtons(List<Order> orders, List<Button> clickedButtons)
        {
            List<string?> productButtonTexts = clickedButtons.Where(button => button.Tag.Equals("Product")).Select(button => button.Content.ToString()).ToList();
            List<string?> operationButtonTexts = clickedButtons.Where(button => button.Tag.Equals("Operation")).Select(button => button.Content.ToString()).ToList();

            List<Order> filteredOrders = new List<Order>();
            if (productButtonTexts.Any() || operationButtonTexts.Any())
            {
                filteredOrders = orders.OrderByDescending(o => o.WeekOfManufacture).Where(o =>
                          (productButtonTexts.Count == 0 || productButtonTexts.Contains(o.Product.ToString())) &&
                          (operationButtonTexts.Count == 0 || operationButtonTexts.Contains(o.Operation.ToString()))
                      ).ToList();

                if (operationButtonTexts.Contains("Výkresy"))
                {
                    filteredOrders = filteredOrders.OrderBy(o => o.WeekOfManufacture).ToList();
                }

            }
            return filteredOrders;
        }

        public static List<Order> FilterBySearchingText(List<Order> ordersFromDatabase, string searchingText)
        {
            List<Order> filteredOrders = new List<Order>();

            filteredOrders = ordersFromDatabase.Where(o => o.Number != null && o.Number.ToLower().Contains(searchingText.ToLower())).ToList();

            return filteredOrders;
        }

    }
}
