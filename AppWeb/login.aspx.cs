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

            logicaNegocio.clase c = new logicaNegocio.clase();
            int id_usuario;
            id_usuario = c.login(tbUsuario.Text, tbPass.Text);
            if (id_usuario == 0)
            {
                lblInfo.Text = "No estas registrado o has introducido credenciales incorrectas";
            }
            else
            {
                lblInfo.Text = "Te has loggeado con exito";
                Response.Redirect("home.aspx?idu=" + id_usuario);
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }
    }
}