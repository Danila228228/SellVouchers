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
    /// Логика взаимодействия для Sing1Page.xaml
    /// </summary>
    public partial class Sing1Page : Page
    {
        public Sing1Page()
        {
            InitializeComponent();
            

        }
        public int id_account;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Accounts CurrentUser = Connects.db.Accounts.FirstOrDefault(u => u.login_ == Login.Text && u.password_ == Password.Password);
            if (CurrentUser != null) 
            {
                if (CurrentUser.id_account != 1) 
                { 
                Session.UserId = CurrentUser.id_account;
                NavigationService.Navigate(new WelcomeUserPage());
                }
            }
            else 
            {
                MessageBox.Show("Данного пользователя нет в базе");
                Login.Text = "";
                Password.Password = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPassword());
        }
    }
}
