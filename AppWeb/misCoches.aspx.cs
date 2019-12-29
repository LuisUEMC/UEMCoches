using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class misCoches : System.Web.UI.Page
    {
        logicaNegocio.clase c = new logicaNegocio.clase();
        protected void Page_Load(object sender, EventArgs e)
        {
            String id_usuario = Request.QueryString["idu"];
            if (Request.QueryString["idu"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                ArrayList alquileres = new ArrayList();
                alquileres = c.mostrarAlquileres(Convert.ToInt32(id_usuario));

                List<Label> labels = new List<Label>();

                for (int i = 0; i<alquileres.Count; i++)
                {
                    transversal.alquilan al = (transversal.alquilan)alquileres[i];

                    //label
                    Label lblAlquileres = new Label();
                    lblAlquileres.Text = "</br>------------------------------------" +
                                     "</br>ID del Vehiculo: " + al.GSidCoche +
                                     "</br>Fecha de Alquiler del coche: " + al.GSfAlquiler +
                                     "</br>Fecha de Finalizacion del alquiler: " + al.GSfFin + "</br>";
                    labels.Add(lblAlquileres);

                    Panel1.Controls.Add(labels[i]);
                }
            }
        }
    }
}