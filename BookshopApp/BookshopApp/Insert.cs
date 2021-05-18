using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshopApp
{

    class Insert
    {
        public static void AddDatacus(string table,string cusname, string address, string email)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO " + table +" (Customer_Name, Address, Email) VALUES (@cusName, @Address, @Email);";
                insertCommand.Parameters.AddWithValue("@cusName", cusname);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@Email", email);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static void AddDatabook(string table, string title, string descrip,int price)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO " + table + " (Title, Description, Price) VALUES (@title, @descrip, @price);";
                insertCommand.Parameters.AddWithValue("@title", title);
                insertCommand.Parameters.AddWithValue("@descrip", descrip);
                insertCommand.Parameters.AddWithValue("@price", price);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static void AddDataTran(string table, string isbn, string cusid, int quatity, int total)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=SQLBOOK.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO " + table + " (ISBN, Customer_Id, Quatity, Total_Price ) VALUES (@idbook, @idcus, @qua, @total);";
                insertCommand.Parameters.AddWithValue("@idbook", isbn);
                insertCommand.Parameters.AddWithValue("@idcus", cusid);
                insertCommand.Parameters.AddWithValue("@qua", quatity);
                insertCommand.Parameters.AddWithValue("@total", total);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
    }
}
