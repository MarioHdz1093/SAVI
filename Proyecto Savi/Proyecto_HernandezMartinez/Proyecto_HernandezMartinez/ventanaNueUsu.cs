using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proyecto_HernandezMartinez
{
    public partial class ventanaNueUsu : Form
    {
        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;
        String id;
        List<Vendedor> listaUsuarios;


        public ventanaNueUsu(List<Vendedor> originlal)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            listaUsuarios = originlal;
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

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                int c = listaUsuarios.Count;
                //Agregar USUARIO 
                String consulta = "Insert into registroUsuario(idUsuario,Nombre,contraseña) Values('" + c.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                conectar();
                comand = new OleDbCommand(consulta, con);
                comand.ExecuteNonQuery();
                desconectar();
                
                
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Close();
            }
            else
            {
                MessageBox.Show("Contraseña no coicide");
            }
            
        }
    }
}
