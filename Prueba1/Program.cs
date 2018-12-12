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
			var formm = new ViewFormMdi();

			Application.EnableVisualStyles();
            Application.Run(formm);
        }

    }
}
