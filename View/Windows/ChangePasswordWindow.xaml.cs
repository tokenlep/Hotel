using Hotel.AppData;
using System.Windows;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }

        void  ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPasswordPb.Password) ||
                string.IsNullOrEmpty(NewPasswordPb.Password) ||
                string.IsNullOrEmpty(AcceptNewPasswordPb.Password))
            {
                Feedback.Warning("Все поля обязательны для заполнения ! Заполните каждое поле !");
            }
            else if (OldPasswordPb.Password != NewPasswordPb.Password)
            {
                Feedback.Error("Неверно введён текущий пароль! Попробуйте снова.");
            }
            else if (NewPasswordPb.Password != AcceptNewPasswordPb.Password)
            {
                Feedback.Error("Новые пароли не совподают ! Попробуйте снова.");
            }
            else if (OldPasswordPb.Password == NewPasswordPb.Password)
            {
                Feedback.Error("Старый и новый пароль совпадают ! Придумайте новый пароль.");
            }
            else
            {
                App.currentUser.Password = NewPasswordPb.Password;
                App.currentUser.IsActivated = true;
                App.context.SaveChanges();

                Feedback.Information("Пароль успешно изменен !");
                
                Close();
            }
        }
    }
}
