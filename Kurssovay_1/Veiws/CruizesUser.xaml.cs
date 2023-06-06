using Kurssovay_1.Bases;
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

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для CruizesUser.xaml
    /// </summary>
    public partial class CruizesUser : Page
    {
        public Cabins cabins = new Cabins();
        public CruizesUser()
        {
            InitializeComponent();
            CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();
            //Des
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
            //Navigate//(new DescriptionPage());
            
            Cruises SelectedCruize = CrusesGrid.SelectedItem as Cruises;

            ChooseCabinWindow chooseCabinWindow = new ChooseCabinWindow((sender as Button).DataContext as Cruises);
            Vouchers voucher = new Vouchers();
            if (chooseCabinWindow.ShowDialog() == true)
            {
                voucher.id_clients = Session.UserId;
                voucher.id_ships = SelectedCruize.id_ships;
                voucher.id_cruises = SelectedCruize.id_cruises;
                voucher.id_cabins = chooseCabinWindow.CabinId;

                if (voucher.id_vouchers == 0)
                {
                    SellVouchersEntities4.GetContext().Vouchers.Add(voucher);
                }

                try
                {
                    SellVouchersEntities4.GetContext().SaveChanges();
                    MessageBox.Show("Вы приобрели билет");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Чтобы оформить билет надо обязательно выбрать кабину!");
            }
       
        }

        private void Page_Loaded1(object sender, RoutedEventArgs e)
        {
            CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
