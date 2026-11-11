namespace Vendinha.Desktop.Componentes
{
    // botão padrão das telas: herda de Button e só muda a aparência
    public class PrimaryButton : Button
    {
        public PrimaryButton()
        {
            BackColor = Color.FromArgb(0, 120, 215);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Arial", 12F);
            Cursor = Cursors.Hand;
        }
    }
}
