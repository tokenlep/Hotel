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

        }

        void  ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPasswordPb.Password) ||
                string.IsNullOrEmpty(NewPasswordPb.Password) ||
                string.IsNullOrEmpty(AcceptNewPasswordPb.Password))
            {
                Feedback.Warning("Все поля обязательны для заполнения ! Заполните каждое поле !");
            }
        }
    }
}
