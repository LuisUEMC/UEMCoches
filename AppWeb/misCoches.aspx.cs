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
        //inicializamos a las funciones de la logica de negocio
        WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //comprobamos que se ha hecho el login, si no redirigimos
            String id_usuario = Request.QueryString["idu"];
            if (Request.QueryString["idu"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                //rellenamos un arraylist con los alquileres que corresponden al usuario
                ArrayList alquileres = new ArrayList(ws.WSMostrarAlquileres(Convert.ToInt32(id_usuario)));

                List<Label> labels = new List<Label>();

                //los mostramos
                for (int i = 0; i<alquileres.Count; i++)
                {
                    WSServicios.alquilan al = (WSServicios.alquilan)alquileres[i];

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