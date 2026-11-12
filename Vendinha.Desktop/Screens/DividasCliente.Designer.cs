using Vendinha.Desktop.Componentes;

namespace Vendinha.Desktop.Screens
{
    partial class DividasCliente
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
            lblValor = new Label();
            txtValor = new TextBox();
            btnNovaDivida = new PrimaryButton();
            dgvDividas = new DataGridView();
            lblTotal = new Label();
            btnPagar = new PrimaryButton();
            ((System.ComponentModel.ISupportInitialize)dgvDividas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 20F);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(130, 39);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Dívidas";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Arial", 12F);
            lblValor.ForeColor = Color.White;
            lblValor.Location = new Point(30, 87);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(87, 23);
            lblValor.TabIndex = 1;
            lblValor.Text = "Valor (R$):";
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Arial", 12F);
            txtValor.Location = new Point(135, 82);
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "Ex.: 50,00";
            txtValor.Size = new Size(160, 30);
            txtValor.TabIndex = 2;
            // 
            // btnNovaDivida
            // 
            btnNovaDivida.Location = new Point(310, 75);
            btnNovaDivida.Name = "btnNovaDivida";
            btnNovaDivida.Size = new Size(160, 42);
            btnNovaDivida.TabIndex = 3;
            btnNovaDivida.Text = "Nova dívida";
            btnNovaDivida.UseVisualStyleBackColor = false;
            btnNovaDivida.Click += btnNovaDivida_Click;
            // 
            // dgvDividas
            // 
            dgvDividas.AllowUserToAddRows = false;
            dgvDividas.AllowUserToDeleteRows = false;
            dgvDividas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDividas.Location = new Point(30, 135);
            dgvDividas.MultiSelect = false;
            dgvDividas.Name = "dgvDividas";
            dgvDividas.ReadOnly = true;
            dgvDividas.RowHeadersVisible = false;
            dgvDividas.RowHeadersWidth = 51;
            dgvDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDividas.Size = new Size(640, 280);
            dgvDividas.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(30, 447);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 23);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total em aberto: R$ 0,00";
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(470, 435);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(200, 45);
            btnPagar.TabIndex = 6;
            btnPagar.Text = "Marcar como paga";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // DividasCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(700, 510);
            Controls.Add(btnPagar);
            Controls.Add(lblTotal);
            Controls.Add(dgvDividas);
            Controls.Add(btnNovaDivida);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DividasCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dívidas do cliente";
            Load += DividasCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblValor;
        private TextBox txtValor;
        private PrimaryButton btnNovaDivida;
        private DataGridView dgvDividas;
        private Label lblTotal;
        private PrimaryButton btnPagar;
    }
}
