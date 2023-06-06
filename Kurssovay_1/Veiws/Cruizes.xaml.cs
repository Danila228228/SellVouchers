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
    /// Логика взаимодействия для Cruizes.xaml
    /// </summary>
    public partial class Cruizes : Page
    {
        public Cruizes()
        {
            InitializeComponent();

           CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var cruiseFoRemov = CrusesGrid.SelectedItems.Cast<Cruises>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {cruiseFoRemov.Count() } элементов?","Внимание",MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    SellVouchersEntities4.GetContext().Cruises.RemoveRange(cruiseFoRemov);
                    SellVouchersEntities4.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }

        }

        private void RemovClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddbtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCruizes(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCruizes((sender as Button).DataContext as Cruises));
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
           {
              SellVouchersEntities4.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
             CrusesGrid.ItemsSource = SellVouchersEntities4.GetContext().Cruises.ToList();
            }
        }
    }
}
