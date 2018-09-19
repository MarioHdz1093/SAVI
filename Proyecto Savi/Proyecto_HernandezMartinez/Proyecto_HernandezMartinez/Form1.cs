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
    public partial class Form1 : Form 
    {
        // Listas administrativas 
        public List<Archivo> ListaHojas;
        // Lista Empleados
        public List<Vendedor> ListaVendedor;
        // lista Articulos existentes para la venta
        public List<Articulos> ListaArticulos;

        //Se nombra el administrador
        Vendedor Administrador = new Vendedor();
        //se nombra el vendedor en turno
        Vendedor enTurno = new Vendedor();

        //cadena para ver quien esta en turno
        string quien;

        String cadconexion;
        OleDbConnection con;
        OleDbCommand comand;
        OleDbDataReader lector;

        public Form1()
        {
            InitializeComponent();
            
            cadconexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\copiadora.accdb; Persist Security Info=False;";

            ListaHojas = new List<Archivo>();
            ListaVendedor = new List<Vendedor>();
            ListaArticulos = new List<Articulos>();

            listaUsu_Lee();
            listaVentas_Lee();
            listaArticulos_Lee();

            //creaAdministrador(Administrador);

            entraUsuario();
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

        public void Muestra()
        {
            String consulta = "Select * From registroUsusario";
            conectar();
            comand = new OleDbCommand(consulta, con);
            lector = comand.ExecuteReader();

            while (lector.Read())
            {
                //listBox1.Items.Add(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();

        }

        //carga los usuarios del archivo copiadora..accdb
        public void listaUsu_Lee()
        {
            Vendedor aux = new Vendedor();
            ListaVendedor = new List<Vendedor>();
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
                //aux.ventasAcumuladas = Int32.Parse(lector.GetValue(3).ToString());

                ListaVendedor.Add(aux);
                aux = new Vendedor();
                //MessageBox.Show(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();

        }

        //carga los productos a la venta del archivo copiadora..accdb
        public void listaArticulos_Lee()
        {
            Articulos aux = new Articulos();
            ListaArticulos = new List<Articulos>();
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

                //aux.ventasAcumuladas = Int32.Parse(lector.GetValue(3).ToString());

                ListaArticulos.Add(aux);
                aux = new Articulos();
                //MessageBox.Show(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();

        }

        //carga los usuarios del archivo copiadora..accdb
        public void listaVentas_Lee()
        {
            Archivo aux = new Archivo();
            ListaHojas = new List<Archivo>();

            String consulta = "Select * From registroVentas";
            conectar();
            //con.Open();
            comand = new OleDbCommand(consulta, con);
            lector = comand.ExecuteReader();

            while (lector.Read())
            {
                aux.cve_vendedor = lector.GetValue(0).ToString();

                aux.vendio.tipVenta = lector.GetValue(1).ToString();
                aux.vendio.cantidadVendida = lector.GetValue(2).ToString();
                aux.vendio.diaVenta = lector.GetValue(3).ToString();
                aux.vendio.horaVenta = lector.GetValue(4).ToString();

                ListaHojas.Add(aux);
                aux = new Archivo();

                //list.Add(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString());
            }
            desconectar();

        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            VentanaTipoVenta a = new VentanaTipoVenta(ListaHojas,enTurno,ListaArticulos);
            a.ShowDialog();
            ListaHojas = a.listaImpresiones;
            enTurno = a.turno;
            //ListaVendedor = new List<Vendedor>();
            listaArticulos_Lee();
            listaUsu_Lee();
            listaVentas_Lee();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Text = vendedorTurno.nombre;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Consultas_Click(object sender, EventArgs e)
        {
            VentanaConsulta a = new VentanaConsulta(ListaHojas);
            a.ShowDialog();
            ListaHojas = a.listaArticulos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaAyuda a = new VentanaAyuda();
            a.ShowDialog();
        }

        public void creaAdministrador(Vendedor admi)
        {
            admi.nombre = "Mario";
            admi.cve_vendedor = "1";
            admi.contraseña = "1234";

            ListaVendedor.Add(admi);
        }

        public void entraUsuario()
        {
            VentanaUsuario usuario = new VentanaUsuario(ListaVendedor);
            usuario.ShowDialog();
            enTurno = usuario.enTurno;

            quien = "El turno es de: " + enTurno.nombre + " clave " + enTurno.cve_vendedor;


            textBox1.Text = quien;
        }

        private void nuevo(object sender, ToolStripItemClickedEventArgs e)
        {
            if (enTurno.cve_vendedor.Equals('0'))
            {
                switch (e.ClickedItem.AccessibleName)
                {
                    //agrega un usuario
                    case "Nuevo Usuario":
                        this.nuevoUsuario();
                        break;

                    //eliminar un usuario
                    case "Elimina":
                        this.nuevoUsuario();
                        break;
                }
            }
            else
            {
                MessageBox.Show("No eres administrador no puedes modificar logeate como andministrador para continuar");
            }
        }

        private void nuevoUsuario()
        {
            //se va la ventana usuario e ingresa un nuevo usuario
            ventanaNueUsu usuarioNuevo = new ventanaNueUsu(ListaVendedor);
            usuarioNuevo.ShowDialog();

            
        }

        private void Nuevo_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
            {
                //agrega un usuario
                case "Nuevo Usuario":
                    this.nuevoUsuario();
                    break;

                //eliminar un usuario
                case "Elimina":
                    this.nuevoUsuario();
                    break;
            }
        }

        //nuevo usuario ingresa
        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enTurno.cve_vendedor.Equals("0"))
            {
                this.nuevoUsuario();
                listaUsu_Lee();
            }
            else
            {
                MessageBox.Show("No eres administrador no puedes modificar logeate como andministrador para continuar");
            }
        }

        //cerrar secion para iniciar con otro.
        private void cerrarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            entraUsuario();

        }

        //Crear nuevo articulo
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaNuevoArticulo articuloNuevo = new VentanaNuevoArticulo(ListaArticulos);
            articuloNuevo.ShowDialog();

            listaArticulos_Lee();
        }

        //añade a articulos mas cantidad
        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAddArticulo articuloNuevo = new VentanaAddArticulo(ListaArticulos);
            articuloNuevo.ShowDialog();

            listaArticulos_Lee();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enTurno.cve_vendedor.Equals("0"))
            {
                VentanaEliminaUsu eUsu = new VentanaEliminaUsu(ListaVendedor);
                eUsu.ShowDialog();

                listaUsu_Lee();
            }
            else
            {
                MessageBox.Show("No eres administrador no puedes modificar logeate como andministrador para continuar");
            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (enTurno.cve_vendedor.Equals("0"))
            {
                VentanaEliminaArticulo eUsu = new VentanaEliminaArticulo(ListaArticulos);
                eUsu.ShowDialog();

                listaArticulos_Lee();
            }
            else {
                MessageBox.Show("No eres administrador no puedes modificar logeate como andministrador para continuar");
            }
        
        }
    }
}

