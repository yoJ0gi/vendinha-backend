namespace Vendinha.Api.Services
{
    public enum TipoResultado
    {
        Sucesso,
        Invalido,      // dado inválido -> 400
        NaoEncontrado, // cliente ou dívida não existe -> 404
        Conflito       // a regra não permite (CPF repetido, dívida em aberto...) -> 409
    }

    // O que o service devolve ao controller: se deu certo ou o motivo do erro
    public class Resultado
    {
        public TipoResultado Tipo { get; set; }
        public string Mensagem { get; set; }

        public Resultado(TipoResultado tipo, string mensagem)
        {
            Tipo = tipo;
            Mensagem = mensagem;
        }

        public bool DeuCerto
        {
            get { return Tipo == TipoResultado.Sucesso; }
        }

        public static Resultado Sucesso()
        {
            return new Resultado(TipoResultado.Sucesso, "");
        }
    }
}
