using System;
using System.Collections.Generic;
using System.Text;

namespace transversal
{
    public class alquilan
    {
        private int id_coche;
        private int id_usuario;
        private string f_alquiler;
        private string f_fin;

        public alquilan()
        {

        }
        public alquilan(int id_coche, int id_usuario , string f_alquiler, string f_fin)
        {
            this.id_coche = id_coche;
            this.id_usuario = id_usuario;
            this.f_alquiler = f_alquiler;
            this.f_fin = f_fin;
        }

        public int GSidCoche
        {
            get { return this.id_coche; }
            set { this.id_coche = value; }
        }
        public int GSidUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }
        public string GSfAlquiler
        {
            get { return this.f_alquiler; }
            set { this.f_alquiler = value; }
        }
        public string GSfFin
        {
            get { return this.f_fin; }
            set { this.f_fin = value; }
        }

    }
}
