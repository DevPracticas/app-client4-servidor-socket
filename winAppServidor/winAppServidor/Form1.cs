using System.Net;
using System.Net.Sockets;
using System.Text;

namespace winAppServidor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Socket esperar = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket conexion;
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6400);

            esperar.Bind(direccion);
            esperar.Listen(5);
            conexion = esperar.Accept();
            MessageBox.Show("Conexión aceptada");
            byte[] vecRecibir = new byte[1024];
            string dato;
            int totalID = 0;
            totalID = conexion.Receive(vecRecibir, 0, vecRecibir.Length, 0);
            Array.Resize(ref vecRecibir, totalID);
            dato = Encoding.Default.GetString(vecRecibir);

            listBox1.Items.Add(dato);
        }
    }
}