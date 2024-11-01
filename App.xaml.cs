using Hotel.Model;
using System.Windows;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Представляет контекст данных взаимодействия с базой данных.
        public static HotelEntities context = new HotelEntities();


        //Представляет собой для хранения пользователя вошедшего в систему.
        public static User currentUser;

    }
}
