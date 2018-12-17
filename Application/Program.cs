using System;
using Sys = System.Windows.Forms;
using Application.classes;

namespace Application
{

	internal sealed class Program
	{

		[STAThread]
		private static void Main(string[] args)
		{
            ClassApplicationBase App = new ClassApplicationBase();

            Sys.Application.EnableVisualStyles();
            Sys.Application.Run(App);
        }

    }
}
