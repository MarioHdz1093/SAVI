using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_HernandezMartinez
{
    public partial class VentanaAyuda : Form
    {
        public VentanaAyuda()
        {
            InitializeComponent();
            label1.Text = "PROGRAMA HECHO PARA VENTAS DE UNA PAPELERIA";
            llena();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaClienteServidor articuloNuevo = new VentanaClienteServidor();
            articuloNuevo.ShowDialog();
        }

        public void llena()
        {
            String hola = "";
            FileStream streamR = new FileStream("texto.txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(streamR);

            hola = reader.ReadString();

            textBox1.Text = hola;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string variable = Directory.GetCurrentDirectory();
            variable = variable + "\\Servidor.exe";
            System.Diagnostics.Process.Start(variable);


        }
    }
}
