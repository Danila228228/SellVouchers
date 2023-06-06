using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Kurssovay_1.Bases;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для WelcomeUserPage.xaml
    /// </summary>
    public partial class WelcomeUserPage : Page
    {
        public WelcomeUserPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



        private void UsersData_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUser());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CruizesUser());
        }
    }
}
