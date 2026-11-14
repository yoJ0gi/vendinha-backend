using Vendinha.Desktop.Componentes;

namespace Vendinha.Desktop.Screens
{
    partial class ListarClientes
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
            txtBusca = new TextBox();
            btnBuscar = new PrimaryButton();
            dgvClientes = new DataGridView();
            btnAnterior = new PrimaryButton();
            lblPagina = new Label();
            btnProxima = new PrimaryButton();
            btnEditar = new PrimaryButton();
            btnExcluir = new PrimaryButton();
            btnDividas = new PrimaryButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI Semibold", 20F);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(30, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(840, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Clientes";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // txtBusca
            //
            txtBusca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBusca.BorderStyle = BorderStyle.FixedSingle;
            txtBusca.Font = new Font("Segoe UI", 12F);
            txtBusca.ForeColor = Color.FromArgb(15, 23, 42);
            txtBusca.Location = new Point(30, 86);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Buscar por nome";
            txtBusca.Size = new Size(690, 34);
            txtBusca.TabIndex = 1;
            //
            // btnBuscar
            //
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Location = new Point(735, 83);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(135, 40);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            //
            // dgvClientes
            //
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.ColumnHeadersHeight = 42;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.GridColor = Color.FromArgb(226, 232, 240);
            dgvClientes.Location = new Point(30, 140);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.RowTemplate.Height = 38;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(840, 325);
            dgvClientes.TabIndex = 3;
            //
            // btnAnterior
            //
            btnAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAnterior.BackColor = Color.White;
            btnAnterior.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAnterior.FlatAppearance.BorderSize = 1;
            btnAnterior.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            btnAnterior.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnAnterior.ForeColor = Color.FromArgb(51, 65, 85);
            btnAnterior.Location = new Point(30, 485);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(125, 44);
            btnAnterior.TabIndex = 4;
            btnAnterior.Text = "< Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            //
            // lblPagina
            //
            lblPagina.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPagina.Font = new Font("Segoe UI", 11F);
            lblPagina.ForeColor = Color.FromArgb(71, 85, 105);
            lblPagina.Location = new Point(160, 485);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(150, 44);
            lblPagina.TabIndex = 5;
            lblPagina.Text = "Página 1 de 1";
            lblPagina.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnProxima
            //
            btnProxima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnProxima.BackColor = Color.White;
            btnProxima.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnProxima.FlatAppearance.BorderSize = 1;
            btnProxima.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            btnProxima.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnProxima.ForeColor = Color.FromArgb(51, 65, 85);
            btnProxima.Location = new Point(315, 485);
            btnProxima.Name = "btnProxima";
            btnProxima.Size = new Size(125, 44);
            btnProxima.TabIndex = 6;
            btnProxima.Text = "Próxima >";
            btnProxima.UseVisualStyleBackColor = false;
            btnProxima.Click += btnProxima_Click;
            //
            // btnEditar
            //
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.BackColor = Color.White;
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnEditar.FlatAppearance.BorderSize = 1;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnEditar.ForeColor = Color.FromArgb(51, 65, 85);
            btnEditar.Location = new Point(640, 485);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 44);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.FromArgb(220, 38, 38);
            btnExcluir.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 27, 27);
            btnExcluir.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnExcluir.Location = new Point(760, 485);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(110, 44);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            //
            // btnDividas
            //
            btnDividas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDividas.Location = new Point(520, 485);
            btnDividas.Name = "btnDividas";
            btnDividas.Size = new Size(110, 44);
            btnDividas.TabIndex = 9;
            btnDividas.Text = "Dívidas";
            btnDividas.UseVisualStyleBackColor = false;
            btnDividas.Click += btnDividas_Click;
            //
            // ListarClientes
            //
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(900, 555);
            Controls.Add(btnDividas);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnProxima);
            Controls.Add(lblPagina);
            Controls.Add(btnAnterior);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusca);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(918, 602);
            Name = "ListarClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clientes";
            Load += ListarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtBusca;
        private PrimaryButton btnBuscar;
        private DataGridView dgvClientes;
        private PrimaryButton btnAnterior;
        private Label lblPagina;
        private PrimaryButton btnProxima;
        private PrimaryButton btnEditar;
        private PrimaryButton btnExcluir;
        private PrimaryButton btnDividas;
    }
}
