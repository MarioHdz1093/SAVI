using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_HernandezMartinez
{
    public partial class VentanaEliminaUsu : Form
    {
        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;
        String id;
        List<Vendedor> listaUsuarios;
        Vendedor aux = new Vendedor();
        bool validar = false;

        public VentanaEliminaUsu(List<Vendedor> original)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            listaUsuarios = original;
            llena();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar)
            {
                int posicionCB = Int32.Parse(comboBox1.Text);
                String consulta = "DELETE From registroUsuario WHERE idUsuario = " + posicionCB.ToString();
                MessageBox.Show("DELETE From registroUsuario WHERE idUsuario = " + posicionCB.ToString());
                conectar();
                comand = new OleDbCommand(consulta, con);
                comand.ExecuteNonQuery();
                desconectar();

                MessageBox.Show("Se Elimino la clave: " + posicionCB + ", con el nombre: " + aux.nombre);
                aux = new Vendedor();
                Close();
            }
            else
            {
                MessageBox.Show("VERIFICA ANTES DE ELIMINAR UN USUARIO");
            }

        }

        public void conectar()
        {
            try
            {
                con = new OleDbConnection(cadconexion);
                con.Open();
            }
            catch
            {
                MessageBox.Show("No me pude conectar");
            }
        }
        public void desconectar()
        {
            con.Close();
        }

        public void llena()
        {
            foreach (Vendedor v in listaUsuarios)
            {
                comboBox1.Items.Add(v.cve_vendedor);
               
                aux = v;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            int i = 0;
            foreach (Vendedor v in listaUsuarios)
            {
                if (i == index)
                {
                    MessageBox.Show(v.nombre);
                    textBox1.Text = v.nombre;
                }
                i++;
            }      
        }

        private void Verificar_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            int i = 0;
            foreach (Vendedor v in listaUsuarios)
            {
                if (i == index)
                {
                   
                    textBox1.Text = v.nombre;
                    aux = v;
                    break;
                }
                i++;
            }
            validar = true;
        }
    }
}
