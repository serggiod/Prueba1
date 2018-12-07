using System;
using System.Drawing;
using System.Windows.Forms;
using Prueba1.controllers;

namespace Prueba1.views
{
    public class ViewFormLogin : ControllerFormLogin
    {
        //public ViewFormLogin(ViewFormMdi parent)
        public ViewFormLogin()
        {
            // Icons.
            Image ikeyg = Image.FromFile("imgs/key.png");
            Image iaccept = Image.FromFile("./icons/accept.png");

            //Propiedades.
            this.LblTitle.Location = new Point(0, 0);
            this.LblTitle.Width = 400;
            this.LblTitle.Height = 40;
            this.LblTitle.BackColor = Color.White;
            this.LblTitle.Padding = new Padding(15);
            this.LblTitle.Image = ikeyg.GetThumbnailImage(40, 40, null, IntPtr.Zero);
            this.LblTitle.ImageAlign = ContentAlignment.MiddleLeft;
            this.LblTitle.Text = "Autheticar";
            this.LblTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.LblAlert.Location = new Point(0, 40);
            this.LblAlert.Width = 400;
            this.LblAlert.Height = 20;
            this.LblAlert.Text = "INFO: Todos los campos son obligatorios.";
            this.LblAlert.TextAlign = ContentAlignment.MiddleCenter;
            this.LblAlert.BackColor = Color.SkyBlue;

            this.lblUsr.Location = new Point(35, this.LblAlert.Location.Y + LblAlert.Height + 3);
            this.lblUsr.Text = "Usuario:";
            this.lblUsr.Width = 100;

            this.LblPass.Location = new Point(35, this.lblUsr.Location.Y + this.lblUsr.Height + 3);
            this.LblPass.Text = "Passowd:";
            this.lblUsr.Width = 100;

            this.TxbUsr.Location = new Point(this.lblUsr.Location.X + this.lblUsr.Width + 10, this.lblUsr.Location.Y);
            this.TxbUsr.Width = 200;
            this.TxbUsr.TabIndex = 1;
            this.TxbUsr.TextAlign = HorizontalAlignment.Center;
            this.TxbUsr.MaxLength = 13;
            this.TxbUsr.Focus();

            this.TxbPass.Location = new Point(this.TxbUsr.Location.X, this.TxbUsr.Location.Y + this.TxbUsr.Height + 3);
            this.TxbPass.Width = 200;
            this.TxbPass.TabIndex = 2;
            this.TxbPass.TextAlign = HorizontalAlignment.Center;
            this.TxbPass.MaxLength = 18;
            this.TxbPass.PasswordChar = '*';

            this.BtnAcept.Location = new Point(this.TxbPass.Location.X + 100, this.TxbPass.Location.Y + this.TxbPass.Height + 3);
            this.BtnAcept.Width = 100;
            this.BtnAcept.Height = 30;
            this.BtnAcept.TabIndex = 3;
            this.BtnAcept.TabStop = true;
            this.BtnAcept.Padding = new Padding(5);
            this.BtnAcept.Text = "Ingresar";
            this.BtnAcept.TextAlign = ContentAlignment.MiddleRight;
            this.BtnAcept.Image = iaccept;
            this.BtnAcept.ImageAlign = ContentAlignment.MiddleLeft;

            // Form
            var screen = Screen.PrimaryScreen.WorkingArea;
            var x = (screen.Width / 2) - (this.width / 2);
            var y = (screen.Height / 2) - (this.height / 2);

            this.Width = this.width;
            this.Height = this.height;
            this.Text = "Autenticar";
            //this.Icon = iconApp;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.StartLocation.X = x;
            this.StartLocation.Y = y;
            this.Location = this.StartLocation;
            this.AcceptButton = this.BtnAcept;

            // Controls.
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblAlert);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.TxbUsr);
            this.Controls.Add(this.TxbPass);
            this.Controls.Add(this.BtnAcept);
        }
    }
}