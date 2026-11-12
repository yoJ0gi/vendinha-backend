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
                dtpNascimento.Value = cliente.DataNascimento;
                txtEmail.Text = cliente.Email;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var dados = new Cliente
            {
                Id = cliente == null ? 0 : cliente.Id,
                NomeCompleto = txtNome.Text,
                Cpf = mskCpf.Text,
                DataNascimento = dtpNascimento.Value.Date,
                Email = txtEmail.Text
            };

            // As validações (CPF válido, CPF repetido, e-mail...) são feitas pela API.
            // Se ela recusar, devolve a mensagem de erro e mostramos para o usuário.
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
