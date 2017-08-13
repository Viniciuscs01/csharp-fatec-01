using System;
using System.Collections.Generic;
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
        private static ConsoleColor defaultColor = ForegroundColor;
        private static List<string> competencias = new List<string>();

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
            SolicitaAltura();
            SolicitaDataNasc();
            SolicitaCompetencias();

            ValidaInformacoes();
        }

        private static void SolicitaCompetencias()
        {
            string resposta;
            if(competencias.Count == 0)
                WriteLine("Deseja cadastrar competências? Digite S para Sim e N para Não (Default: S).");            
            else
                WriteLine("Deseja cadastrar uma nova competencia? Digite S para Sim e N para Não (Default: S).");                
            
            resposta = ReadLine();
            if (string.IsNullOrWhiteSpace(resposta) || resposta.ToUpper() == "S")
            {
                SolicitaCompetencia();
                SolicitaCompetencias();
            }
            else if (resposta.ToUpper() != "N")
            {
                WriteLine("Informe um valor válido.");
                SolicitaCompetencias();
            }

            void SolicitaCompetencia()
            {
                WriteLine("Informe a competencia:");
                string comp = ReadLine();
                if (string.IsNullOrWhiteSpace(comp))
                {
                    WriteLine("Informe uma competencia válida!");
                    SolicitaCompetencia();
                }
                else
                    competencias.Add(comp);
            }
        }

        private static void SolicitaDataNasc()
        {
            WriteLine("Informe sua data de nascimento:");
            try
            {
                dataNasc = Convert.ToDateTime(ReadLine());
            }
            catch (Exception)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Informe sua data de nascimento no formato dd/MM/AAAA");
                ForegroundColor = defaultColor;
                SolicitaDataNasc();
            }
        }

        private static void SolicitaAltura()
        {
            WriteLine("Informe a altura");
            try
            {                
                altura = Convert.ToDouble(ReadLine());
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Insira corretamente sua altura!");
                ForegroundColor = defaultColor;
                SolicitaAltura();
            }
        }

        private static void ValidaInformacoes()
        {
            WriteLine();
            WriteLine("Informações Inseridas:");
            WriteLine($"Nome: {nome}");
            WriteLine($"RA: {ra.PadLeft(ra.Length -1, '-')}");
            WriteLine($"Email: {email}");
            WriteLine($"Altura: {altura.ToString("0.00")}m");
            WriteLine($"Data de Nascimento: {dataNasc.ToString("dd/MM/yyyy")}");
            WriteLine("Competências:");
            competencias.ForEach(gravaCompetencia);

            WriteLine();
            ObtemEscolha();
        }

        static void gravaCompetencia(string comp) => Write($"{comp};");

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
