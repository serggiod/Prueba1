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

namespace Prueba1.views
{

	public class FormMdi : Form
	{
		public FormMdi()
		{

			this.Text = "Aplicación";
			this.IsMdiContainer = true;
			this.WindowState = FormWindowState.Maximized;

			// Eventos.
			this.Shown += EventShown;
			
		}
		
		private void EventShown(Object s,EventArgs a)
		{
			var FormLogin = new FormLogin(this);
			FormLogin.Show();
		}
	}
}
