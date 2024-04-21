using OrderManager.ViewModel;
using System.Windows;
namespace OrderManager.View
{
    public partial class Create : Window
    {
        public Create()
        {
            OrderVM orderVM = new OrderVM();
            DataContext = orderVM;
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        //Zavření okna
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Akce po kliknutí levým tlačítkem
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

