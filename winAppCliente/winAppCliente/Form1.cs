using System.Net;
using System.Net.Sockets;
using System.Text;

namespace winAppCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Socket cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint conexion = new IPEndPoint(IPAddress.Parse("172.25.222.15"), 6400);

            cliente.Connect(conexion);
            byte [] vecEnviar = new byte[1024];

            string dato = "";
            dato = textBox1.Text;
            MessageBox.Show("... enviando información");
            vecEnviar = Encoding.Default.GetBytes(dato);
            cliente.Send(vecEnviar);
        }
    }
}