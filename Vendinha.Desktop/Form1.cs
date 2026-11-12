using Vendinha.Desktop.Screens;
using Vendinha.Desktop.Services;

namespace Vendinha.Desktop
{
    public partial class Form1 : Form
    {
        // Um service só para o programa todo, passado para as telas que precisam dele
        private readonly ClienteService clienteService = new ClienteService();
        private readonly DividaService dividaService = new DividaService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tela = new ListarClientes(clienteService, dividaService);
            tela.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tela = new CadastroCliente(clienteService);
            tela.ShowDialog();
        }
    }
}
