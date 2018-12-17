using System.Windows.Forms;
using Application.controllers;

namespace Application.views
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
