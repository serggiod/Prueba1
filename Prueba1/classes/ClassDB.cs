using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System;

namespace Prueba1.classes
{
    public class ClassDB
    {
        MySqlConnection Connection;
        public ClassDB()
        {
            string c = "Server=localhost;Database=test;User ID=test;Pwd=test;";
            this.Connection = new MySqlConnection(c);
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
                        MessageBox.Show("No se puede conectar al servidor.");
                        break;

                    case 1045:
                        MessageBox.Show("Error en el usuario o el password.");
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
                MessageBox.Show(e.Message);
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

    }
}
