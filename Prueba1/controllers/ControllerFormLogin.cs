/*
 * Created by SharpDevelop.
 * User: local167
 * Date: 1/12/2018
 * Time: 00:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*

Ejemplo de código fuente para implementar
el diseño de un formulario en lenguaje WPF:xaml.

<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.AWindow"
    Title="Window with Button"
    Width="250" Height="100">

  <!-- Add button to window -->
  <Button Name="button" Click="button_Click">Click Me!</Button>

</Window>

Ejemplo de código fuente para 
la implementacón de Clases en C#
con formulario diseñados en xaml.

using System.Windows; // Window, RoutedEventArgs, MessageBox 

namespace SDKSample
{
    public partial class AWindow : Window
    {
        public AWindow()
        {
            // InitializeComponent call is required to merge the UI 
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}


*/
using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using Prueba1.models;

namespace Prueba1.controllers
{
    public class ControllerFormLogin : Form
	{
        protected Point StartLocation = new Point(0, 0);
        protected int width = 400;
        protected int height = 190;
        protected Label LblTitle = new Label();
        protected Label LblAlert = new Label();
        protected Label lblUsr = new Label();
        protected Label LblPass = new Label();
        protected TextBox TxbUsr = new TextBox();
        protected TextBox TxbPass = new TextBox();
        protected Button BtnAcept = new Button();
        protected ModelFormLogin Model = new ModelFormLogin();

        public ControllerFormLogin() {

            this.SetTopLevel(false);
            this.Model.example();

            //Events.
            this.Move += this.EventMove;
            this.Resize += this.EventResize;
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
	    private void EventResize(Object s, EventArgs a)
		{
			this.Width = this.width;
			this.Height = this.height;
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
    }
}
