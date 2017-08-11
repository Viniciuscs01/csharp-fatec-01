using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Fatec.Cadastro
{
    class Program
    {
        private static string nome;
        private static string ra;
        private static string email;
        private static double altura;
        private static DateTime dataNasc;

        static void Main(string[] args)
        {
            ProcessaCadastro();
            ReadKey();
        }

        private static void ProcessaCadastro()
        {
            SolicitaNome();
            SolicitaRA();
            SolicitaEmail();
            ValidaInformacoes();
        }

        private static void ValidaInformacoes()
        {
            WriteLine();
            WriteLine("Informações Inseridas:");
            WriteLine($"Nome: {nome}");
            WriteLine($"RA: {ra}");
            WriteLine($"Email: {email}");
            WriteLine();
            ObtemEscolha();
        }

        private static void ObtemEscolha()
        {
            WriteLine("Deseja prosseguir com o cadastro?");
            WriteLine("Digite S para prosseguir ou N para reiniciar o cadastro. Default: S");
            var opcao = ReadLine();
            if (string.IsNullOrEmpty(opcao) || opcao.ToLower().Equals("s"))
                SalvaRegistro();
            else if (opcao.ToLower().Equals("n"))
            {
                Clear();
                ProcessaCadastro();
            }
            else
                ObtemEscolha();
        }
        
        private static void SalvaRegistro() => WriteLine("Registro Salvo com Sucesso");

        private static void SolicitaEmail()
        {
            WriteLine("Informe o e-mail");
            email = ReadLine();
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                SolicitaEmail();
        }

        private static void SolicitaNome()
        {
            WriteLine("Informe o Nome:");
            nome = ReadLine();
            if (String.IsNullOrEmpty(nome))
                SolicitaNome();
        }

        private static void SolicitaRA()
        {
            WriteLine("Informe o RA de 7 digitos:");
            ra = ReadLine();
            if (String.IsNullOrEmpty(ra) || ra.Length != 7 || !int.TryParse(ra, out int result))
                SolicitaRA();
        }
    }
}
