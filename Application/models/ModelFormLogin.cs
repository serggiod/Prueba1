using System.Data;
using Application.classes;

namespace Application.models
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
        public bool loggedin;

        public ModelFormLogin()
        {
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.cuil = string.Empty;
            this.password = string.Empty;
            this.modulel = "admindds";
            this.modulon = string.Empty;
            this.modulod = string.Empty;
            this.estado = 1;
            this.loggedin = false;
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

            string q = string.Empty; 
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

            DataTable usuarios = this.Select(q,"usuario",campos);

            if (usuarios.Rows.Count == 1)
            {
                r = true;
                this.nombre = usuarios.Rows[0]["nombre"].ToString();
                this.apellido = usuarios.Rows[0]["apellido"].ToString();
                this.modulon = usuarios.Rows[0]["mosulon"].ToString();
                this.modulod = usuarios.Rows[0]["modulod"].ToString();
                this.loggedin = true;
            }

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
