using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;

namespace AppWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //boton del registro de un nuevo usuario
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            //comprobamos que la edad no sea menor de 18 años
            if (Convert.ToInt32(tbEdad.Text) < 18)
            {
                lblEdad.Visible = true;
            }
            else
            {
                //evitamos que el usuario se pueda registrar como administrador
                if (tbUsuario.Text == "admin" || tbPass.Text == "admin")
                {
                    lblInfo.Text = "No te puedes registrar con esas credenciales";
                }
                else
                {
                    //comprobamos que el nombre de usuario ya existe llamando a la funcion que busca un usuario
                    //en funcion de su nombre de usuario
                    WSServicios.usuario usu = ws.WSBuscarUsuario(tbUsuario.Text);

                    //si devuelve null es que no existe con lo cual se registra con exito
                    if (usu == null)
                    {
                        //inicializamos las clases
                        WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();

                        ws.WSRegistrarUsuario(tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbUsuario.Text, tbPass.Text);

                        lblInfo.Text = "Te has registrado con exito!!....Redirigiendo....";

                        Thread.Sleep(1500);

                        Response.Redirect("login.aspx");
                    }
                    //si no es null, es que el usuario si existe (pequeño chiste)
                    else
                    {
                        lblInfo.Text = "Nombre de usuario repetido, prueba con: " + usu.GSUser + "123";
                    }
                    
                }
                
                
            }
            
        }
    }
}