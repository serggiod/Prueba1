using System;

namespace Prueba1.models
{
    public class ModelFormLogin : ModelBase
    {
        private string nombre;
        private string apellido;
        private string cuil;
        private string password;
        private string modulon;
        private string modulod;
        private int estado;

        public ModelFormLogin()
        {
            this.nombre = "";
            this.apellido = "";
            this.cuil = "";
            this.password = "";
            this.modulon = "";
            this.modulod = "";
            this.estado = 1;
        }

        private bool login()
        {
            return true;
        }

        private bool logout()
        {
            return true;
        }

        private bool session()
        {
            return true;
        }

        private void session_start()
        { }

        private void session_destroy()
        { }

    }
}
