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
        logicaNegocio.clase c = new logicaNegocio.clase();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = Request.QueryString["idu"];
            if (Request.QueryString["idu"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                ArrayList vehiculos = new ArrayList();
                vehiculos = c.mostrarVehiculos();

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

                for (int j = 0; j < vehiculos.Count; j++)
                {
                    Panel1.Controls.Add(labels[j]);
                    Panel1.Controls.Add(images[j]);
                    Panel1.Controls.Add(buttons[j]);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("misCoches.aspx?idu=" + Request.QueryString["idu"]);
        }

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