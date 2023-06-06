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
    /// Логика взаимодействия для AdminPassword.xaml
    /// </summary>
    public partial class AdminPassword : Page
    {
        public AdminPassword()
        {
            InitializeComponent();
        }

        private void AdminPas_Click(object sender, RoutedEventArgs e)
        {
            Accounts CurrentUser = Connects.db.Accounts.FirstOrDefault(u => u.login_ == logAdmin.Text && u.password_ == pasAdmin.Password);
            if (CurrentUser != null)
            {   if(CurrentUser.id_account==1 && CurrentUser.password_ == "1111")
                {
                    Session.UserId = CurrentUser.id_account;
                NavigationService.Navigate(new WelcomPage());
                }
               else
               {
                MessageBox.Show("Данного ADMINA нет в базе");
                logAdmin.Text = "";
                pasAdmin.Password = "";
               }
            }
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
