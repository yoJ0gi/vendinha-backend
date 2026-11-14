namespace Vendinha.Desktop.Componentes
{
    // botão padrão das telas: herda de Button e só muda a aparência
    public class PrimaryButton : Button
    {
        public PrimaryButton()
        {
            BackColor = Color.FromArgb(37, 99, 235);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            // cores quando o mouse passa por cima e quando o botão é clicado
            FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175);
            Font = new Font("Segoe UI Semibold", 11F);
            Cursor = Cursors.Hand;
        }
    }
}
