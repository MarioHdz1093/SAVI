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
    public partial class VentanaTipoVenta : Form
    {
        public List<Archivo> listaImpresiones;
        public List<Articulos> existentes;
        public string tipo;
        private string nombre;
        public Vendedor turno;

        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;

        public VentanaTipoVenta(List<Archivo> original, Vendedor enTurno, List<Articulos> existencias)
        {
            InitializeComponent();

            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";

            listaImpresiones = original;
            tipo = "color";
            TBtipoVenta.Text = "Impresiones";
           
            turno = enTurno;
            existentes = existencias;

            rellena_lista();
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

        //con este boton cambias pantalla a tipo de impresion color/BN
        private void button1_Click(object sender, EventArgs e)
        {
            if (TBtipoVenta.Text.Equals("Impresiones Color") == true || TBtipoVenta.Text.Equals("Impresiones ByN") == true)
            {
                Articulos auxArticulo = new Articulos();

                foreach (Articulos a in existentes)
                {
                    if (a.cve_Articulo.Equals("1"))
                    {
                        auxArticulo = a;
                    }
                }

                if (auxArticulo.cantidad != 0)
                {
                    VentanaVentas a = new VentanaVentas(listaImpresiones, turno);
                    a.ShowDialog();
                    listaImpresiones = a.listaImpresiones;
                    turno = a.turno;
                    //ListaVendedor = new List<Vendedor>();
                    Close();
                }
            }

            else
            {
                MessageBox.Show("Elija opcion valida (Impresiones color o impresion ByN) para poder acceder a imprimir" );
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void rellena_lista()
        {
            foreach(Articulos a in existentes)
            {
                TBtipoVenta.Items.Add(a.nombre);

            }

        }

        /* click con el cual se concreta la venta
        *
        */

        private void vender_Click(object sender, EventArgs e)
        {
            Articulos auxArticulo = new Articulos();
            int num = 0;
            int falta = 0;

            if (TBtipoVenta.Text.Equals("Impresiones Color") == false && TBtipoVenta.Text.Equals("Impresiones ByN") == false)
            {
                foreach (Articulos a in existentes)
                {
                    if (a.nombre.Equals(TBtipoVenta.Text) == true)
                    {
                        auxArticulo = a;
                    }

                }

                num = Int32.Parse(numeroCopias.Text);

                if (auxArticulo.cantidad >= num)
                {
                    auxArticulo.dia = DateTime.Now.ToString("dd/MM/yyyy");
                    auxArticulo.hora = DateTime.Now.ToString("hh:mm:ss");

                    String consulta = "Insert into registroVentas(idUsuario,tipo,copias,dia,hora) Values('" + turno.cve_vendedor + "','" + auxArticulo.cve_Articulo + "','" + num + "','" +auxArticulo.dia + "','" + auxArticulo.hora + "')";
                    conectar();
                    comand = new OleDbCommand(consulta, con);
                    comand.ExecuteNonQuery();
                    desconectar();

                    int resta = auxArticulo.cantidad - num;
                    


                    String consult = "UPDATE articulos SET cantidaExistente = " + resta+"  WHERE IdProducto = " + auxArticulo.cve_Articulo + "";
                    //MessageBox.Show(consult);
                    conectar();
                    //OleDbCommand cmd = new OleDbCommand("DELETE FROM Articulos WHERE Title = tempTitle", con);
                    comand = new OleDbCommand(consult, con);
                    comand.ExecuteNonQuery();
                    desconectar();

                    MessageBox.Show("Se vendio " + auxArticulo.nombre + " por el venderor" +turno.nombre);
                    MessageBox.Show(auxArticulo.hora,auxArticulo.dia);

                    if (resta <= 5)
                    {
                        MessageBox.Show("El articulo " + auxArticulo.nombre + " se esta agotando");
                    }

                    Close();
                }
                else
                {
                    falta = num - auxArticulo.cantidad;
                    MessageBox.Show("No se puede vender no tienes cantidad suficiente falta: " +falta+ "articulo(s) para completar la venta");
                }
            }
        }
    }
}
