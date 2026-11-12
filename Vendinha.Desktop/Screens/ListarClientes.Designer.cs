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
            lblTitulo = new Label();
            txtBusca = new TextBox();
            btnBuscar = new PrimaryButton();
            dgvClientes = new DataGridView();
            btnAnterior = new PrimaryButton();
            lblPagina = new Label();
            btnProxima = new PrimaryButton();
            btnEditar = new PrimaryButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 20F);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(129, 39);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Clientes";
            // 
            // txtBusca
            // 
            txtBusca.Font = new Font("Arial", 12F);
            txtBusca.Location = new Point(30, 82);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Buscar por nome";
            txtBusca.Size = new Size(400, 30);
            txtBusca.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(445, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 42);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(30, 135);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(840, 330);
            dgvClientes.TabIndex = 3;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(30, 485);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(140, 45);
            btnAnterior.TabIndex = 4;
            btnAnterior.Text = "< Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Font = new Font("Arial", 12F);
            lblPagina.ForeColor = Color.White;
            lblPagina.Location = new Point(190, 497);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(120, 23);
            lblPagina.TabIndex = 5;
            lblPagina.Text = "Página 1 de 1";
            // 
            // btnProxima
            // 
            btnProxima.Location = new Point(360, 485);
            btnProxima.Name = "btnProxima";
            btnProxima.Size = new Size(140, 45);
            btnProxima.TabIndex = 6;
            btnProxima.Text = "Próxima >";
            btnProxima.UseVisualStyleBackColor = false;
            btnProxima.Click += btnProxima_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(730, 485);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(140, 45);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // ListarClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(900, 560);
            Controls.Add(btnEditar);
            Controls.Add(btnProxima);
            Controls.Add(lblPagina);
            Controls.Add(btnAnterior);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusca);
            Controls.Add(lblTitulo);
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
    }
}
