using Hotel.AppData;
using Hotel.Model;
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
    /// Логика взаимодействия для RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        List<Category> categories = App.context.Category.ToList();

        public RoomsPage()
        {
            InitializeComponent();

            RoomsLb.ItemsSource = App.context.Room.ToList();

            categories.Insert(0, new Category { Name = "Все статусы" });
            FilterCmb.ItemsSource = categories;
            FilterCmb.DisplayMemberPath = "Name";
            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.SelectedIndex = 0;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FilterCmb.SelectedIndex != 0)
            {
                RoomsLb.ItemsSource = App.context.Room.Where(r => r.CategoryId == FilterCmb.SelectedIndex).ToList();
            }
            else
            {
                RoomsLb.ItemsSource = App.context.Room.ToList();
            }
            //RoomsByStatusCountTbl.Text = CountRoomsByStatus();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(SearchTb.Text))
            {
                try
                {
                    int roomNumber = Convert.ToInt32(SearchTb.Text);
                    RoomsLb.ItemsSource = App.context.Room.Where(r => r.Number == roomNumber).ToList();
                }
                catch(FormatException exception)
                {
                    Feedback.Error($"{exception.Message} Используйте числовые символы для поиска.");
                }
                catch(Exception exception)
                {
                    Feedback.Error(exception.Message);
                }
            }
            else
            {
                RoomsLb.ItemsSource = App.context.Room.ToList();
            }
        }

        private void RoomsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BookingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //public string CountRoomsByStatus()
        //{

        //}
    }
}
