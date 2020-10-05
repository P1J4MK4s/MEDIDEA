using System.Linq;
using System.Windows;

namespace Medidea
{
    public partial class UpdateReception : Window
    {
        ReceptionsEntities _db = new ReceptionsEntities();
        int Id;
        public UpdateReception(int ReceptionId)
        {
            InitializeComponent();
            Id = ReceptionId;
            Receptions updateReception = (from p in _db.Receptions
                                          where p.IdReception == Id
                                          select p).Single();
            ReceptionDatePicker.SelectedDate = updateReception.DateReception;
            TypeComboBox.Text = updateReception.TypeReception;
            DiagnosisTextBox.Text = updateReception.Diagnosis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Receptions updateReception = (from p in _db.Receptions
                                              where p.IdReception == Id
                                              select p).Single();
                updateReception.DateReception = ReceptionDatePicker.SelectedDate;
                updateReception.TypeReception = TypeComboBox.Text;
                updateReception.Diagnosis = DiagnosisTextBox.Text;
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
