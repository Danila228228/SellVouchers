using Kurssovay_1.Bases;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VouchersGrid.ItemsSource = SellVouchersEntities4.GetContext().Vouchers.Where(v => v.id_clients == Session.UserId).ToList();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var VoucherToRemove = VouchersGrid.SelectedItem as Vouchers;

            if (MessageBox.Show($"Вы точно хотите вернуть билет?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    VoucherToRemove.Cabins.count_places += 1;
                    SellVouchersEntities4.GetContext().Vouchers.Remove(VoucherToRemove);
                    SellVouchersEntities4.GetContext().SaveChanges();
                    MessageBox.Show("Билет возвращен");
                    VouchersGrid.ItemsSource = SellVouchersEntities4.GetContext().Vouchers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
