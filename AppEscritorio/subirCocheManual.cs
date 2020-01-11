using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorio
{
    public partial class subirCocheManual : Form
    {
        public subirCocheManual()
        {
            InitializeComponent();
        }
        //codigo inutil
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //codigo inutil
        private void label11_Click(object sender, EventArgs e)
        {

        }
        //boton para retroceder al home
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();
            ws.WSGuardarVehiculo(tbModelo.Text, Convert.ToInt32(tbAno.Text), tbPrestaciones.Text, tbColor.Text, Convert.ToInt32(tbPuertas.Text), tbCombustible.Text, Convert.ToInt32(dddlValoracion.Value),Convert.ToDouble(tbPrecio.Text));
            lblInfo.Text = "Vehiculo añadido correctamente";
        }
    }
}
