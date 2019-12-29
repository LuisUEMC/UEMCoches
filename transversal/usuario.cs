using System;
using System.Collections.Generic;
using System.Text;

namespace transversal
{
    public class usuario
    {
        private string nombre;
        private string apellidos;
        private int edad;
        private string user;
        private string pass;
        private string tipo;
        private int id_usuario;

        public usuario(string nombre, string apellidos, int edad, string user, string pass, int id_usuario, string tipo)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.user = user;
            this.pass = pass;
            this.id_usuario = id_usuario;
            this.tipo = tipo;
        }

        public string GSNombre
        {
            get{return this.nombre;}
            set{this.nombre = value;}
        }
        public string GSApellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }
        public int GSEdad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public string GSUser
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public string GSPass
        {
            get { return this.pass; }
            set { this.pass = value; }
        }
        public string GSTipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        public int GSIdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }
    }
}

