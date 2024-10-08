using System;
using SistemaEstacionamento.Models;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Limpa o console e adiciona o encoding para UTF8, para evitar possíveis problemas com as acentuações.
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento.");

            Console.WriteLine("\nDigite o preço inicial:");
            decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o preço por hora:");    
            decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

            // Instanciamento da classe Estacionamento num objeto, com os valores obtidos anteriormente.
            Estacionamento objetoEstacionamento = new Estacionamento(precoInicial, precoPorHora);

            string opcao = string.Empty;
            bool exibirMenu = true;

            // Caso os valores definidos nas variáveis precoInicial e precoPorHora sejam maiores que 0, inicia-se o loop do menu, do contrário, é necessário tentar novamente.
            if (precoInicial > 0 && precoPorHora > 0)
            {
                while (exibirMenu)
                {
                    Console.Clear();
                    Console.WriteLine("Digite a sua opção:\n");
                    Console.WriteLine("1 - Cadastrar placa do veículo.");
                    Console.WriteLine("2 - Listar veículos cadastrados.");
                    Console.WriteLine("3 - Remover veículo.");
                    Console.WriteLine("4 - Encerrar o programa.\n");

                    switch (opcao = Console.ReadLine())
                    {
                        case "1":
                            objetoEstacionamento.AdicionarVeiculos();
                            break;

                        case "2":
                            objetoEstacionamento.ListarVeiculos();
                            break;
                    
                        case "3":
                            objetoEstacionamento.RemoverVeiculos();
                            break;

                        case "4":
                            exibirMenu = false;
                            Console.WriteLine("\nMuito obrigado por utilizar o sistema.");
                            break;

                        default:
                            Console.WriteLine("\nOpção inválida, tente novamente.");
                            break;
                    }

                    Console.WriteLine("\nPressione a tecla ENTER para continuar.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Você não pode colocar o valor ''0'' nas opções de preço inicial e preço por hora. Tente novamente.");
            }
            
        }
    }
}
