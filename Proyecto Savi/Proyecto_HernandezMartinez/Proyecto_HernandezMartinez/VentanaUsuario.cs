using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_HernandezMartinez
{
    public partial class VentanaUsuario : Form
    {
        List<Vendedor> manejo;
        String nombreUsuario;
        public Vendedor enTurno;

        public VentanaUsuario(List<Vendedor> entrante)
        {
            InitializeComponent();
            manejo = entrante;
            //pasaUsuarios();
            enTurno = new Vendedor();
            
        }

        public void pasaUsuarios()
        {
            foreach (Vendedor v in manejo)
            {
                MessageBox.Show(v.nombre + " " + v.cve_vendedor + " " + v.contraseña);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreUsuario = textBox1.Text;
            bool band1 = false;

            

            foreach (Vendedor v in manejo)
            {
                if (nombreUsuario == v.nombre && textBox2.Text == v.contraseña)
                {
                    band1 = true;
                    enTurno = v;
                }


            }

            if (band1)
            {

                Close();
            }
            else
            {
                MessageBox.Show(" Nombre y/o contraseña erronea");

                textBox2.Text = "";
            }

        }
    }
}

