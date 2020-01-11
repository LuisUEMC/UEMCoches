using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorio
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        //codigo inutil
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //codigo inutil
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //la funcion que comprueba el login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //inicializamos las funciones de la logica de negocios
            WSServicios.serviciosSoapClient ws = new WSServicios.serviciosSoapClient();
            int id_usuario = 0;
            id_usuario = ws.WSLogin(tbUser.Text, tbPass.Text);
            //si el id_usuario es 0 significa que no estas registrado o son credenciales incorrectas
            if (id_usuario == 0)
            {
                lblInfo.Text = "No estas registrado o has introducido credenciales incorrectas";
            }
            else
            {
                //comprobamos que solo los usuarios de tipo administrador puedan acceder aqui
                WSServicios.usuario usu = ws.WSBuscarUsuario(tbUser.Text);
                if (usu.GSTipo != "administrador")
                {
                    lblInfo.Text = "Aqui no puedes entrar siendo usuario comun";
                }
                else
                {
                    //como el login es correcto, se cierra esta ventana y se muestra la de home
                    lblInfo.Text = "Te has loggeado con exito";
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
            }
        }
    }
}
