using System;
using Sys = System.Windows.Forms;
using Application.views;

namespace Application
{

	internal sealed class Program
	{

		[STAThread]
		private static void Main(string[] args)
		{
            ViewFormMdi form = new ViewFormMdi();

            Sys.Application.EnableVisualStyles();
            Sys.Application.Run(form);
        }

    }
}
