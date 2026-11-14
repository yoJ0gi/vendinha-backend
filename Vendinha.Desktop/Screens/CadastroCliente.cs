using System.Globalization;
using Vendinha.Desktop.Models;
using Vendinha.Desktop.Services;

namespace Vendinha.Desktop.Screens
{
    public partial class CadastroCliente : Form
    {
        private readonly ClienteService clienteService;

        // null quando é um cadastro novo; preenchido quando é edição
        private readonly Cliente? cliente;

        // Parâmetro opcional: sem cliente a tela cadastra, com cliente a tela edita
        public CadastroCliente(ClienteService clienteService, Cliente? cliente = null)
        {
            InitializeComponent();
            this.clienteService = clienteService;
            this.cliente = cliente;

            if (cliente != null)
            {
                Text = "Editar cliente";
                lblTitulo.Text = "Editar cliente";
                txtNome.Text = cliente.NomeCompleto;
                mskCpf.Text = cliente.Cpf;
                mskNascimento.Text = cliente.DataNascimento.ToString("dd/MM/yyyy");
                txtEmail.Text = cliente.Email;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            // A data é digitada (dd/mm/aaaa). TryParseExact devolve false se ela estiver vazia ou inválida, e a data convertida sai pelo parâmetro out (nascimento).
            if (!DateTime.TryParseExact(mskNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var nascimento))
            {
                MessageBox.Show("Informe a data de nascimento no formato dd/mm/aaaa.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dados = new Cliente
            {
                Id = cliente == null ? 0 : cliente.Id,
                NomeCompleto = txtNome.Text,
                Cpf = mskCpf.Text,
                DataNascimento = nascimento,
                Email = txtEmail.Text
            };

            // As validações (CPF, e-mail...) são feitas pela API; se ela recusar, mostramos a mensagem
            string? erro;
            try
            {
                if (cliente == null)
                    erro = await clienteService.Cadastrar(dados);
                else
                    erro = await clienteService.Atualizar(dados);
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

            MessageBox.Show("Cliente salvo com sucesso!", "Vendinha",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Fecha a tela e avisa quem abriu que deu certo
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
