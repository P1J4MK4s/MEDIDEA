using System.Windows;

namespace Medidea
{
    public partial class StartedWindow : Window
    {
        public StartedWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Receptions receptions = new Receptions();
            receptions.ShowDialog();
        }
    }
}
