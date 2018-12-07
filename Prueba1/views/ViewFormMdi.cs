/*
 * Created by SharpDevelop.
 * User: local167
 * Date: 30/11/2018
 * Time: 15:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Prueba1.views;
using Prueba1.controllers;

namespace Prueba1.views
{

	public class ViewFormMdi : ControllerFormMdi
	{
		public ViewFormMdi()
		{
            this.Text = "Aplicación";
			this.IsMdiContainer = true;
			this.WindowState = FormWindowState.Maximized;

            // Eventos.
            var FormLogin = new ViewFormLogin();
            FormLogin.Parent = this;
            FormLogin.Show();
        }
    }
}
