using System.Data;
using Application.classes;
using Application.@struct;

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

        public DataResponse Login()
        {
            string sql = string.Empty; 
            sql += "SELECT ";
            sql += " jp.per_nombres nombre, ";
            sql += " jp.per_apellidos apellido, ";
            sql += " m.modname modulon, ";
            sql += " m.moddesc modulod ";
            sql += "FROM ";
            sql += " modules m ";
            sql += "INNER JOIN ";
            sql += " usermod um ON um.modid = m.id ";
            sql += "INNER JOIN ";
            sql += " usuarios u ON u.id = um.userid ";
            sql += "INNER JOIN ";
            sql += " jujuy_usuarios ju ON ju.per_cuil = u.per_cuil ";
            sql += "INNER JOIN ";
            sql += " jujuy_personas jp ON jp.per_cuil = ju.per_cuil ";
            sql += "WHERE ";
            sql += " m.modlink = '" + this.modulel + "' ";
            sql += " AND ju.per_cuil = '" + this.cuil + "' ";
            sql += " AND ju.usu_pass = '" + this.password + "' ";
            sql += " AND u.estado = " + this.estado;
            sql += " AND ju.usu_estado = " + this.estado;

            DataResponse response = this.Select(sql);

            if (response.result == true)
            {
                if (response.rows.Rows.Count == 1)
                {
                    this.nombre = response.rows.Rows[0]["nombre"].ToString();
                    this.apellido = response.rows.Rows[0]["apellido"].ToString();
                    this.modulon = response.rows.Rows[0]["mosulon"].ToString();
                    this.modulod = response.rows.Rows[0]["modulod"].ToString();
                    this.loggedin = true;
                }
            }
            return response;
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
