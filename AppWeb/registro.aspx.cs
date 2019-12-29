using System;
using logicaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

namespace AppWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            

            if (Convert.ToInt32(tbEdad.Text) < 18)
            {
                lblEdad.Visible = true;
            }
            else
            {
                if (tbUsuario.Text == "admin" || tbPass.Text == "admin")
                {
                    lblInfo.Text = "No te puedes registrar con esas credenciales";
                }
                else
                {
                    //inicializamos las clases
                    logicaNegocio.clase c = new logicaNegocio.clase();

                    c.registrarUsuario(tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbUsuario.Text, tbPass.Text);

                    lblInfo.Text = "Te has registrado con exito!!....Redirigiendo....";

                    Thread.Sleep(1500);

                    Response.Redirect("login.aspx");
                }
                
                
            }
            
        }
    }
}