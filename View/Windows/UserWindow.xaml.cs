using Hotel.AppData;
using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void AddUaerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

     public void AddUser()
     {
            try
            {
                if (string.IsNullOrEmpty(FullnameTb.Text) || string.IsNullOrEmpty(LoginTb.Text) ||
                    string.IsNullOrEmpty(PasswordPb.Password))
                {
                    Feedback.Warning("Все поля обязательно для заполнения ! Заполните каждое поле !");
                }

                else
                        {
                            User newUser = new User()
                            {
                                Fullname = FullnameTb.Text,
                                Login = LoginTb.Text,
                                Password = PasswordPb.Password,
                                RegistrationDate = DateTime.Now.Date,
                                IsActivated = false,
                                IsBlocked = false,
                                RoleId = 2
                            };

                            App.context.User.Add(newUser);
                            App.context.SaveChanges();

                            Feedback.Information("Пользователь успешно добавлен !");

                            DialogResult = true;
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                Feedback.Error($"Пользователь с таким логином уже существует. Придумайте новый. {dbUpdateException.Message}");
            }
            catch (Exception exception)
            {
                Feedback.Error($"Ошибка при добавлении пользователя. {exception.Message}");
            }
            
      }


    }
}
