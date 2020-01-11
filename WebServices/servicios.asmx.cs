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
            ArrayList vehiculos = c.mostrarVehiculos();
            List<vehiculo> vehiculos2 = new List<vehiculo>(vehiculos.Count);
            for (int i=0; i<vehiculos.Count; i++)
            {
                vehiculo ve = (vehiculo)vehiculos[i];
                vehiculos2.Add(new vehiculo(ve.GSNombre, ve.GSAno, ve.GSPrestaciones, ve.GSDisponible, ve.GSColor, ve.GSPuertas, ve.GSCombustible, ve.GSValoracion, ve.GSPrecio, ve.GSIdVehiculo));
            }

            return vehiculos2;
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
            ArrayList alquileres = c.mostrarAlquileres(idu);
            List<alquilan> alquileres2 = new List<alquilan>(alquileres.Count);
            for (int i = 0; i < alquileres.Count; i++)
            {
                alquilan al = (alquilan)alquileres[i];
                alquileres2.Add(new alquilan(al.GSidCoche, al.GSidUsuario, al.GSfAlquiler, al.GSfFin));
            }

            return alquileres2;
        }

        [WebMethod]
        public List<vehiculo> WSBuscarVehiculos(string modelo, string combustible, double precio)
        {
            ArrayList vehiculos = c.buscarVehiculos(modelo, combustible, precio);
            List<vehiculo> vehiculos2 = new List<vehiculo>(vehiculos.Count);
            for (int i = 0; i < vehiculos.Count; i++)
            {
                vehiculo ve = (vehiculo)vehiculos[i];
                vehiculos2.Add(new vehiculo(ve.GSNombre, ve.GSAno, ve.GSPrestaciones, ve.GSDisponible, ve.GSColor, ve.GSPuertas, ve.GSCombustible, ve.GSValoracion, ve.GSPrecio, ve.GSIdVehiculo));
            }

            return vehiculos2;
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
