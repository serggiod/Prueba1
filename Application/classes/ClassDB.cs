using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Application.classes
{
    public class ClassDB
    {
        MySqlConnection Connection;
        public ClassDB()
        {
            string s = "Server=127.0.0.1; database=test; UID=test; password=test;";
            this.Connection = new MySqlConnection(s);
        }

        public bool Open()
        {
            bool r = false;
            try
            {
                this.Connection.Open();
                r = true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("ERROR: No se puede conectar al servidor.");
                        break;

                    case 1045:
                        Console.WriteLine("ERROR: Error en el usuario o el password.");
                        break;
                }
                r = false;
            }

            return r;

        }

        public bool Close()
        {
            try
            {
                this.Connection.Close();
                return true;
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Insert(string q)
        {
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.Connection;
                cmd.ExecuteNonQuery();
                return this.Close();
            }
            else return false;
        }

        public bool Update(string q)
        {
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.Connection;
                cmd.ExecuteNonQuery();
                return this.Close();
            }
            else return false;
        }

        public bool Delete(string q)
        {
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.Connection;
                cmd.ExecuteNonQuery();
                return this.Close();
            }
            else return false;
        }

        public DataTable Select(string q, string n, string[] f)
        {
            DataTable table = new DataTable(n);

            for(int i=0; i<f.Length; i++)
            {
                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = f[i];
                table.Columns.Add(column);
            }

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.Connection;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < f.Length; i++) row[f[i]] = reader.GetString(i);
                    table.Rows.Add(row);
                }
                reader.Dispose();
                 
                this.Connection.Close();

            }

            return table;
        }

        public string ToMD5(string s)
        {
            string r = string.Empty;

            if (this.Open())
            {
                string q = string.Empty;
                q += "SELECT ";
                q += " MD5('" + s + "') AS md5";

                MySqlCommand cmd = new MySqlCommand(q,this.Connection);
                cmd.CommandText = q;
                cmd.Connection = this.Connection;

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) r = reader["md5"].ToString();
                reader.Dispose();

                this.Close();
            }

            return r;
        }
    }
}
