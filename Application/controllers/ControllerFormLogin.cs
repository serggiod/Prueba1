using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using Application.models;

namespace Application.controllers
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
                string pass = this.Model.ToMD5(this.TxbPass.Text);
                if (string.IsNullOrEmpty(pass) || pass == "d41d8cd98f00b204e9800998ecf8427e")
                {
                    this.LblAlert.BackColor = Color.LightPink;
                    this.LblAlert.Text = "ERROR: El usuario o el passoword son incoreectos.";
                }
                else
                {
                    this.Model.SetCuil(this.TxbUsr.Text);
                    this.Model.SetPassword(this.TxbPass.Text);

                    if (this.Model.Login() == true)
                    {
                        Console.WriteLine("Te has logueado.");
                        this.LblAlert.BackColor = Color.LightGreen;
                        this.LblAlert.Text = "OK: El usuario se ha logueado en el systema.";
                    }

                    else
                    {
                        Console.WriteLine("No te has logueado."); 
                        this.LblAlert.BackColor = Color.LightPink;
                        this.LblAlert.Text = "ERROR: El usuario o el passoword son incoreectos.";
                    }

                }
            }
        }
        private void EventClose(Object s, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
