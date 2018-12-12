using System.Configuration;
using MySql.Data.MySqlClient;

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
            try
            {
                this.Connection.Open();
                return true;
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
                return false;
            }

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
        }

        public List <string> [] Select(string q)
        {
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.Connection;

                MySqlDataReader reader = cmd.ExecuteReader();

                List<string>[] list = new List<string>[reader.FieldCount];
                /*
string query = "SELECT * FROM tableinfo";

    //Create a list to store the result
    List< string >[] list = new List< string >[3];
    list[0] = new List< string >();
    list[1] = new List< string >();
    list[2] = new List< string >();

    //Open connection
    if (this.OpenConnection() == true)
    {
        //Create Command
        MySqlCommand cmd = new MySqlCommand(query, connection);
        //Create a data reader and Execute the command
        MySqlDataReader dataReader = cmd.ExecuteReader();
        
        //Read the data and store them in the list
        while (dataReader.Read())
        {
            list[0].Add(dataReader["id"] + "");
            list[1].Add(dataReader["name"] + "");
            list[2].Add(dataReader["age"] + "");
        }

        //close Data Reader
        dataReader.Close();

        //close Connection
        this.CloseConnection();

        //return list to be displayed
        return list;
    }
    else
    {
        return list;
    }               
                */

            }
        }
    }
}
