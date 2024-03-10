using OrderManager.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OrderManager.View
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public Detail(Order selectedOrder)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ZamknutiVlastnosti();

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ZamknutiVlastnosti()
        {
            // Získání všech ovládacích prvků ve vašem controlu OrderDetail
            var orderDetailControls = GetAllControls(controlsStackPanel);

            // Nastavit IsEnabled na false pro všechny ovládací prvky ve vašem controlu OrderDetail
            foreach (var control in orderDetailControls)
            {
                control.IsEnabled = false;
            }
        }

        // Pomocná metoda pro nalezení všech ovládacích prvků v daném controlu a jeho potomcích
        public static IEnumerable<Control> GetAllControls(DependencyObject parent)
        {
            if (parent is Control control)
            {
                yield return control;
            }

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                foreach (var descendant in GetAllControls(child))
                {
                    yield return descendant;
                }
            }
        }

    }
}
