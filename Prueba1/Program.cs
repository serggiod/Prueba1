/*
 * Created by SharpDevelop.
 * User: local167
 * Date: 30/11/2018
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Prueba1.views;

namespace Prueba1
{

	internal sealed class Program
	{

		[STAThread]
		private static void Main(string[] args)
		{
			var formm = new FormMdi();

            string dsn = "Server=127.0.0.1;Database=mysql;User ID=test;Password=test;Pooling=false;";

            string query = "select * from user";

            MySqlConnection con = new MySqlConnection(dsn);
            con.Open();

            MySqlCommand mycmd = new MySqlCommand(query, con);

            MySqlDataReader result = mycmd.ExecuteReader();

            while (result.Read()) Console.WriteLine("Resultado: user: " + result["User"].ToString() + " y host:" + result["Host"].ToString());

            result.Close();
            mycmd.Dispose();
            con.Close();

			Application.EnableVisualStyles();
			
			Application.Run(formm);
		}
		
	}
}
