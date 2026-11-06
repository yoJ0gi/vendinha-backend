namespace Vendinha.Api.Utils
{
        public static class ValidadorCpf
    {
        
        public static string SomenteNumeros(string cpf)
        {
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        public static bool EhValido(string cpf)
        {
            cpf = SomenteNumeros(cpf);

            if (cpf.Length != 11)
                return false;

            
            if (cpf.All(c => c == cpf[0]))
                return false;

            var primeiroDigito = CalcularDigito(cpf.Substring(0, 9), 10);
            var segundoDigito = CalcularDigito(cpf.Substring(0, 10), 11);

            return cpf[9] - '0' == primeiroDigito && cpf[10] - '0' == segundoDigito;
        }

        private static int CalcularDigito(string numeros, int pesoInicial)
        {
            var soma = 0;
            for (var i = 0; i < numeros.Length; i++)
            {
                soma += (numeros[i] - '0') * (pesoInicial - i);
            }

            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
