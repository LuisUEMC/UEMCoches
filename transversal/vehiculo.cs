using System;
using System.Collections.Generic;
using System.Text;

namespace transversal
{
    [Serializable]
    public class vehiculo
    {
        private string modelo;
        private int ano;
        private string prestaciones;
        private bool disponible;
        private string color;
        private int puertas;
        private string combustible;
        private int valoracion;
        private double precio;
        private int id_vehiculo;
        private string resultado;

        public vehiculo()
        {

        }
        public vehiculo(string modelo, int ano, string prestaciones, bool disponible, string color, int puertas,
            string combustible, int valoracion, double precio, int id_vehiculo)
        {
            this.modelo = modelo;
            this.ano = ano;
            this.prestaciones = prestaciones;
            this.disponible = disponible;
            this.color = color;
            this.puertas = puertas;
            this.combustible = combustible;
            this.valoracion = valoracion;
            this.precio = precio;
            this.id_vehiculo = id_vehiculo;
            resultado = "";
        }


        public string GSNombre
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public int GSAno
        {
            get { return this.ano; }
            set { this.ano = value; }
        }
        public string GSPrestaciones
        {
            get { return this.prestaciones; }
            set { this.prestaciones = value; }
        }
        public bool GSDisponible
        {
            get { return this.disponible; }
            set { this.disponible = value; }
        }
        public string GSColor
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public int GSPuertas
        {
            get { return this.puertas; }
            set { this.puertas = value; }
        }
        public string GSCombustible
        {
            get { return this.combustible; }
            set { this.combustible = value; }
        }
        public int GSValoracion
        {
            get { return this.valoracion; }
            set { this.valoracion = value; }
        }
        public double GSPrecio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public int GSIdVehiculo
        {
            get { return this.id_vehiculo; }
            set { this.id_vehiculo = value; }
        }

        public string Disponible()
        {
            if (this.disponible == true)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }

        public string mostrarCaracteristicas()
        {
            return "</br>------------------------------------------" +
                   "</br>Disponible: " + Disponible() +
                   "</br>Modelo: " + GSNombre +
                   "</br>Año: " + GSAno +
                   "</br>Color: " + GSColor +
                   "</br>Puertas: " + GSPuertas +
                   "</br>Combustible: " + GSCombustible +
                   "</br></br>Valoracion: " + GSValoracion + "/5" +
                   "</br>Precio: " + GSPrecio + " €" +
                   "</br></br>Prestaciones:</br>" + GSPrestaciones +
                   "</br></br>";
        }

    }
}
