using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Proyecto_HernandezMartinez
{
    public partial class VentanaClienteServidor : Form
    {
        private Socket Cliente_Jugador;
        private byte[] buffer;
        private string adress;
        private string numPuerto;
        private AsyncCallback clientecallback;
        private int myId;

        public VentanaClienteServidor()
        {
            InitializeComponent();

            adress = "127.0.0.1";//IPv4 Adress 
            numPuerto = "8002";
            myId = -1;
            Cliente_Jugador = null;
            clientecallback = new AsyncCallback(OnDataReceived);
        }


        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                int len;
                char[] chars;

                len = Cliente_Jugador.EndReceive(asyn);

                chars = new char[len + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(buffer, 0, len, chars, 0);

                //Asignacion de nombre
                if (chars[1] == 'I')
                {
                    if (chars[0] == '0')
                        myId = 0;
                    if (chars[0] == '1')
                        myId = 1;

                    nomJugador.Invoke(new Action(delegate () { nomJugador.Text = "Cliente : " + myId; }));
                }
                else
                {
                    //Envio de datos
                    listBox1.Invoke(new Action(delegate () { listBox1.Items.Add(new System.String(chars)); }));
                }
                Cliente_Jugador.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, clientecallback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void envia()
        {
            try
            {
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(txtMensaje.Text);
                if (Cliente_Jugador != null)
                    Cliente_Jugador.Send(byData);
                //listBox1.Items.Add(txtMensaje.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("CONECTADO");
            try
            {
                Cliente_Jugador = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse(adress);
                int iPortNo = int.Parse(numPuerto);

                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);

                Cliente_Jugador.Connect(ipEnd);
                if (Cliente_Jugador.Connected == true)
                {
                    buffer = new byte[1024];
                    Cliente_Jugador.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, clientecallback, null);
                }
                else MessageBox.Show("No se conecto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDesconectar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("DESCONECTADO");
            if (Cliente_Jugador == null) return;

            Cliente_Jugador.Close();
            Cliente_Jugador = null;
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            if (myId != -1)
                envia();

            txtMensaje.Text = "";
        }


    }
}
