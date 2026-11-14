using Vendinha.Desktop.Models;
using Vendinha.Desktop.Services;

namespace Vendinha.Desktop.Screens
{
    public partial class DividasCliente : Form
    {
        private readonly DividaService dividaService;
        private readonly Cliente cliente;

        // Dívidas que estão na tabela (para saber qual foi selecionada)
        private List<Divida> dividas = new List<Divida>();

        public DividasCliente(DividaService dividaService, Cliente cliente)
        {
            InitializeComponent();
            this.dividaService = dividaService;
            this.cliente = cliente;

            lblTitulo.Text = $"Dívidas de {cliente.NomeCompleto}";
        }

        private async void DividasCliente_Load(object sender, EventArgs e)
        {
            await CarregarDividas();
        }

        private async Task CarregarDividas()
        {
            try
            {
                dividas = await dividaService.Listar(cliente.Id);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Não foi possível falar com a API. Confira se a Vendinha.Api está rodando.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tipo anônimo com as colunas da tabela, já formatadas
            dgvDividas.DataSource = dividas
                .Select(d => new
                {
                    Valor = d.Valor.ToString("C"),
                    d.Situacao,
                    CriadaEm = d.DataCriacao.ToString("dd/MM/yyyy"),
                    PagaEm = d.DataPagamento == null ? "" : d.DataPagamento.Value.ToString("dd/MM/yyyy")
                })
                .ToList();
            // Títulos das colunas pela posição (começa em 0)
            dgvDividas.Columns[1].HeaderText = "Situação";
            dgvDividas.Columns[2].HeaderText = "Criada em";
            dgvDividas.Columns[3].HeaderText = "Paga em";

            // Valor em dinheiro alinhado à direita (célula e título da coluna)
            dgvDividas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDividas.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            // LINQ (Aula 5): soma só as dívidas que ainda não foram pagas
            var totalEmAberto = dividas.Where(d => !d.Paga).Sum(d => d.Valor);
            lblTotal.Text = $"Total em aberto: {totalEmAberto:C}";
        }

        private async void btnNovaDivida_Click(object sender, EventArgs e)
        {
            // Aceita "50,25" e também "50.25" (sem vírgula, o ponto vira vírgula, que é o padrão brasileiro)
            var texto = txtValor.Text.Contains(',') ? txtValor.Text : txtValor.Text.Replace('.', ',');

            // TryParse com out: converte o texto para decimal e avisa se não conseguir
            if (!decimal.TryParse(texto, out var valor))
            {
                MessageBox.Show("Informe um valor válido. Ex.: 50,00", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? erro;
            try
            {
                // A API confere se o valor é maior que zero e se já existe dívida em aberto
                erro = await dividaService.Cadastrar(cliente.Id, valor);
            }
            catch (HttpRequestException)
            {
                erro = "Não foi possível falar com a API. Confira se a Vendinha.Api está rodando.";
            }

            if (erro != null)
            {
                MessageBox.Show(erro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtValor.Clear();
            await CarregarDividas();
        }

        private async void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvDividas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma dívida na lista.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var divida = dividas[dgvDividas.CurrentRow.Index];

            var resposta = MessageBox.Show($"Marcar a dívida de {divida.Valor:C} como paga?", "Pagar dívida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta != DialogResult.Yes)
                return;

            string? erro;
            try
            {
                erro = await dividaService.Pagar(cliente.Id, divida.Id);
            }
            catch (HttpRequestException)
            {
                erro = "Não foi possível falar com a API. Confira se a Vendinha.Api está rodando.";
            }

            if (erro != null)
            {
                MessageBox.Show(erro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await CarregarDividas();
        }
    }
}
