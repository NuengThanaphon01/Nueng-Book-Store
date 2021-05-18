using Microsoft.Data.Sqlite;
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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Window
    {
        public Book()
        {
            InitializeComponent();
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Detail = query.GetString(2), Price =  query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }

        }
        class Item
        {
            public string Id { get; set; }
            public string name { get; set; }
            public string Detail { get; set; }
            public string Price { get; set; }

        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            if (txtbookname.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการเพิ่มข้อมูลหนังสือ" + "\n" + "ชื่อหนังสือ : " + txtbookname.Text, "ยืนยันการเพิ่มข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Insert.AddDatabook("Books", txtbookname.Text, txtbookdetail.Text, int.Parse(txtprice.Text));
                    List<Item> listdata = new List<Item>();
                    using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
                    {
                        db.Open();

                        SqliteCommand selectCommand = new SqliteCommand
                            ("SELECT * from Books", db);

                        SqliteDataReader query = selectCommand.ExecuteReader();

                        while (query.Read())
                        {
                            listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Detail = query.GetString(2), Price = query.GetString(3) });
                        }

                        dataGrid.ItemsSource = listdata;
                        db.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ชื่อหนังสือ", "เพิ่มข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnmove_Click(object sender, RoutedEventArgs e)
        {
            if (txtbookid.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการลบหนังสือ" + "\n" + "รหัสหนังสือ : " + txtbookid.Text, "ยืนยันการลบข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Del.RemoveDataBook("Books", txtbookid.Text);
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสหนังสือ", "ลบข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtbookid.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("ยืนยันการอัพเดทข้อมูล" + "\n" + "ชื่อหนังสือ : " + txtbookname.Text, "ยืนยันการอัพเดทข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Update.UpdatedataBook("Books", txtbookid.Text, txtbookname.Text, txtbookdetail.Text, int.Parse(txtprice.Text));
                }
            }
            else 
            {
                MessageBox.Show("กรุณาใส่รหัสหนังสือ", "อัพเดทข้อมูลผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("รัเฟรชข้อมูล", "รีเฟรชข้อมูล", MessageBoxButton.OK);
            InitializeComponent();
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Detail = query.GetString(2), Price = query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string serch = txtserch.Text;
            List<Item> listdata = new List<Item>();
            using (SqliteConnection db = new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books where ISBN like " + "'%" + serch + "%'" +
                    " or Title like" + "'%" + serch + "%'"
                    + " or Price like" + "'%" + serch + "%'", db);
                //selectCommand.Parameters.AddWithValue("@serch", serch);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listdata.Add(new Item { Id = query.GetString(0), name = query.GetString(1), Detail = query.GetString(2), Price = query.GetString(3) });
                }

                dataGrid.ItemsSource = listdata;
                db.Close();
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            fromMenu fromMenu = new fromMenu();
            fromMenu.Show();
            this.Close();
        }
    }
}
