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
using System.Windows.Shapes;
using Kurssovay_1.Bases;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для ChooseCabinWindow.xaml
    /// </summary>
    public partial class ChooseCabinWindow : Window
    {
        private Cabins _currentCabin;
        public int CabinId { get { return _currentCabin.id_cabins; } }

        public ChooseCabinWindow(Cruises selectedCruise)
        {
            InitializeComponent();
            DataContext = selectedCruise;
            var cabinsToSelect = SellVouchersEntities4.GetContext().Cabins.ToList();
            CabinsGrid.ItemsSource = cabinsToSelect.Where(c => c.id_ships == selectedCruise.id_ships && c.count_places > 0).ToList();
        }   

        private void BtnChooseCabin_Click(object sender, RoutedEventArgs e)
        {
            Cabins SelectedCabin = CabinsGrid.SelectedItem as Cabins;
            _currentCabin = SelectedCabin;
            SelectedCabin.count_places = SelectedCabin.count_places - 1;
            this.DialogResult = true;
        }
    }
}
