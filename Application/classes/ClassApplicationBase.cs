using System;
using System.Windows.Forms;

namespace Application.classes
{
    public class ClassApplicationBase : Form
    {
        public ClassLog Log;

        public ClassApplicationBase()
        {

            // Components.
            this.Log = new ClassLog();

        }
    }
}
