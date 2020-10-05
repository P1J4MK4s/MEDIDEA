using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Medidea
{

    public partial class Receptions : Window
    {
        PatientsEntities _db = new PatientsEntities();
        public static DataGrid datagrid;
        public Receptions()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            try
            {
                ReceptionsGrid.ItemsSource = _db.Receptions.ToList();
                datagrid = ReceptionsGrid;
            }
            catch (System.Exception)
            {
                 MessageBox.Show("Отсутсвует соединение с базой", "Внимание", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertReception Ipage = new InsertReception();
            Ipage.ShowDialog();
        }

        private void updatetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (ReceptionsGrid.SelectedItem as Receptions).IdReception;
                UpdateReception Upage = new UpdateReception(Id);
                Upage.ShowDialog();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Нельзя изменить пустое поле", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
            int Id = (ReceptionsGrid.SelectedItem as Receptions).IdReception;
            var deletePatient = _db.Receptions.Where(p => p.IdReception == Id).Single();
            _db.Receptions.Remove(deletePatient);
            _db.SaveChanges();
            ReceptionsGrid.ItemsSource = _db.Receptions.ToList();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Нельзя удалить пустое поле", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
