using System.Linq;
using System.Windows;

namespace Medidea
{
    public partial class UpdatePatient : Window
    {
        ReceptionsEntities _db = new ReceptionsEntities();
        int Id;
        public UpdatePatient(int patientId)
        {
            InitializeComponent();
            Id = patientId;
            Patient updatePatient = (from p in _db.Patient
                                     where p.IdPatient == Id
                                     select p).Single();
            FIOTextBox.Text = updatePatient.FIO;
            PolComboBox.Text = updatePatient.Pol;
            DataDatePicker.SelectedDate = updatePatient.DateOfBirth;
            AdressTextBox.Text = updatePatient.Adress;
            PhoneTextBox.Text = updatePatient.Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient updatePatient = (from p in _db.Patient
                                         where p.IdPatient == Id
                                         select p).Single();
                updatePatient.FIO = FIOTextBox.Text;
                updatePatient.Pol = PolComboBox.Text;
                updatePatient.DateOfBirth = DataDatePicker.SelectedDate;
                updatePatient.Adress = AdressTextBox.Text;
                updatePatient.Phone = PhoneTextBox.Text;
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.Patient.ToList();
                this.Hide();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Проверьте корректность сохраняемых данных", "Внимание", MessageBoxButton.OK, MessageBoxImage.Exclamation); throw;
            }

        }
    }
}
