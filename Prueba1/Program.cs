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

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            con.Open();

            //MySqlCommand mycmd = new MySqlCommand("select * from boletin", con);

            //MySqlDataReader result = mycmd.ExecuteReader();

            //while (result.Read()) Console.WriteLine("Resultado: user: " + result["bol_num"].ToString() + " y host:" + result["bol_ani"].ToString());

            //result.Close();
            //mycmd.Dispose();
            con.Close();

			Application.EnableVisualStyles();
			
			Application.Run(formm);
		}

    }
}
