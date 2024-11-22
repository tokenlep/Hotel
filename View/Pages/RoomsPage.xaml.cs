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
        List<Status> statuses = App.context.Status.ToList();

        public RoomsPage()
        {
            InitializeComponent();

            RoomsLb.ItemsSource = App.context.Room.ToList();

            statuses.Insert(0, new Status { Name = "Все статусы" });
            FilterCmb.ItemsSource = statuses;
            FilterCmb.DisplayMemberPath = "Name";
            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.SelectedIndex = 0;
        }

        private void SaerchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
