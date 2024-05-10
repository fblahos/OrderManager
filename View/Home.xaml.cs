using System.Windows;



namespace OrderManager.View
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        //Searching textBox visibility
        private void textBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            textBlockSearch.Visibility = Visibility.Hidden;
        }

        //Close window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Maximized window
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        //Minimize window
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                this.DragMove();
            }
        }

    }
}