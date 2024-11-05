using Hotel.AppData;
using Hotel.Model;
using System;
using System.Linq;
using System.Windows;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            BlockingUserByDate();
        }



        public bool Validation()
        {
            if (string.IsNullOrEmpty(LoginTb.Text) && string.IsNullOrEmpty(PasswordPb.Password))
            {
                Feedback.Warning("Поля для ввода должны быть пустыми. Введите логин и пароль!");
                return false;
            }
            else if (string.IsNullOrEmpty(LoginTb.Text))
            {
                Feedback.Warning("Поле для ввода должно быть пустым. Введите логин!");
                return false;

            }
            else if (string.IsNullOrEmpty(PasswordPb.Password))
            {
                Feedback.Warning("Поле для ввода должно быть пустым. Введите пароль!");
                return false;

            }
            return true;
        }

        public void Authentication()
        {
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTb.Text && user.Password == PasswordPb.Password);

            if (App.currentUser == null)
            {
                Feedback.Error($"Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные!");
            }
            else if (App.currentUser.IsBlocked == true)
            {
                Feedback.Error("Вы заблокированы. Обратитесь к администратору");
            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.ShowDialog();
            }
            else
            {
                
                Feedback.Information("Вы успешно авторизовались!");
                Close();
            }
        }

        public void BlockingUserByDate()
        {
            foreach(var user in App.context.User.Where(u => u.RoleId == 2))
            {
                if(user.RegistrationDate.AddMonths(1) < DateTime.Now.Date && user.IsActivated == false)
                {
                    user.IsBlocked = true;
                }
            }
            App.context.SaveChanges();
        }


        public void Authorization()
        {
            switch(App.currentUser.RoleId)
            {
                case 1: AdministratorWindow administratorWindow = new AdministratorWindow();
                    administratorWindow.Show();
                    break;
                case 2: UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    break;
                default: Feedback.Error("Роль пользователя не найдена! Доступ запрещен.");
                    break;
            }
            Close();

        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                Authentication();
            }
        }
    }
}
