using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class alquilerCoche : System.Web.UI.Page
    {
        logicaNegocio.clase c = new logicaNegocio.clase();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = Request.QueryString["idu"];
            string id_coche = Request.QueryString["idc"];
            if (Request.QueryString["idu"] == null || Request.QueryString["idc"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                transversal.vehiculo v = c.mostrarVehiculo(Convert.ToInt32(id_coche));

                lblTitulo.Text = v.GSNombre;
                lblModelo.Text = v.GSNombre;
                lblColor.Text = v.GSColor;
                lblCombustible.Text = v.GSCombustible;
                lblAno.Text = v.GSAno.ToString();
                lblPrestaciones.Text = v.GSPrestaciones;
                lblPrecio.Text = v.GSPrecio.ToString() + " €";
                lblValoracion.Text = v.GSValoracion.ToString() + " /5";
                lblPuertas.Text = v.GSPuertas.ToString();
                if (v.GSDisponible == true)
                {
                    lblDisponible.Text = "SI";
                    lblDisponible.ForeColor = Color.Green;
                    btnAlquilar.Visible = true;
                }
                else
                {
                    lblDisponible.Text = "NO";
                    lblDisponible.ForeColor = Color.Red;
                    btnAlquilar.Visible = false;
                    lblInfo.Text = "Si no aparece el boton es porque no esta disponible, busca otro vehiculo";
                }
            }  
        }

        protected void btnAlquilar_Click(object sender, EventArgs e)
        {
            string id_usuario = Request.QueryString["idu"];
            string id_coche = Request.QueryString["idc"];
            c.alquilarCoche(Convert.ToInt32(id_coche), Convert.ToInt32(id_usuario), tbFAlquiler.Text, tbFFin.Text);

            lblInfo.Text = "Has alquilado el coche con exito!";
            Thread.Sleep(1500);
            Response.Redirect("home.aspx?idu=" + id_usuario);
        }
    }
}