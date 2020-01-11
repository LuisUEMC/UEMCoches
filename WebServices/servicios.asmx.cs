using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Xml.Linq;
using transversal;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class servicios : System.Web.Services.WebService
    {
        logicaNegocio.clase c = new logicaNegocio.clase();

        [WebMethod]
        public void WSRegistrarUsuario(string nombre, string apellidos, int edad, string user, string pass)
        {
            c.registrarUsuario(nombre, apellidos, edad, user, pass);
        }

        [WebMethod]
        public int WSLogin (string user, string pass)
        {
            return c.login(user, pass);
        }

        [WebMethod]
        public List<vehiculo> WSMostrarVehiculos()
        {
            List<vehiculo> vehiculos = c.mostrarVehiculos();
            return vehiculos;
        }

        [WebMethod]
        public transversal.vehiculo WSMostrarVehiculo(int idv)
        {
            return c.mostrarVehiculo(idv);
        }

        [WebMethod]
        public void WSAlquilarCoche(int idc, int idu, string fa, string ff)
        {
            c.alquilarCoche(idc, idu, fa, ff);
        }

        [WebMethod]
        public List<alquilan> WSMostrarAlquileres(int idu)
        {
            List<alquilan> alquileres = c.mostrarAlquileres(idu);
            return alquileres;
        }

        [WebMethod]
        public List<vehiculo> WSBuscarVehiculos(string modelo, string combustible, double precio)
        { 
            List<vehiculo> vehiculos = c.buscarVehiculos(modelo, combustible, precio);
            return vehiculos;
        }

        [WebMethod]
        public transversal.usuario WSBuscarUsuario(string usuario)
        {
            return c.buscarUsuario(usuario);
        }

        [WebMethod]
        public void WSguardarCochesXML()
        {
            c.guardarCochesXML();
        }

        [WebMethod]
        public void WSguardarCochesBD(string fileName)
        {
            c.guardarCochesBD(fileName);
        }

        [WebMethod]
        public void WSGuardarVehiculo(string modelo, int ano, string prestaciones, string color, int puertas, string combustible, int valoracion, double precio)
        {
            c.guardarVehiculo(modelo, ano, prestaciones, color, puertas, combustible, valoracion, precio);
        }
    }
}
