using System;
using MySql.Data.MySqlClient;

namespace Prueba1.models
{
    public class ModelBase
    {

        protected MySqlConnection Connect = new MySqlConnection();

        public ModelBase()
        {

        }

        public void example()
        {
            //ConectionString Connect = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            //MySqlCommand mycmd = new MySqlCommand("select * from boletin", this.Connect);


            //MySqlDataReader result = mycmd.ExecuteReader();

            //while (result.Read()) Console.WriteLine("Resultado: user: " + result["bol_num"].ToString() + " y host:" + result["bol_ani"].ToString());

            //result.Close();
            //mycmd.Dispose();

            //this.Connect.Close();
        }

        public void open()
        { }

        public void close()
        { }
    }
}
