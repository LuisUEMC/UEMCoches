using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //mandamos el usuario y contraseña a la logica de negocio para que lo valide
            WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();
            int id_usuario;
            id_usuario = ws.WSLogin(tbUsuario.Text, tbPass.Text);
            //primera comprobacion de usuario inexistente
            if (id_usuario == 0)
            {
                lblInfo.Text = "No estas registrado o has introducido credenciales incorrectas";
            }
            else
            {
                //segunda comprobacion para que no pueda logearse un usuario de tipo admin
                WSServicios.usuario usu = ws.WSBuscarUsuario(tbUsuario.Text);
                if (usu.GSTipo != "comun")
                {
                    lblInfo.Text = "Aqui no puedes entrar como administrador";
                }
                else
                {
                    //finalmente el loggin correcto
                    lblInfo.Text = "Te has loggeado con exito";
                    Response.Redirect("home.aspx?idu=" + id_usuario);
                }

                
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }
    }
}