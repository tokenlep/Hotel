using Hotel.AppData;
using Hotel.Model;
using Hotel.View.Windows;
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

namespace Hotel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersListPage.xaml
    /// </summary>
    public partial class UsersListPage : Page
    {
        const int USER_ROLE_ID = 2;
        public UsersListPage()
        {
            
            InitializeComponent();
            // Загрузка пользователей в список при открытии страницы 
            UsersLv.ItemsSource = App.context.User.Where(u => u.RoleId == USER_ROLE_ID).ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            if(userWindow.ShowDialog() == true)
            {
                UsersLv.ItemsSource = App.context.User.ToList();
            }
        }

        private void UsersLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDetailsGrid.DataContext = UsersLv.SelectedItem as User;
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();
            Feedback.Information("Информация успшно сохранена !");
        }
    }
}
