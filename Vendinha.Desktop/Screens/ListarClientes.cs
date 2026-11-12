using Vendinha.Desktop.Models;
using Vendinha.Desktop.Services;

namespace Vendinha.Desktop.Screens
{
    public partial class ListarClientes : Form
    {
        private readonly ClienteService clienteService;
        private readonly DividaService dividaService;
        private int paginaAtual = 1;
        private int totalPaginas = 1;

        // Clientes da página que está na tela (usado depois para Editar, Excluir e Dívidas)
        private List<Cliente> clientes = new List<Cliente>();

        public ListarClientes(ClienteService clienteService, DividaService dividaService)
        {
            InitializeComponent();
            this.clienteService = clienteService;
            this.dividaService = dividaService;
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

            // Se a página ficou vazia (ex.: excluiu o último cliente dela), volta para a última página
            if (paginaAtual > totalPaginas)
            {
                paginaAtual = totalPaginas;
                await CarregarClientes();
                return;
            }

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
            dgvClientes.Columns[4].HeaderText = "Total devido"; // a 5ª coluna (começa em 0)

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

        private async void btnDividas_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na lista.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = clientes[dgvClientes.CurrentRow.Index];
            var tela = new DividasCliente(dividaService, cliente);
            tela.ShowDialog();

            // Ao voltar, recarrega: o total devido pode ter mudado
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

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na lista.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = clientes[dgvClientes.CurrentRow.Index];

            var resposta = MessageBox.Show($"Deseja excluir o cliente {cliente.NomeCompleto}?", "Excluir cliente",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta != DialogResult.Yes)
                return;

            try
            {
                // 1ª tentativa sem confirmar: se o cliente tiver dívida em aberto, a API não exclui e pergunta
                var confirmacao = await clienteService.Excluir(cliente.Id);

                if (confirmacao != null)
                {
                    var divida = confirmacao.DividaEmAberto;
                    var texto = confirmacao.Mensagem;
                    if (divida != null)
                        texto += $"\n\nValor: {divida.Valor:C}\nCriada em: {divida.DataCriacao:dd/MM/yyyy}";

                    if (MessageBox.Show(texto, "Cliente com dívida em aberto",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    // O usuário confirmou: chama de novo, agora com confirmar = true
                    await clienteService.Excluir(cliente.Id, confirmar: true);
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Não foi possível excluir o cliente. Confira se a Vendinha.Api está rodando.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cliente excluído.", "Vendinha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CarregarClientes();
        }
    }
}
