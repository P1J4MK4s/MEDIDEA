using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Medidea
{
    public partial class MainWindow : Window
    {
        PatientsEntities _db = new PatientsEntities();

        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
            {
                Patients.ItemsSource = _db.Patient.ToList();
                datagrid = Patients;
            }
            catch (System.Exception)
            {

                MessageBox.Show("Отсутсвует соединение с базой", "Внимание", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPatient Ipage = new InsertPatient();
            Ipage.ShowDialog();
        }

        private void updatetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (Patients.SelectedItem as Patient).IdPatient;
                UpdatePatient Upage = new UpdatePatient(Id);
                Upage.ShowDialog();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Нельзя изменить пустое поле", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Id = (Patients.SelectedItem as Patient).IdPatient;
                var deletePatient = _db.Patient.Where(p => p.IdPatient == Id).Single();
                _db.Patient.Remove(deletePatient);
                _db.SaveChanges();
                Patients.ItemsSource = _db.Patient.ToList();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Нельзя удалить пустое поле","Внимание",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }
    }
}
