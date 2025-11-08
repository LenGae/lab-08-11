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
using System.Windows.Shapes;
using WpfApp8.ViewModels;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public ViewModel m;
        public Users()
        {
            InitializeComponent();
            m = new();
            DataContext = m;
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser();
            window.Show();
        }

        private void DelUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
