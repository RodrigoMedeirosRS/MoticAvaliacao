using System;
using System.Text;
using System.Linq;

namespace BLL.Utils
{
    public static class ValidadorUtils
    {
        public static void ValidarCPF(string cpf)
        {
            ValidarQuantidadeDeDigitos(cpf);
            ValidarSomaDeDigitos(cpf);
        }

        static internal void ValidarSenha(string senha)
        {
            if(senha.Length < 8)
                throw new Exception("Usuário ou senha inválido.");
        }

        private static void ValidarQuantidadeDeDigitos(string cpf)
        {
            if (cpf.Length < 11 || !cpf.All(char.IsDigit))
                throw new Exception("CPF Inválido, favor inserir um CPF com 11 dígitos.");
        }

        private static void ValidarSomaDeDigitos(string cpf)
        {
            var soma = 0;
            
            foreach(var digito in cpf)
                soma += (int)Char.GetNumericValue(digito);

            var somaString = soma.ToString();
            
            if (somaString[0] != somaString[1])
                throw new Exception("CPF Inválido");
        }

        public static string CriarMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
}