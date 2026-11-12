using Vendinha.Desktop.Models;
using Vendinha.Desktop.Services;

namespace Vendinha.Desktop.Screens
{
    public partial class ListarClientes : Form
    {
        private readonly ClienteService clienteService;
        private int paginaAtual = 1;
        private int totalPaginas = 1;

        // Clientes da página que está na tela (usado depois para Editar, Excluir e Dívidas)
        private List<Cliente> clientes = new List<Cliente>();

        public ListarClientes(ClienteService clienteService)
        {
            InitializeComponent();
            this.clienteService = clienteService;
        }

        private async void ListarClientes_Load(object sender, EventArgs e)
        {
            await CarregarClientes();
        }

        // Busca a página atual na API e mostra na tabela
        private async Task CarregarClientes()
        {
            PaginaClientes resultado;
            try
            {
                resultado = await clienteService.Listar(txtBusca.Text, paginaAtual);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Não foi possível falar com a API. Confira se a Vendinha.Api está rodando.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clientes = resultado.Itens;
            totalPaginas = Math.Max(resultado.TotalPaginas, 1);

            // Tipo anônimo (Aula 5): só as colunas que aparecem na tabela, já formatadas
            dgvClientes.DataSource = clientes
                .Select(c => new
                {
                    Nome = c.NomeCompleto,
                    CPF = c.CpfFormatado,
                    c.Idade,
                    Email = c.Email,
                    TotalDevido = c.TotalDividas.ToString("C")
                })
                .ToList();
            dgvClientes.Columns["TotalDevido"].HeaderText = "Total devido";

            lblPagina.Text = $"Página {paginaAtual} de {totalPaginas}";
            btnAnterior.Enabled = paginaAtual > 1;
            btnProxima.Enabled = paginaAtual < totalPaginas;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaAtual = 1; // busca nova sempre começa da primeira página
            await CarregarClientes();
        }

        private async void btnAnterior_Click(object sender, EventArgs e)
        {
            paginaAtual--;
            await CarregarClientes();
        }

        private async void btnProxima_Click(object sender, EventArgs e)
        {
            paginaAtual++;
            await CarregarClientes();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na lista.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // A linha da tabela está na mesma posição do cliente na lista
            var cliente = clientes[dgvClientes.CurrentRow.Index];

            // Mesma tela do cadastro, mas recebendo o cliente: assim ela abre em modo de edição
            var tela = new CadastroCliente(clienteService, cliente);
            if (tela.ShowDialog() == DialogResult.OK)
                await CarregarClientes(); // recarrega para mostrar os dados novos
        }
    }
}
