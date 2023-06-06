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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        
        public AddUserPage( )
        {
            InitializeComponent();
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            Accounts accounts = new Accounts();
            if (Connects.db.Accounts.Count(x => x.login_ == Login.Text) > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                Login.Text = "";
                Password.Password = "";
            }
            else
            {
               accounts.login_ = Login.Text;
               accounts.password_ = Password.Password;
                if (Login.Text.Length > 0) // проверяем логин
{
                    if (Password.Password.Length > 0) // проверяем пароль
                    {
                        Connects.db.Clients.Add(clients);

                        try
                        {
                            StringBuilder errors = new StringBuilder();
                            if (string.IsNullOrWhiteSpace(Surname.Text))
                                errors.AppendLine("Укажите фамилию");
                            if (string.IsNullOrWhiteSpace(Name.Text))
                                errors.AppendLine("Укажите имя");
                            
                                if (errors.Length > 0)
                                {
                                    MessageBox.Show(errors.ToString());
                                    return;
                                }
                                if (clients.id_clients == 0) 
                                {
                               
                                    clients.surname_ = Surname.Text; // добавляем фамилию
                                    clients.name_ = Name.Text; // добавляем имя
                             
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        
                        
                         Connects.db.Accounts.Add(accounts);
                         _ = Connects.db.SaveChanges();
                        MessageBox.Show("Пользователь добавлен");
                    }
                    else MessageBox.Show("Укажите пароль");
                }
                else MessageBox.Show("Укажите логин");

            }
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sing1Page());
        }
    }
}
