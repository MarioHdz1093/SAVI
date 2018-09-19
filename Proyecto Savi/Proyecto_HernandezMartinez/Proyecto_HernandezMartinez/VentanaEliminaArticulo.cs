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
    public partial class VentanaEliminaArticulo : Form
    {
        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;
        String id;
        List<Articulos> listaUsuarios;
        Articulos aux = new Articulos();
        bool validar = false;

        public VentanaEliminaArticulo(List<Articulos> original)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            listaUsuarios = original;
            llena();
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
            foreach (Articulos v in listaUsuarios)
            {
                comboBox1.Items.Add(v.cve_Articulo);

                aux = v;
            }
        }


        private void Verificar_Click_1(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            int i = 0;
            foreach (Articulos v in listaUsuarios)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (validar)
            {
                int posicionCB = Int32.Parse(comboBox1.Text);
                String consulta = "DELETE From articulos WHERE idProducto = " + posicionCB.ToString();
                //MessageBox.Show("DELETE  From registroUsuario WHERE idUsuario = " + posicionCB.ToString());
                conectar();
                comand = new OleDbCommand(consulta, con);
                comand.ExecuteNonQuery();
                desconectar();

                MessageBox.Show("Se Elimino la clave: " + posicionCB + ", con el nombre: " + aux.nombre);
                aux = new Articulos();
                Close();
            }
            else
            {
                MessageBox.Show("VERIFICA ANTES DE ELIMINAR UN USUARIO");
            }

        }
    }

}
