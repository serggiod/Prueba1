using System;
using System.Windows.Forms;
using Application.views;

namespace Application.classes
{
    public class ClassApplicationBase : Form
    {

        public string BasePath;

        public ClassApplicationBase()
        {
            this.BasePath = Environment.CurrentDirectory;

            var form = new ViewFormMdi();
            form.Show();

        }
    }
}
