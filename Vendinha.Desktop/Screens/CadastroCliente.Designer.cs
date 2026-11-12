using Vendinha.Desktop.Componentes;

namespace Vendinha.Desktop.Screens
{
    partial class CadastroCliente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            lblCpf = new Label();
            mskCpf = new MaskedTextBox();
            lblNascimento = new Label();
            mskNascimento = new MaskedTextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSalvar = new PrimaryButton();
            btnCancelar = new PrimaryButton();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 20F);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(184, 39);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Novo cliente";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Arial", 10F);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(30, 80);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(122, 19);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome completo *";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Arial", 12F);
            txtNome.Location = new Point(30, 103);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(430, 30);
            txtNome.TabIndex = 2;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Font = new Font("Arial", 10F);
            lblCpf.ForeColor = Color.White;
            lblCpf.Location = new Point(30, 148);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(45, 19);
            lblCpf.TabIndex = 3;
            lblCpf.Text = "CPF *";
            // 
            // mskCpf
            // 
            mskCpf.Font = new Font("Arial", 12F);
            mskCpf.Location = new Point(30, 171);
            mskCpf.Mask = "000.000.000-00";
            mskCpf.Name = "mskCpf";
            mskCpf.Size = new Size(200, 30);
            mskCpf.TabIndex = 4;
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Font = new Font("Arial", 10F);
            lblNascimento.ForeColor = Color.White;
            lblNascimento.Location = new Point(250, 148);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(155, 19);
            lblNascimento.TabIndex = 5;
            lblNascimento.Text = "Data de nascimento *";
            // 
            // mskNascimento
            // 
            mskNascimento.Font = new Font("Arial", 12F);
            mskNascimento.Location = new Point(250, 171);
            mskNascimento.Mask = "00/00/0000";
            mskNascimento.Name = "mskNascimento";
            mskNascimento.Size = new Size(210, 30);
            mskNascimento.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 10F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(30, 216);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 19);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 12F);
            txtEmail.Location = new Point(30, 239);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(430, 30);
            txtEmail.TabIndex = 8;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(30, 300);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(200, 50);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(260, 300);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(200, 50);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // CadastroCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(500, 380);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(mskNascimento);
            Controls.Add(lblNascimento);
            Controls.Add(mskCpf);
            Controls.Add(lblCpf);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CadastroCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblCpf;
        private MaskedTextBox mskCpf;
        private Label lblNascimento;
        private MaskedTextBox mskNascimento;
        private Label lblEmail;
        private TextBox txtEmail;
        private PrimaryButton btnSalvar;
        private PrimaryButton btnCancelar;
    }
}
