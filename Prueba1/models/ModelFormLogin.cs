using System;
using Prueba1.classes;

namespace Prueba1.models
{
    public class ModelFormLogin : ClassDB
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

        protected bool login()
        {
            return true;
        }

        protected bool logout()
        {
            return true;
        }

        protected bool session()
        {
            return true;
        }

        protected void session_start()
        { }

        protected void session_destroy()
        { }
    }
}
