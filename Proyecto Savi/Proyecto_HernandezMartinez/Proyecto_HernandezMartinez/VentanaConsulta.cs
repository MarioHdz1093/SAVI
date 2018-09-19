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
    public partial class VentanaConsulta : Form
    {
        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;


        public List<Archivo> listaArticulos;
        public VentanaConsulta(List<Archivo> original)
        {
            InitializeComponent();
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            llena();
            listaArticulos = original;
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

        public void manejo_dataGridArticulos()
        {
            
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            //Se inicializa el dataGribView correspondiente

            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[0].Name = "Clave:";
            dataGridView1.Columns[1].Name = "Cantidad de producto:";
            dataGridView1.Columns[2].Name = "Nombre:";

            // Se popula el primer dataGridView con los datos de los articulos
            List<String[]> filas = new List<string[]>();
            String[] fila;

            Articulos aux = new Articulos();
            List<Articulos> ListaAuxArticulos = new List<Articulos>();
            String consulta = "Select * From articulos";
            conectar();
            //con.Open();
            comand = new OleDbCommand(consulta, con);
            lector = comand.ExecuteReader();

            while (lector.Read())
            {

                aux.cve_Articulo = lector.GetValue(0).ToString();
                aux.cantidad = Int32.Parse(lector.GetValue(1).ToString());
                aux.nombre = lector.GetValue(2).ToString();

                fila = new string[] { aux.cve_Articulo, aux.cantidad.ToString(), aux.nombre };

                ListaAuxArticulos.Add(aux);
                aux = new Articulos();
                filas.Add(fila);
                //MessageBox.Show(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();

            foreach (string[] arr in filas)
            {
                dataGridView1.Rows.Add(arr);
            }
        }

        public void manejo_dataGridUsuarios()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            //Se inicializa el dataGribView correspondiente

            dataGridView1.ColumnCount = 2;
            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[0].Name = "Clave: ";
            dataGridView1.Columns[1].Name = "Nombre: ";
            

            // Se popula el primer dataGridView con los datos de los articulos
            List<String[]> filas = new List<string[]>();
            String[] fila;

            Vendedor aux = new Vendedor();
            List<Vendedor> ListaVendedor = new List<Vendedor>();
            String consulta = "Select * From registroUsuario";
            conectar();
            //con.Open();
            comand = new OleDbCommand(consulta, con);
            lector = comand.ExecuteReader();

            while (lector.Read())
            {

                aux.cve_vendedor = lector.GetValue(0).ToString();
                aux.nombre = lector.GetValue(1).ToString();
                aux.contraseña = lector.GetValue(2).ToString();
                aux.ventasAcumuladas = Int32.Parse(lector.GetValue(3).ToString());

                ListaVendedor.Add(aux);
                fila = new string[] { aux.cve_vendedor, aux.nombre } ;
                filas.Add(fila);
                aux = new Vendedor();
                //MessageBox.Show(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();
            

            foreach (string[] arr in filas)
            {
                dataGridView1.Rows.Add(arr);
            }
        }

        public void manejo_dataGridVentas()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            //Se inicializa el dataGribView correspondiente

            dataGridView1.ColumnCount = 5;
            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[0].Name = "Clave Usuario: ";
            dataGridView1.Columns[1].Name = "Tipo: ";
            dataGridView1.Columns[2].Name = "Cantidad: ";
            dataGridView1.Columns[3].Name = "Dia ";
            dataGridView1.Columns[4].Name = "Hora ";

            // Se popula el primer dataGridView con los datos de los articulos
            List<String[]> filas = new List<string[]>();
            String[] fila;

            Archivo aux = new Archivo();
            List<Archivo> ListaHojas = new List<Archivo>();

            String consulta = "Select * From registroVentas";
            conectar();
            //con.Open();
            comand = new OleDbCommand(consulta, con);
            lector = comand.ExecuteReader();

            while (lector.Read())
            {
                aux.cve_vendedor = lector.GetValue(0).ToString();

                aux.vendio.tipVenta = lector.GetValue(2).ToString();
                aux.vendio.cantidadVendida = lector.GetValue(1).ToString();
                aux.vendio.diaVenta = lector.GetValue(3).ToString();
                aux.vendio.horaVenta = lector.GetValue(4).ToString();

                MessageBox.Show(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString() +""+ lector.GetValue(3).ToString());

                fila = new string[] { aux.cve_vendedor, aux.vendio.tipVenta.ToString(), aux.vendio.cantidadVendida.ToString(), aux.vendio.diaVenta, aux.vendio.horaVenta };
                filas.Add(fila);
                
                ListaHojas.Add(aux);
                aux = new Archivo();
                //list.Add(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();
            

            foreach (string[] arr in filas)
            {
                dataGridView1.Rows.Add(arr);
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Ventas":
                    manejo_dataGridVentas();
                    break;
                case "Articulos":
                    manejo_dataGridArticulos();
                    break;
                case "Usuarios":
                    manejo_dataGridUsuarios();
                    break;
            }
        }

        public void llena()
        {
            comboBox1.Items.Add("Ventas");
            comboBox1.Items.Add("Articulos");
            comboBox1.Items.Add("Usuarios");
        }
    }
}
