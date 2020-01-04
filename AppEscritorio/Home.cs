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
    public partial class Home : Form
    {
        logicaNegocio.clase c = new logicaNegocio.clase();
        public Home(int idu)
        {
            //comprobamos que se ha hecho el login, si no se redirige al login
            if (idu == 0)
            {
                this.Close();
                login l = new login();
                l.Show();
            }
            else
            {
                InitializeComponent();
            }
            
        }

        //codigo inutil
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //con este boton simplemente llamamos a la funcion que guarda los coches en un XML
        private void btnGuardarCoches_Click(object sender, EventArgs e)
        {
            c.guardarCochesXML();
            lblInfo.Text = "XML creado con exito!";
        }

        //con este boton abrimos un dialogo de seleccion de ficheros XML y enviamos el path a la funcion
        //que se encargara de guardar los coches en la Base de datos
        private void btnSubirCoches_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ficheros xml | *.xml";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                c.guardarCochesBD(dialog.FileName);
                lblInfo.Text = "vehiculos añadidos con exito!";
            }
        }
    }
}
