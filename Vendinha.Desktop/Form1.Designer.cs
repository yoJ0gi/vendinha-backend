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
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(260, 220);
            button1.Name = "button1";
            button1.Size = new Size(280, 52);
            button1.TabIndex = 1;
            button1.Text = "Listar clientes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            //
            // button2
            //
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            button2.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            button2.ForeColor = Color.FromArgb(51, 65, 85);
            button2.Location = new Point(260, 286);
            button2.Name = "button2";
            button2.Size = new Size(280, 52);
            button2.TabIndex = 2;
            button2.Text = "Cadastrar cliente";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            //
            // label1
            //
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI Semibold", 32F);
            label1.ForeColor = Color.FromArgb(15, 23, 42);
            label1.Location = new Point(0, 105);
            label1.Name = "label1";
            label1.Size = new Size(800, 75);
            label1.TabIndex = 0;
            label1.Text = "Vendinha";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vendinha";
            ResumeLayout(false);
        }

        #endregion

        private PrimaryButton button1;
        private PrimaryButton button2;
        private Label label1;
    }
}
