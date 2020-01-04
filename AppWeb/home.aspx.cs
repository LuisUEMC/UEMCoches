using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class home : System.Web.UI.Page
    {
        //inicializamos las funciones de la logica de negocio
        logicaNegocio.clase c = new logicaNegocio.clase();
        protected void Page_Load(object sender, EventArgs e)
        {
            //comprobamos que se ha hecho login, si no es asi, redirecciona al login
            string id_usuario = Request.QueryString["idu"];
            if (Request.QueryString["idu"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                //cargamos todos los vehiculos de la base de datos
                ArrayList vehiculos = new ArrayList();
                vehiculos = c.mostrarVehiculos();

                //inicializamos los componentes que vamos a utilizar dinamicamente
                List<Button> buttons = new List<Button>();
                List<Label> labels = new List<Label>();
                List<Image> images = new List<Image>();

                //rellenamos los componentes con los datos de los vehiculos
                for (int i = 0; i < vehiculos.Count; i++)
                {
                    transversal.vehiculo ve = (transversal.vehiculo)vehiculos[i];

                    //boton de seleccionar coche
                    Button newButton = new Button();
                    newButton.Text = "Alquilar";
                    //funcion para que al hacer click en el boton redireccione a la pagina de alquiler del coche correspondiente
                    newButton.Click += delegate { Response.Redirect("alquilerCoche.aspx?idu=" + id_usuario + "&idc=" + ve.GSIdVehiculo.ToString()); };
                    buttons.Add(newButton);

                    //label
                    Label lblCaracteristicas = new Label();
                    lblCaracteristicas.Text = ve.mostrarCaracteristicas();
                    labels.Add(lblCaracteristicas);

                    //imagen
                    Image ImgCoche = new Image();
                    ImgCoche.Width = 70;
                    ImgCoche.Height = 70;
                    ImgCoche.ImageUrl = "coche.jpg";
                    images.Add(ImgCoche);
                }

                //añadimos los componentes al panel
                for (int j = 0; j < vehiculos.Count; j++)
                {
                    Panel1.Controls.Add(labels[j]);
                    Panel1.Controls.Add(images[j]);
                    Panel1.Controls.Add(buttons[j]);
                }
            }
        }

        //el boton que lleva a mis coches alquilados
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("misCoches.aspx?idu=" + Request.QueryString["idu"]);
        }

        //este boton se encarga de refrescar el panel con el filtro correspondiente
        //no comento el codigo interior porque es el mismo pero con los vehiculos filtrados
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            ArrayList vehiculos = new ArrayList();
            vehiculos = c.buscarVehiculos(tbModelo.Text, tbcombustible.Text, Convert.ToDouble(tbPrecio.Text));

            //inicializamos los componentes
            List<Button> buttons = new List<Button>();
            List<Label> labels = new List<Label>();
            List<Image> images = new List<Image>();

            for (int i = 0; i < vehiculos.Count; i++)
            {
                transversal.vehiculo ve = (transversal.vehiculo)vehiculos[i];

                //boton de seleccionar coche
                Button newButton = new Button();
                newButton.Text = "Alquilar";
                newButton.Click += delegate { Response.Redirect("alquilerCoche.aspx?idu=" + Request.QueryString["idu"] + "&idc=" + ve.GSIdVehiculo.ToString()); };
                buttons.Add(newButton);

                //label
                Label lblCaracteristicas = new Label();
                lblCaracteristicas.Text = ve.mostrarCaracteristicas();
                labels.Add(lblCaracteristicas);

                //imagen
                Image ImgCoche = new Image();
                ImgCoche.Width = 70;
                ImgCoche.Height = 70;
                ImgCoche.ImageUrl = "coche.jpg";
                images.Add(ImgCoche);
            }

            for (int j = 0; j < vehiculos.Count; j++)
            {
                Panel1.Controls.Add(labels[j]);
                Panel1.Controls.Add(images[j]);
                Panel1.Controls.Add(buttons[j]);
            }

        }
    }
}