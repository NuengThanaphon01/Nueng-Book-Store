using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for FromCustomer.xaml
    /// </summary>
    public partial class FromCustomer : Window
    {
        public FromCustomer()
        {
            InitializeComponent();
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }
        }


        class Item
        {
            public string Id { get; set; }
            public string name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }

        }
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            if (txtcusName.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการเพิ่มข้อมูลลูกค้า" + "\n" + "ชื่อลูกค้า : " + txtcusName.Text, "ยืนยันการเพิ่มข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Insert.AddDatacus("Customers", txtcusName.Text, txtaddress.Text, txtemail.Text);
                    List<Item> listdata = new List<Item>();
                    using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
                    {
                        db.Open();

                        SqliteCommand selectCommand = new SqliteCommand
                            ("SELECT * from Customers", db);

                        SqliteDataReader query = selectCommand.ExecuteReader();

                        while (query.Read())
                        {
                            listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) });
                        }

                        dataGrid.ItemsSource = listdata;
                        db.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ชื่อลูกค้า", "เพิ่มข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            string serch = txtserch.Text;
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers where Customer_Id like " + "'%" + serch + "%'" +
                    " or Customer_Name like" + "'%" + serch + "%'"
                    + " or Email like" + "'%" + serch + "%'", db);
                //selectCommand.Parameters.AddWithValue("@serch", serch);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }
        }

        private void btnremove_Click(object sender, RoutedEventArgs e)
        {
            if (txtcusid.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการลบลูกค้า" + "\n" + "รหัสลูกค้า : " + txtcusid.Text, "ยืนยันการลบข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Del.RemoveDataCus("Customers", txtcusid.Text);
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสลูกค้า", "ลบข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtcusid.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการอัพเดทข้อมูล" + "\n" + "ชื่อลูกค้า : " + txtcusName.Text, "ยืนยันการอัพเดทข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Update.UpdatedataCus("Customers", txtcusid.Text, txtcusName.Text, txtaddress.Text, txtemail.Text);
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสลูกค้า", "อัพเดทข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnre_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("รัเฟรชข้อมูล", "รีเฟรชข้อมูล", MessageBoxButton.OK);
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Address = query.GetString(2), Email = query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            fromMenu fromMenu1 = new fromMenu();
            fromMenu1.Show();
            this.Close();
        }

    }
}
