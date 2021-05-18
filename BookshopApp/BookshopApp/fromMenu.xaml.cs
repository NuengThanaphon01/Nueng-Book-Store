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

namespace BookshopApp
{
    /// <summary>
    /// Interaction logic for fromMenu.xaml
    /// </summary>
    public partial class fromMenu : Window
    {
        FromCustomer fromCustomer = new FromCustomer();
        Book book = new Book();
        FromTransactions fromTransactions = new FromTransactions();
        public fromMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            fromCustomer.Show();
            this.Close();
        }

        private void btnbook_Click(object sender, RoutedEventArgs e)
        {
            book.Show();
            this.Close();
        }

        private void btnorder_Click(object sender, RoutedEventArgs e)
        {
            fromTransactions.Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("ยืนยันการออกจากระบบ", "ออกจากระบบ", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("ออกจากระบบเสร็จสิ้น", "ออกจากระบบ", MessageBoxButton.OK);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

        }
    }
}
