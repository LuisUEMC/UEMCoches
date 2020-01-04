using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace AccesoDatos
{
    public class funciones
    {
        //Definicion de la cadena de conexion
        SqlConnection conexion = new SqlConnection("user id=root;" +
                                                   "password=;server=localhost;" +
                                                   "Trusted_Connection=yes;" +
                                                   "database=UEMCoches; " +
                                                   "connection timeout=15");

        //funcion que inserta un nuevo usuario des registro, recibe un objeto usuario y lo inserta
        public void insertarRegistro(transversal.usuario nu)
        {
            string cadenaConsulta;
            //abrimos la conexion
            conexion.Open();
            try
            {
                //Formar la sentencia SQL, un INSERT en este caso
                cadenaConsulta = "INSERT INTO usuarios VALUES ('" + nu.GSNombre + "','" + nu.GSApellidos + "'," + nu.GSEdad + ",'" + nu.GSUser + "','" + nu.GSPass + "','" + nu.GSTipo + "')";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);

                //Ejecutar el comando SQL
                myCommand.ExecuteNonQuery();
                //cerramos la conexion
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
            }
        }

        //funcion que devuelve un arraylist de todos los usuarios
        public ArrayList allUsuarios()
        {
            ArrayList usuarios = new ArrayList();
            conexion.Open();
            string cadenaConsulta;
            try
            {
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                cadenaConsulta = "SELECT * FROM usuarios";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();

                //mientras lee los datos los vamos almacenando en el arrayList de tipo usuarios
                while (myReader.Read())
                {
                    usuarios.Add(new transversal.usuario(myReader["nombre"].ToString(), myReader["apellidos"].ToString(), Convert.ToInt32(myReader["edad"].ToString()), myReader["usuario"].ToString(), myReader["pass"].ToString(), Convert.ToInt32(myReader["id"].ToString()), myReader["tipo"].ToString()));
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
            }
            //devolvemos el arraylist de usuarios
            return usuarios;
        }

        //funcion igual que la anterior de allUsuarios pero con todos los vehiculos
        //devolvemos un arraylist de tipo vehiculos
        public ArrayList allVehiculos()
        {
            ArrayList vehiculos = new ArrayList();
            conexion.Open();
            string cadenaConsulta;
            try
            {
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                cadenaConsulta = "SELECT * FROM coches";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();

                //mientras lee los datos los vamos almacenando en el arrayList de tipo vehiculo
                while (myReader.Read())
                {
                    vehiculos.Add(new transversal.vehiculo(myReader["modelo"].ToString(), Convert.ToInt32(myReader["ano"].ToString()), myReader["prestaciones"].ToString(), Convert.ToBoolean(myReader["disponible"].ToString()), myReader["color"].ToString(), Convert.ToInt32(myReader["puertas"].ToString()), myReader["combustible"].ToString(), Convert.ToInt32(myReader["valoracion"].ToString()), Convert.ToDouble(myReader["precio"].ToString()), Convert.ToInt32(myReader["id"].ToString())));
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
            }

            //devolvemos el arraylist
            return vehiculos;
        }

        //funcion que devuelve un solo vehiculo, esta funcion se usa en el aquiler de un vehiculo
        public transversal.vehiculo unVehiculo(int id_vehiculo)
        {
            conexion.Open();
            string cadenaConsulta;
            try
            {
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                cadenaConsulta = "SELECT * FROM coches WHERE id=" + id_vehiculo;
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                  transversal.vehiculo v = new transversal.vehiculo(myReader["modelo"].ToString(), Convert.ToInt32(myReader["ano"].ToString()), myReader["prestaciones"].ToString(), Convert.ToBoolean(myReader["disponible"].ToString()), myReader["color"].ToString(), Convert.ToInt32(myReader["puertas"].ToString()), myReader["combustible"].ToString(), Convert.ToInt32(myReader["valoracion"].ToString()), Convert.ToDouble(myReader["precio"].ToString()), Convert.ToInt32(myReader["id"].ToString()));
                  //devolvemos el vehiculo leido
                  return v;
                }
                conexion.Close();    
            }
            catch (Exception ex)
            {
                conexion.Close();
                return null;
            }
            return null;
        }

        //funcion que inserta un alquiler de un coche, recibe un objeto alquilan y lo inserta, parecido a insertarUsuario
        public void insertarAlquiler(transversal.alquilan al)
        {
            conexion.Close();
            string cadenaConsulta;
            conexion.Open();
            try
            {
                //Formar la sentencia SQL, un INSERT en este caso
                cadenaConsulta = "INSERT INTO alquilan VALUES (" + al.GSidCoche + "," + al.GSidUsuario + ",'" + al.GSfAlquiler + "','" + al.GSfFin + "')";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myCommand.ExecuteNonQuery();

                //cambiamos la disponibilidad del vehiculo para que el vehiculo ya no este disponible
                cadenaConsulta = "UPDATE coches SET disponible = 0 WHERE id=" + al.GSidCoche;
                SqlCommand myCommand2 = new SqlCommand(cadenaConsulta, conexion);
                myCommand2.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
            }
        }

        //funcion que devuelve todos los alquileres de un usuario en forma de arraylist
        public ArrayList allAlquileres(int idu)
        {
            ArrayList alquileres = new ArrayList();
            conexion.Open();
            string cadenaConsulta;
            try
            {
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                cadenaConsulta = "SELECT * FROM alquilan WHERE id_usuario=" + idu;
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();

                //Mostrar los datos de la tabla
                while (myReader.Read())
                {
                    alquileres.Add(new transversal.alquilan(Convert.ToInt32(myReader["id_coche"].ToString()), Convert.ToInt32(myReader["id_usuario"].ToString()), myReader["f_alquiler"].ToString(), myReader["f_fin"].ToString()));
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
            }
            //devolvemos el arraylist de alquileres
            return alquileres;
        }

        //funcion que filtra los resultados de busqueda, un lio de ifs, solo puse 3 filtros
        //para no complicarme mas la vida
        public ArrayList buscarVehiculos(string modelo, string combustible, double precio)
        {
            String cadenaConsulta = null;
            //condiciones de busqueda
            if (modelo != "" && combustible == "" && precio == 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE modelo='" + modelo + "'";
            }else if (modelo != "" && combustible != "" && precio == 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE modelo='" + modelo + "' AND combustible='" + combustible + "'";
            }else if (modelo != "" && combustible != "" && precio != 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE modelo='" + modelo + "' AND combustible='" + combustible + "' AND precio=" + Convert.ToDecimal(precio) + "";
            }else if (modelo == "" && combustible != "" && precio != 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE combustible='" + combustible + "' AND precio=" + Convert.ToDecimal(precio) + "";
            }else if (modelo == "" && combustible == "" && precio != 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE precio=" + Convert.ToDecimal(precio) + "";
            }else if (modelo == "" && combustible != "" && precio == 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE combustible='" + combustible + "'";
            }else if (modelo != "" && combustible == "" && precio != 0)
            {
                cadenaConsulta = "SELECT * FROM coches WHERE modelo='" + modelo + "' AND precio=" + Convert.ToDecimal(precio) + "";
            }
            else
            {
                cadenaConsulta = "SELECT * FROM coches";
            }

            //con la sentencia slq hecha a medida se rellena el arraylist
            ArrayList vehiculos = new ArrayList();
            conexion.Open();
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();

                //rellenamos el arraylist
                while (myReader.Read())
                {
                    vehiculos.Add(new transversal.vehiculo(myReader["modelo"].ToString(), Convert.ToInt32(myReader["ano"].ToString()), myReader["prestaciones"].ToString(), Convert.ToBoolean(myReader["disponible"].ToString()), myReader["color"].ToString(), Convert.ToInt32(myReader["puertas"].ToString()), myReader["combustible"].ToString(), Convert.ToInt32(myReader["valoracion"].ToString()), Convert.ToDouble(myReader["precio"].ToString()), Convert.ToInt32(myReader["id"].ToString())));
                }
                conexion.Close();
            //se devuelve el arraylist
            return vehiculos;
        }

        //funcion que busca a un usuario especifico por su nombre de usuario
        //esta funcion se emplea en el registro para comprobar que no exista ese usuario ya
        public transversal.usuario buscarUsuario (string usuario)
        {
            conexion.Open();
            string cadenaConsulta;
            try
            {
                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                cadenaConsulta = "SELECT * FROM usuarios WHERE usuario='" + usuario + "'";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myReader = myCommand.ExecuteReader();

                //rellenamos el objeto y lo revolvemos
                while (myReader.Read())
                {
                    transversal.usuario usu = new transversal.usuario(myReader["nombre"].ToString(), myReader["apellidos"].ToString(), Convert.ToInt32(myReader["edad"].ToString()), myReader["usuario"].ToString(), myReader["pass"].ToString(), Convert.ToInt32(myReader["id"].ToString()), myReader["tipo"].ToString());
                    return usu;
                }
                
                conexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                conexion.Close();
                return null;
            }
        }

        //funcion que inserta uno o varios vehiculos desde un XML leido/os en la logica de negocio
        //recibe un arraylist y los va insertando segun los lee
        public void insertarVehiculos (ArrayList vehiculos)
        {
            string cadenaConsulta;
            conexion.Open();
            
            for (int i = 0; i < vehiculos.Count; i++)
            {
                transversal.vehiculo ve = (transversal.vehiculo)vehiculos[i];
                cadenaConsulta = "INSERT INTO coches VALUES ('" + ve.GSNombre + "'," + ve.GSAno + ",'" + ve.GSPrestaciones + "','" + ve.GSDisponible + "','" + ve.GSColor + "'," + ve.GSPuertas + ",'" + ve.GSCombustible + "'," + ve.GSValoracion + "," + Convert.ToDecimal(ve.GSPrecio) + ")";
                SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
                myCommand.ExecuteNonQuery();
            }
            conexion.Close();
        }

        //funcion que inserta un solo vehiculo, se usa en la insercion manual
        public void insertarVehiculo(transversal.vehiculo ve)
        {
            string cadenaConsulta;
            conexion.Open();
            
            cadenaConsulta = "INSERT INTO coches VALUES ('" + ve.GSNombre + "'," + ve.GSAno + ",'" + ve.GSPrestaciones + "','" + ve.GSDisponible + "','" + ve.GSColor + "'," + ve.GSPuertas + ",'" + ve.GSCombustible + "'," + ve.GSValoracion + "," + Convert.ToDecimal(ve.GSPrecio) + ")";
            SqlCommand myCommand = new SqlCommand(cadenaConsulta, conexion);
            
            myCommand.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
