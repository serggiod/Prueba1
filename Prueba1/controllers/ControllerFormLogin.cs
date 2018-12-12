using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using Prueba1.models;

namespace Prueba1.controllers
{
    public class ControllerFormLogin : Form
	{
        protected Point StartLocation;
        protected Label LblTitle;
        protected Label LblAlert;
        protected Label LblUsr;
        protected Label LblPass;
        protected TextBox TxbUsr;
        protected TextBox TxbPass;
        protected Button BtnAcept;
        protected ModelFormLogin Model;

        public ControllerFormLogin() {

            this.Width = 400;
            this.Height = 190;
            this.StartLocation = new Point(0, 0);
            this.SetTopLevel(false);

            //Components.
            this.LblTitle = new Label();
            this.LblAlert = new Label();
            this.LblUsr = new Label();
            this.LblPass = new Label();
            this.TxbUsr = new TextBox();
            this.TxbPass = new TextBox();
            this.BtnAcept = new Button();
            this.Model = new ModelFormLogin();

            // Controls.
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblAlert);
            this.Controls.Add(this.LblUsr);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.TxbUsr);
            this.Controls.Add(this.TxbPass);
            this.Controls.Add(this.BtnAcept);

            //Events.
            this.Move += this.EventMove;
            this.FormClosing += this.EventClose;

            this.BtnAcept.Click += this.EventClick;

            this.TxbUsr.Enter += this.EventTxbUsrEnter;
            this.TxbUsr.KeyPress += this.EventTxbUsrKeyPress;

            this.TxbPass.Enter += this.EventTxbPassEnter;
            this.TxbPass.KeyPress += this.EventTxbPassKeyPress;
        }
		private void EventMove(Object s, EventArgs a)
		{
			this.Location = this.StartLocation;
		}
        private void EventTxbUsrEnter(object s, EventArgs a)
		{
			this.TxbUsr.Text = "";
            this.LblAlert.Text = "INFO: Todos los campos son obligatorios.";
			this.LblAlert.BackColor = Color.SkyBlue;
		}
        private void EventTxbUsrKeyPress(Object s, KeyPressEventArgs k)
        {
            if (char.IsControl(k.KeyChar) || char.IsDigit(k.KeyChar) || k.KeyChar.ToString() == "-") k.Handled = false;
            else k.Handled = true;
        }
		private void EventTxbPassEnter(Object s, EventArgs a)
		{
			this.TxbPass.Text = "";
            this.LblAlert.Text = "INFO: Todos los campos son obligatorios.";
			this.LblAlert.BackColor = Color.SkyBlue;
		}
        private void EventTxbPassKeyPress(Object s, KeyPressEventArgs k)
        {
            if (char.IsDigit(k.KeyChar) || char.IsLetter(k.KeyChar) || char.IsControl(k.KeyChar)) k.Handled = false;
            else k.Handled = true;
        }
        private void EventClick(Object s, EventArgs a)
        {
            if (this.TxbUsr.Text == "" || this.TxbPass.Text == "")
            {
                this.LblAlert.BackColor = Color.LightPink;
                this.LblAlert.Text = "ERROR: Todos los campos son obligatorios.";
            }
            else
            {
                Regex regc = new Regex("\\d{2}-\\d{7,8}-\\d{1}");
                Regex regp = new Regex("(\\d\\w){8,18}");

                MatchCollection mcregc = regc.Matches(this.TxbUsr.Text);
                MatchCollection mcregp = regp.Matches(this.TxbPass.Text);

                if (mcregc.Count > 0 && mcregp.Count > 0) this.Close();
                else
                {
                    this.LblAlert.BackColor = Color.LightPink;
                    this.LblAlert.Text = "ERROR: El usuario o el password son incorrectos.";
                }
            }
        }
        private void EventClose(Object s, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
