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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            lblTitulo.AutoEllipsis = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 20F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(30, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(640, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Dívidas";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblValor
            //
            lblValor.Font = new Font("Segoe UI Semibold", 11F);
            lblValor.ForeColor = Color.FromArgb(71, 85, 105);
            lblValor.Location = new Point(30, 83);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(100, 40);
            lblValor.TabIndex = 1;
            lblValor.Text = "Valor (R$):";
            lblValor.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtValor
            //
            txtValor.BorderStyle = BorderStyle.FixedSingle;
            txtValor.Font = new Font("Segoe UI", 12F);
            txtValor.ForeColor = Color.FromArgb(15, 23, 42);
            txtValor.Location = new Point(135, 86);
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "Ex.: 50,00";
            txtValor.Size = new Size(180, 34);
            txtValor.TabIndex = 2;
            //
            // btnNovaDivida
            //
            btnNovaDivida.Location = new Point(330, 83);
            btnNovaDivida.Name = "btnNovaDivida";
            btnNovaDivida.Size = new Size(160, 40);
            btnNovaDivida.TabIndex = 3;
            btnNovaDivida.Text = "Nova dívida";
            btnNovaDivida.UseVisualStyleBackColor = false;
            btnNovaDivida.Click += btnNovaDivida_Click;
            //
            // dgvDividas
            //
            dgvDividas.AllowUserToAddRows = false;
            dgvDividas.AllowUserToDeleteRows = false;
            dgvDividas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvDividas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDividas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDividas.BackgroundColor = Color.White;
            dgvDividas.BorderStyle = BorderStyle.None;
            dgvDividas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDividas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDividas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDividas.ColumnHeadersHeight = 42;
            dgvDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDividas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDividas.EnableHeadersVisualStyles = false;
            dgvDividas.GridColor = Color.FromArgb(226, 232, 240);
            dgvDividas.Location = new Point(30, 140);
            dgvDividas.MultiSelect = false;
            dgvDividas.Name = "dgvDividas";
            dgvDividas.ReadOnly = true;
            dgvDividas.RowHeadersVisible = false;
            dgvDividas.RowHeadersWidth = 51;
            dgvDividas.RowTemplate.Height = 38;
            dgvDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDividas.Size = new Size(640, 275);
            dgvDividas.TabIndex = 4;
            //
            // lblTotal
            //
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotal.Location = new Point(30, 435);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(420, 46);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total em aberto: R$ 0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnPagar
            //
            btnPagar.BackColor = Color.FromArgb(22, 163, 74);
            btnPagar.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 101, 52);
            btnPagar.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnPagar.Location = new Point(470, 435);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(200, 46);
            btnPagar.TabIndex = 6;
            btnPagar.Text = "Marcar como paga";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            //
            // DividasCliente
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
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
