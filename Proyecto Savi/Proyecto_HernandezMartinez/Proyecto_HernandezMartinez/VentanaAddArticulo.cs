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
    public partial class VentanaAddArticulo : Form
    {
        public List<Articulos> ListaArticulos;

        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;
        String id;

        public VentanaAddArticulo(List<Articulos> original)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            ListaArticulos = original;
            llenaComboBox();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int suma = 0;
            bool validar = false;
            Articulos aux = new Articulos();

            foreach (Articulos a in ListaArticulos)
            {
                if (a.nombre.Equals(CBnombre.Text))
                {
                    aux = a;
                    validar = true;
                }
            }

            if (validar == true)
            {
                int cantidad = Int32.Parse(TBCantidad.Text);
                

                suma = cantidad + aux.cantidad;
                
                //Agregar Mas Producto
                //MOdificar para quesolo agrege mas producto
                //String consulta = "Insert into articulos(idProducto,cantidaExistente,nombre) Values('" + aux.cve_Articulo + "','" + cantidad + "','" + aux.nombre + "')";
                String consulta = "UPDATE articulos SET cantidaExistente = " + suma + "  WHERE IdProducto = " + aux.cve_Articulo + "";

                conectar();
                comand = new OleDbCommand(consulta, con);
                comand.ExecuteNonQuery();
                desconectar();

                MessageBox.Show("Se agrego " + suma + " a el articulo " + aux.cve_Articulo );

                Close();
            }
            else
            {
                MessageBox.Show("No existe Producto que quires agregar");
                TBCantidad.Text = "";
                CBnombre.Text = "";
            }
        }

        public void llenaComboBox()
        {
            
            foreach (Articulos a in ListaArticulos)
            {
                CBnombre.Items.Add(a.nombre);
               

            }
        }
    }
}
