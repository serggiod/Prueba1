﻿/*
 * Created by SharpDevelop.
 * User: local167
 * Date: 30/11/2018
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Prueba1.views;

namespace Prueba1
{

	internal sealed class Program
	{

		[STAThread]
		private static void Main(string[] args)
		{
			var formm = new FormMdi();
			
			Application.EnableVisualStyles();
			
			Application.Run(formm);
		}
		
	}
}
