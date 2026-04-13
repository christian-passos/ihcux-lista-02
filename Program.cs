using System;
using System.Text.RegularExpressions;

namespace TerminalSuporte.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Terminal de Suporte Proativo";
            Console.WriteLine("Bem-vindo ao Terminal de Suporte Proativo!");
            ExibirMenuComandos();

            while (true)
            {
                Console.Write("\nDigite um comando (ou 'help' para ver as opcoes): ");
                string comando = Console.ReadLine()?.ToLower() ?? string.Empty;

                switch (comando)
                {
                    case "ping":
                        ComandoPing();
                        break;
                    case "formatar unidade":
                        ComandoFormatarUnidade();
                        break;
                    case "help":
                    case "?":
                        ExibirAjuda();
                        break;
                    case "sair":
                        Console.WriteLine("Saindo do Terminal. Ate mais!");
                        return;
                    default:
                        ExibirMensagemErro("Comando invalido. Digite 'help' para ver as opcoes.");
                        break;
                }
            }
        }

        public static void ExibirMenuComandos()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Menu de Comandos Rapidos ---");
            Console.WriteLine("Ping - Verifica a conectividade com um IP.");
            Console.WriteLine("Formatar Unidade - Formata uma unidade de disco (requer confirmacao).");
            Console.WriteLine("Help / ? - Exibe este menu de ajuda.");
            Console.WriteLine("Sair - Encerra o terminal.");
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
        }

        public static void ExibirAjuda()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- Ajuda ---");
            Console.WriteLine("Ping: Testa a conexao com um endereco IP. Exemplo: ping 192.168.1.1");
            Console.WriteLine("Formatar Unidade: Inicia o processo de formatacao de uma unidade. CUIDADO: Esta acao e irreversivel.");
            Console.WriteLine("Help ou ?: Exibe uma lista de todos os comandos disponiveis e suas descricoes.");
            Console.WriteLine("Sair: Fecha o aplicativo do terminal.");
            Console.WriteLine("-----------");
            Console.ResetColor();
        }

        public static void ComandoPing()
        {
            Console.Write("Digite o endereco IP para pingar: ");
            string ip = Console.ReadLine() ?? string.Empty;

            if (ValidarIP(ip))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Pingando {ip}... Resposta recebida!");
                Console.ResetColor();
            }
            else
            {
                ExibirMensagemErro($"IP invalido: '{ip}'. Formato esperado: xxx.xxx.xxx.xxx");
            }
        }

        public static bool ValidarIP(string ip)
        {
            string pattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
            return Regex.IsMatch(ip, pattern);
        }

        public static void ComandoFormatarUnidade()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nATENCAO: Voce esta prestes a formatar uma unidade. Esta acao e IRREVERSIVEL!");
            Console.WriteLine("Confirma a formatacao da unidade? (sim/nao)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Confirmacao: ");
            string confirmacao = Console.ReadLine()?.ToLower() ?? string.Empty;
            Console.ResetColor();

            if (confirmacao == "sim")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Unidade formatada com sucesso!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Formatacao cancelada.");
                Console.ResetColor();
            }
        }

        public static void ExibirMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERRO: {mensagem}");
            Console.ResetColor();
        }
    }
}