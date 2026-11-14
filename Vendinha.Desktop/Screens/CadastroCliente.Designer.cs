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
            lblTitulo.Font = new Font("Segoe UI Semibold", 20F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(30, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(440, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Novo cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 10F);
            lblNome.ForeColor = Color.FromArgb(71, 85, 105);
            lblNome.Location = new Point(25, 82);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(129, 23);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome completo *";
            //
            // txtNome
            //
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 12F);
            txtNome.ForeColor = Color.FromArgb(15, 23, 42);
            txtNome.Location = new Point(30, 110);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(440, 34);
            txtNome.TabIndex = 2;
            //
            // lblCpf
            //
            lblCpf.AutoSize = true;
            lblCpf.Font = new Font("Segoe UI Semibold", 10F);
            lblCpf.ForeColor = Color.FromArgb(71, 85, 105);
            lblCpf.Location = new Point(25, 157);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(47, 23);
            lblCpf.TabIndex = 3;
            lblCpf.Text = "CPF *";
            //
            // mskCpf
            //
            mskCpf.BorderStyle = BorderStyle.FixedSingle;
            mskCpf.Font = new Font("Segoe UI", 12F);
            mskCpf.ForeColor = Color.FromArgb(15, 23, 42);
            mskCpf.Location = new Point(30, 185);
            mskCpf.Mask = "000\\.000\\.000-00";
            mskCpf.Name = "mskCpf";
            mskCpf.Size = new Size(210, 34);
            mskCpf.TabIndex = 4;
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //
            // lblNascimento
            //
            lblNascimento.AutoSize = true;
            lblNascimento.Font = new Font("Segoe UI Semibold", 10F);
            lblNascimento.ForeColor = Color.FromArgb(71, 85, 105);
            lblNascimento.Location = new Point(255, 157);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(164, 23);
            lblNascimento.TabIndex = 5;
            lblNascimento.Text = "Data de nascimento *";
            //
            // mskNascimento
            //
            mskNascimento.BorderStyle = BorderStyle.FixedSingle;
            mskNascimento.Font = new Font("Segoe UI", 12F);
            mskNascimento.ForeColor = Color.FromArgb(15, 23, 42);
            mskNascimento.Location = new Point(260, 185);
            mskNascimento.Mask = "00/00/0000";
            mskNascimento.Name = "mskNascimento";
            mskNascimento.Size = new Size(210, 34);
            mskNascimento.TabIndex = 6;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(25, 232);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail";
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmail.Location = new Point(30, 260);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(440, 34);
            txtEmail.TabIndex = 8;
            //
            // btnSalvar
            //
            btnSalvar.Location = new Point(30, 325);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(210, 46);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Location = new Point(260, 325);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(210, 46);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // CadastroCliente
            //
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(500, 400);
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
