using System.Data;
using System.Windows.Forms;
using Prueba1.classes;

namespace Prueba1.models
{
    public class ModelFormLogin : ClassDB
    {
        private string nombre;
        private string apellido;
        private string cuil;
        private string password;
        private string modulel;
        private string modulon;
        private string modulod;
        private int estado;

        public ModelFormLogin()
        {
            this.nombre = "";
            this.apellido = "";
            this.cuil = "";
            this.password = "";
            this.modulel = "admindds";
            this.modulon = "";
            this.modulod = "";
            this.estado = 1;
        }

        public void SetCuil(string c)
        {
            this.cuil = c; 
        }

        public void SetPassword(string p)
        {
            this.password = p;
        }

        public bool Login()
        {
            bool r = false;

            string q = ""; 
            q += "SELECT ";
            q += " jp.per_nombres nombre, ";
            q += " jp.per_apellidos apellido, ";
            q += " m.modname modulon, ";
            q += " m.moddesc modulod ";
            q += "FROM ";
            q += " modules m ";
            q += "INNER JOIN ";
            q += " usermod um ON um.modid = m.id ";
            q += "INNER JOIN ";
            q += " usuarios u ON u.id = um.userid ";
            q += "INNER JOIN ";
            q += " jujuy_usuarios ju ON ju.per_cuil = u.per_cuil ";
            q += "INNER JOIN ";
            q += " jujuy_personas jp ON jp.per_cuil = ju.per_cuil ";
            q += "WHERE ";
            q += " m.modlink = '" + this.modulel + "' ";
            q += " AND ju.per_cuil = '" + this.cuil + "' ";
            q += " AND ju.usu_pass = '" + this.password + "' ";
            q += " AND u.estado = " + this.estado;
            q += " AND ju.usu_estado = " + this.estado;

            string[] campos = new string[] {
                "nombre",
                "apellido",
                "modulon",
                "modulod"
            };

            DataTable tusuario = this.Select(q,"usuario",campos);

            MessageBox.Show(tusuario.ToString());

            return r;
        }

        public bool Logout()
        {
            return true;
        }

        public bool Session()
        {
            return true;
        }

        public void SessionStart()
        { }

        public void SessionDestroy()
        { }
    }
}
