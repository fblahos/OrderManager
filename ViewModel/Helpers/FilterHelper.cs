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

            operationButtonTexts = TranslateOperations(operationButtonTexts);

            List<Order> filteredOrders = new List<Order>();
            if (productButtonTexts.Any() || operationButtonTexts.Any())
            {
                filteredOrders = orders.OrderBy(o => o.Id).Where(o =>
                          (productButtonTexts.Count == 0 || productButtonTexts.Contains(o.Product.ToString())) &&
                          (operationButtonTexts.Count == 0 || operationButtonTexts.Contains(o.Operation.ToString()))
                      ).ToList();

                if (operationButtonTexts.Contains("Výrobní výkresy"))
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

        public static List<Order> FilterByWeeks(List<Order> ordersFromDatabase, int? week)
        {
            List<Order> filteredOrders = new List<Order>();

            filteredOrders = ordersFromDatabase.Where(o => o.WeekOfManufacture != null && o.WeekOfManufacture == week).ToList();

            return filteredOrders;
        }


        public static List<string> TranslateOperations(List<string?> operationButtonTexts)
        {
            List<string?> translantedOperations = new List<string>();


            for (int i = 0; i < operationButtonTexts.Count; i++)
            {
                if (operationButtonTexts[i].Contains("Výkresy"))
                {
                    operationButtonTexts[i] = "Výrobní výkresy";
                }

                else if (operationButtonTexts[i].Contains("Dimenze"))
                {
                    operationButtonTexts[i] = "Generování do Dimenze";
                }

                else if (operationButtonTexts[i].Contains("Uzavření"))
                {
                    operationButtonTexts[i] = "Uzavření konstrukce";
                }


                else if (operationButtonTexts[i].Contains("Elektro"))
                {
                    operationButtonTexts[i] = "Generování Elektro";
                }

                translantedOperations.Add(operationButtonTexts[i]);
            }

            return translantedOperations;

        }
    }
}
