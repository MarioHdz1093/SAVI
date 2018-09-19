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
    public partial class VentanaNuevoArticulo : Form
    {
        public List<Articulos> ListaArticulos;

        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;
        String id;

        public VentanaNuevoArticulo(List<Articulos> original)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            ListaArticulos = original;
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

        private void B_Agregar_Click(object sender, EventArgs e)
        {
            bool validar = true;
            foreach (Articulos a in ListaArticulos)
            {
                if (a.nombre.Equals(TBnombre.Text))
                {
                    validar = false;
                }
            }


            if (validar == true)
            {
                int cantidad = Int32.Parse(TBcantidad.Text);

                int ultimo = ListaArticulos.Count;
                
                //Agregar Producto
                String consulta = "Insert into articulos(idProducto,cantidaExistente,nombre) Values('" + ultimo.ToString() + "','" + cantidad + "','" + TBnombre.Text + "')";
                conectar();
                comand = new OleDbCommand(consulta, con);
                comand.ExecuteNonQuery();
                desconectar();

                Close();
            }
            else
            {
                MessageBox.Show("Nombre ya existe");
            }

        }
    }
}
