using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kurssovay_1.Bases;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для AddCruizes.xaml
    /// </summary>
    public partial class AddCruizes : Page
    {
        private Cruises _currentCruize = new Cruises();
        public AddCruizes(Cruises selectedCruises)
        {
            InitializeComponent();
            if (selectedCruises != null)
            {
                _currentCruize = selectedCruises;
            }
            DataContext = _currentCruize;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(_currentCruize.route_))
                    errors.AppendLine("Укажите тур");

                if (_currentCruize.cost_ < 0)
                    errors.AppendLine("Укажите цену");

                if (string.IsNullOrWhiteSpace(_currentCruize.date_start.ToString()))
                    errors.AppendLine("Укажите дату начала тура");

                if (string.IsNullOrWhiteSpace(_currentCruize.date_finish.ToString()))
                    errors.AppendLine("Укажите дату окончания тура");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (_currentCruize.id_cruises == 0)
                    SellVouchersEntities4.GetContext().Cruises.Add(_currentCruize);

                MessageBox.Show(SellVouchersEntities4.GetContext().ChangeTracker.HasChanges().ToString());
                SellVouchersEntities4.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }


        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
