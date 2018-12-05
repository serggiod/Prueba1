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
using System.Drawing;
using System.Windows.Forms;
using Prueba1.views;

namespace Prueba1.views
{

	public class FormLogin : Form
	{
		private Point StartLocation = new Point(0,0);
		private int width = 400;
		private int height = 190;
		
		private Label LblTitle = new Label();
		private Label LblAlert = new Label();
		private Label lblUsr = new Label();
		private Label LblPass = new Label();
		private TextBox TxbUsr = new TextBox();
		private TextBox TxbPass = new TextBox();
		private Button BtnAcept = new Button();
			
		public FormLogin(FormMdi parent)
		{
			// Base.
			var screen = Screen.PrimaryScreen.WorkingArea;
			var x = (screen.Width /2) -(this.width /2);
			var y = (screen.Height /2) -(this.height /2);
			this.StartLocation.X = x;
			this.StartLocation.Y = y;
			
			// Icons.
			Image ikeyg   = Image.FromFile("imgs/key.png");
			Image iaccept = Image.FromFile("./icons/accept.png");
			
			//Propiedades.
			this.LblTitle.Location = new Point(0,0);
			this.LblTitle.Width = 400;
			this.LblTitle.Height = 40;
			this.LblTitle.BackColor = Color.White;
			this.LblTitle.Padding = new Padding(15);
			this.LblTitle.Image = ikeyg.GetThumbnailImage(40,40,null,IntPtr.Zero);
			this.LblTitle.ImageAlign = ContentAlignment.MiddleLeft;
			this.LblTitle.Text = "Autheticar";
			this.LblTitle.TextAlign = ContentAlignment.MiddleCenter;
				
			this.LblAlert.Location = new Point(0,40);
			this.LblAlert.Width = 400;
			this.LblAlert.Height = 20;
			this.LblAlert.Text = "INFO: Todos los campos son obligatorios.";
			this.LblAlert.TextAlign = ContentAlignment.MiddleCenter;
			this.LblAlert.BackColor = Color.SkyBlue;
			
			this.lblUsr.Location = new Point(35,this.LblAlert.Location.Y +LblAlert.Height +3);
			this.lblUsr.Text = "Usuario:";
			this.lblUsr.Width = 100;
			
			this.LblPass.Location = new Point(35, this.lblUsr.Location.Y +this.lblUsr.Height + 3);
			this.LblPass.Text = "Passowd:";
			this.lblUsr.Width = 100;
			
			this.TxbUsr.Location = new Point(this.lblUsr.Location.X +this.lblUsr.Width + 10, this.lblUsr.Location.Y);
			this.TxbUsr.Width = 200;
			this.TxbUsr.TabIndex = 1;
			this.TxbUsr.TextAlign = HorizontalAlignment.Center;
            this.TxbUsr.MaxLength = 13;
            this.TxbUsr.Focus();
			
			this.TxbPass.Location = new Point(this.TxbUsr.Location.X, this.TxbUsr.Location.Y +this.TxbUsr.Height + 3);
			this.TxbPass.Width = 200;
			this.TxbPass.TabIndex = 2;
			this.TxbPass.TextAlign = HorizontalAlignment.Center;
            this.TxbPass.MaxLength = 18;
            this.TxbPass.PasswordChar = '*';
			
			this.BtnAcept.Location = new Point(this.TxbPass.Location.X +100, this.TxbPass.Location.Y +this.TxbPass.Height +3);
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
			this.Width = this.width;
			this.Height = this.height;
			this.Text = "Autenticar";
			this.MdiParent = parent;
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.ControlBox = false;
			this.Location = this.StartLocation;
			this.AcceptButton = this.BtnAcept;
			
			// Controls.
			this.Controls.Add(this.LblTitle);
			this.Controls.Add(LblAlert);
			this.Controls.Add(this.lblUsr);
			this.Controls.Add(this.LblPass);
			this.Controls.Add(this.TxbUsr);
			this.Controls.Add(this.TxbPass);
			this.Controls.Add(this.BtnAcept);
				
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
        private void EventTxbUsrKeyPress(Object s, KeyPressEventArgs a)
        {

            //if(char.IsControl() || char.Is
        }
		private void EventTxbPassEnter(Object s, EventArgs a)
		{
			this.TxbPass.Text = "";
            this.LblAlert.Text = "INFO: Todos los campos son obligatorios.";
			this.LblAlert.BackColor = Color.SkyBlue;
		}
        private void EventTxbPassKeyPress(Object s, KeyPressEventArgs a)
        {
        
        }
        private void EventClick(Object s, EventArgs a)
        {
            if (this.TxbUsr.Text == "" || this.TxbPass.Text == "")
            {
                this.LblAlert.BackColor = Color.LightPink;
                this.LblAlert.Text = "ERROR: Todos los campos son obligatorios.";
            }
        }
    }
}
