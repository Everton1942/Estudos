using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> listaVeiculos = new List<string>();

        // Construtor da classe que inicializa as propriedades da mesma.
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Faz a solicitação de uma placa para que ela seja adicionada. Se a placa já estiver cadastrada, for vazia ou composta apenas por espaços em branco, ela não será cadastrada.
        public void AdicionarVeiculos()
        {
            string veiculo;

            Console.WriteLine("\nInsira a placa do veículo: ");
            veiculo = Console.ReadLine();

            if (listaVeiculos.Any(x => x.ToUpper() == veiculo.ToUpper()))
            {
                Console.WriteLine("\nEsta placa já está cadastrada no sistema.");
            }
            else if (!string.IsNullOrWhiteSpace(veiculo))
            {
                listaVeiculos.Add(veiculo);
                Console.WriteLine("\nVeículo adicionado.");
            }
            else
            {
                Console.WriteLine("\nVocê não pode digitar uma placa em branco, tente novamente.");
            }
        }

        // Apresenta todas as placas armazenadas na lista "listaVeiculos", iniciando pelo índice 0.
        public void ListarVeiculos()
        {
            if (listaVeiculos.Count > 0)
            {
                Console.WriteLine("\nAs placas dos veículos estacionados são: ");

                foreach (string veiculosArmazenados in listaVeiculos)
                {
                    Console.WriteLine(veiculosArmazenados);
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }

        /* Solicita para que o usuário informe a placa que deseja remover. Se ela estiver presente na lista, também será solicitado que o usuário informe quantas horas passou no estacionamento para que um cálculo seja feito e apresentado. */
        public void RemoverVeiculos()
        {
            Console.WriteLine("\nDigite a placa do veículo que você deseja remover: ");
            string veiculo = Console.ReadLine();            

            // Faz a verificação se a placa está presente na "listaVeiculos", caso sim, prossegue com a remoção da mesma.
            if (listaVeiculos.Any(x => x.ToUpper() == veiculo.ToUpper()))
            {
                Console.WriteLine("\nAgora informe quantas horas o veículo ficou no estacionamento: ");
                int horasTotais = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horasTotais;

                listaVeiculos.Remove(veiculo);

                Console.WriteLine($"\nO veículo de placa ''{veiculo}'' foi removido com sucesso!");

                Console.WriteLine($"O valor a ser pago pela estadia no estacionamento é de: R${valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado no sistema.");
            }
        }
    }
}