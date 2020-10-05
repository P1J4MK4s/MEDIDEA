using System.Linq;
using System.Windows;

namespace Medidea
{
    public partial class InsertPatient : Window
    {
        ReceptionsEntities _db = new ReceptionsEntities();
        public InsertPatient()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient newPatient = new Patient()
                {
                    FIO = FIOTextBox.Text,
                    Pol = PolComboBox.Text,
                    DateOfBirth = DateDatePicker.SelectedDate,
                    Adress = AdressTextBox.Text,
                    Phone = PhoneTextBox.Text
                };
                _db.Patient.Add(newPatient);
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.Patient.ToList();
                this.Hide();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Проверьте корректность сохраняемых данных", "Внимание", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
