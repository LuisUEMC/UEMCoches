using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace logicaNegocio
{
    public class clase
    {
        //inicializamos las funciones de la capa acceso a datos
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
            //creamos un arrayList de vehiculos, los cargamos desde la funcion de acceso a datos y los devolvemos
            ArrayList vehiculos = new ArrayList();
            vehiculos = f.allVehiculos();
            return vehiculos;
        }

        //funcion que devuelve un solo vehiculo en funcion de su id
        public transversal.vehiculo mostrarVehiculo(int idv)
        {
            transversal.vehiculo v = f.unVehiculo(idv);
            return v;
        }

        //funcion que gestiona el alquiler de un coche
        public void alquilarCoche(int idc, int idu, string fa, string ff)
        {
            //recibe el id_usuario, id_coche, fecha_actual y fecha_final
            transversal.alquilan a = new transversal.alquilan(idc, idu, fa, ff);
            f.insertarAlquiler(a);
        }

        //funcion que muestra los alquileres nuestros
        public ArrayList mostrarAlquileres(int idu)
        {
            ArrayList alquileres = new ArrayList();
            alquileres = f.allAlquileres(idu);
            return alquileres;
        }

        //funcion que se encarga del filtro de vehiculos para el usuario
        public ArrayList buscarVehiculos(string modelo, string combustible, double precio)
        {
            ArrayList vehiculosBuscados = new ArrayList();
            vehiculosBuscados = f.buscarVehiculos(modelo, combustible, precio);
            return vehiculosBuscados;
        }

        //funcion que busca a un solo usuario, se usa para comprobar logins y registros indeseados
        public transversal.usuario buscarUsuario (string usuario)
        {
            transversal.usuario usu = f.buscarUsuario(usuario);
            if (usu == null)
            {
                return null;
            }
            else
            {
                return usu; 
            }
        }

        //funcion que guarda los vehiculos en un XML
        public void guardarCochesXML()
        {
            //llamamos a la funcion que nos devuelve todos los coches
            ArrayList vehiculos = new ArrayList();
            vehiculos = mostrarVehiculos();

            //creacion del documento xml
            XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement nodoRaiz = new XElement("raiz");

            for (int i = 0; i < vehiculos.Count; i++)
            {
                transversal.vehiculo ve = (transversal.vehiculo)vehiculos[i];

                XElement vehiculo = new XElement("vehiculo");

                XElement modelo = new XElement("modelo", ve.GSNombre);
                vehiculo.Add(modelo);
                XElement ano = new XElement("ano", ve.GSAno);
                vehiculo.Add(ano);
                XElement prestaciones = new XElement("prestaciones", ve.GSPrestaciones);
                vehiculo.Add(prestaciones);
                XElement disponible = new XElement("disponible", ve.GSDisponible);
                vehiculo.Add(disponible);
                XElement color = new XElement("color", ve.GSColor);
                vehiculo.Add(color);
                XElement puertas = new XElement("puertas", ve.GSPuertas);
                vehiculo.Add(puertas);
                XElement combustible = new XElement("combustible", ve.GSCombustible);
                vehiculo.Add(combustible);
                XElement valoracion = new XElement("valoracion", ve.GSValoracion);
                vehiculo.Add(valoracion);
                XElement precio = new XElement("precio", ve.GSPrecio);
                vehiculo.Add(precio);
                XElement id = new XElement("id", ve.GSIdVehiculo);
                vehiculo.Add(id);

                nodoRaiz.Add(vehiculo);

            }
            documento.Add(nodoRaiz);
            documento.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\vehiculos.xml");

        }

        //funcion que lee los vehiculos del xml seleccionado y se los manda a la capa AccesoDatos
        //para su insercion en la base de datos
        public void guardarCochesBD(string fileName)
        {
            ArrayList vehiculos = new ArrayList();
            if (File.Exists(fileName))
            {
                XDocument documento = XDocument.Load(fileName);
                var raiz = from r in documento.Descendants("raiz") select r;

                foreach (XElement vehiculo in raiz.Elements("vehiculo"))
                {
                    string modelo = vehiculo.Element("modelo").Value;
                    int ano = Convert.ToInt32(vehiculo.Element("ano").Value);
                    string prestaciones = vehiculo.Element("prestaciones").Value;
                    bool disponible = Convert.ToBoolean(vehiculo.Element("disponible").Value);
                    string color = vehiculo.Element("color").Value;
                    int puertas = Convert.ToInt32(vehiculo.Element("puertas").Value);
                    string combustible = vehiculo.Element("combustible").Value;
                    int valoracion = Convert.ToInt32(vehiculo.Element("valoracion").Value);
                    double precio = Convert.ToDouble(vehiculo.Element("precio").Value);
                    int id = Convert.ToInt32(vehiculo.Element("id").Value);

                    vehiculos.Add(new transversal.vehiculo(modelo, ano, prestaciones, disponible, color, puertas, combustible, valoracion, precio, id));
                }

                AccesoDatos.funciones f = new AccesoDatos.funciones();
                f.insertarVehiculos(vehiculos);
            }
        }

        //funcion que crea una clase vehiculo con los datos de la insercion manual y se la manda a la capa
        //acceso a datos para la insercion de un solo vehiculo
        public void guardarVehiculo(string modelo, int ano, string prestaciones, string color, int puertas, string combustible, int valoracion, double precio)
        {
            transversal.vehiculo ve = new transversal.vehiculo(modelo, ano, prestaciones, true, color, puertas, combustible, valoracion, precio, 0);
            f.insertarVehiculo(ve);
        }
    }
}
