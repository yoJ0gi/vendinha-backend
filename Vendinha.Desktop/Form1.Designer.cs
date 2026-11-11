using Vendinha.Desktop.Componentes;

namespace Vendinha.Desktop
{
    partial class Form1
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
            button1 = new PrimaryButton();
            button2 = new PrimaryButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(35, 126);
            button1.Name = "button1";
            button1.Size = new Size(250, 60);
            button1.TabIndex = 1;
            button1.Text = "Listar clientes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial", 12F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(35, 192);
            button2.Name = "button2";
            button2.Size = new Size(250, 60);
            button2.TabIndex = 2;
            button2.Text = "Cadastrar cliente";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 32F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(251, 26);
            label1.Name = "label1";
            label1.Size = new Size(206, 61);
            label1.TabIndex = 0;
            label1.Text = "Vendinha";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Vendinha";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PrimaryButton button1;
        private PrimaryButton button2;
        private Label label1;
    }
}
