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
    public partial class VentanaVentas : Form
    {
        public List<Archivo> listaImpresiones;
        public string tipo;
        private string nombre;
        public Vendedor turno;

        //conectar base de datos
        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;

        public VentanaVentas(List<Archivo> original, Vendedor enTurno)
        {
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";
            InitializeComponent();
            listaImpresiones = original;
            tipo = "color";
            numeroCopias.Text = "1";
            rellena_lista();
            turno = enTurno;
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

        private void imprimirArchivo_Click(object sender, EventArgs e)
        {
            Archivo aux = new Archivo();
            tipoVenta auxVenta = new tipoVenta();
            int num = 0;
            int tipoVenta = 0;

            num = Int32.Parse(numeroCopias.Text);
            MessageBox.Show("Se imprimio: " +TBdireccion.Text+ " Numero Copias " +num+ ", a " +tipo);

            aux.cve_vendedor = turno.cve_vendedor;

            if (tipo.Equals("escala de grises"))
            {
                tipoVenta = 1;
            }

            if (tipo.Equals("color"))
            {
                tipoVenta = 2;
            }


            String consulta = "Insert into registroVentas(idUsuario,tipo,copias) Values('" +turno.cve_vendedor+ "','" + tipoVenta + "','" + num + "')";
            conectar();
            comand = new OleDbCommand(consulta, con);
            comand.ExecuteNonQuery();
            desconectar();

            auxVenta.tipVenta = tipoVenta.ToString();
            auxVenta.cantidadVendida = num.ToString();
            auxVenta.diaVenta = DateTime.Now.ToString("dd/MM/yyyy");
            auxVenta.horaVenta = DateTime.Now.ToString("hh:mm:ss");

            listaImpresiones.Add(aux);
            turno.listaDeVentas.Add(auxVenta);


            Close();
        }

       


    private void Abrir_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "files *.pdf | *.docx";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                nombre = openFileDialog2.FileName;
                TBdireccion.Text = nombre;
            }
        }

        //simple lista que rellena el combo box del 1 al 15
        public void rellena_lista()
        {
            for (int i = 1; i < 15; i++)
            {
                numeroCopias.Items.Add(i + 1);

            }

        }


        //sellecion de color o blanco y negro //[
        private void ByN_Click(object sender, EventArgs e)
        {
            tipo = "escala de grises";
        }

        private void Color_Click(object sender, EventArgs e)
        {
            tipo = "color";
        }
        ////]//
        
    }
}
