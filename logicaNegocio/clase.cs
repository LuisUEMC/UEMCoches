using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace logicaNegocio
{
    public class clase
    {
        //inicializamos las clases
        AccesoDatos.funciones f = new AccesoDatos.funciones();

        //funcion que registra un nuevo usuario
        public void registrarUsuario(string nombre, string apellidos, int edad, string user, string pass)
        {
            //creamos una clase usuario
            transversal.usuario nuevoUsuario = new transversal.usuario(nombre, apellidos, edad, user, pass, 0, "comun");
            //se la mandamos a AccesoDatos.funciones para que la inserte en la base de datos
            f.insertarRegistro(nuevoUsuario);   
        }

        //funcion que comprueba el login
        public int login(string user, string pass)
        {
            ArrayList usuarios = new ArrayList();
            usuarios = f.allUsuarios();

            for (int i = 0; i<usuarios.Count; i++)
            {
                transversal.usuario usu = (transversal.usuario)usuarios[i];
                if (usu.GSUser == user && usu.GSPass == pass)
                {
                    return usu.GSIdUsuario;
                }
            }
            return 0;
        }

        //funcion que devuelve todos los vehiculos
        public ArrayList mostrarVehiculos()
        {
            ArrayList vehiculos = new ArrayList();
            vehiculos = f.allVehiculos();
            return vehiculos;
        }

        public transversal.vehiculo mostrarVehiculo(int idv)
        {
            transversal.vehiculo v = f.unVehiculo(idv);
            return v;
        }

        public void alquilarCoche(int idc, int idu, string fa, string ff)
        {
            transversal.alquilan a = new transversal.alquilan(idc, idu, fa, ff);
            f.insertarAlquiler(a);
        }

        public ArrayList mostrarAlquileres(int idu)
        {
            ArrayList alquileres = new ArrayList();
            alquileres = f.allAlquileres(idu);
            return alquileres;
        }

        public ArrayList buscarVehiculos(string modelo, string combustible, double precio)
        {
            ArrayList vehiculosBuscados = new ArrayList();
            vehiculosBuscados = f.buscarVehiculos(modelo, combustible, precio);
            return vehiculosBuscados;
        }

    }
}
