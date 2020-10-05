using System.Linq;
using System.Windows;

namespace Medidea
{
    public partial class InsertReception : Window
    {
        ReceptionsEntities _db = new ReceptionsEntities();
        public InsertReception()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                Receptions newReception = new Receptions()
                {
                    DateReception = ReceptionDatePicker.SelectedDate,
                    TypeReception = TypeComboBox.Text,
                    Diagnosis = DiagnosisTextBox.Text
                };
                _db.Receptions.Add(newReception);
                _db.SaveChanges();
                Receptions.datagrid.ItemsSource = _db.Receptions.ToList();
                this.Hide();
            //}
            //catch (System.Exception)
            //{

            //    MessageBox.Show("Проверьте корректность сохраняемых данных", "Внимание", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}

        }
    }
}
