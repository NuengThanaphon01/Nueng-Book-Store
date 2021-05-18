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

namespace BookshopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        fromMenu fromMenu = new fromMenu();
        public MainWindow()
        {

            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtusername.Text == "ADMIN" || txtusername.Text == "admin")
            {
                if (passwordBox.Password == "123456")
                {
                    MessageBoxResult result = MessageBox.Show("ล็อคอินสำเร็จ", "สำเร็จ", MessageBoxButton.OK);

                    if (result == MessageBoxResult.OK)
                    {
                        fromMenu.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("โปรดเช็คพาสเวิร์ดของท่าน", "พาสเวิร์ดผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else 
            {
                MessageBox.Show("ไม่มี Username นี้ในระบบ", "Username ผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtusername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtusername.Text = "";
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = "";
        }
    }
}
