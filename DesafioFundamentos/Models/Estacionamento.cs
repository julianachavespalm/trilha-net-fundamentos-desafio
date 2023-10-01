namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Implementação: Solicitação de nomenclatura da placa
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novaPlaca = Console.ReadLine();

            // Implementação: adicionar novaPlaca à lista "veiculos" 
            // se não for valor em branco ou duplicado.
            if (!string.IsNullOrWhiteSpace(novaPlaca) && !veiculos.Contains(novaPlaca))
            {
                // Adiciona a nova placa à lista "veiculos"
                veiculos.Add(novaPlaca);
                Console.WriteLine($"A nova placa {novaPlaca} foi adicionada com sucesso!");
            }
            else
            {
                // Não adiciona a nova placa à lista "veiculos"
                Console.WriteLine($"A placa {novaPlaca} não foi adicionada.");
                Console.WriteLine("Valor em branco ou duplicado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Implementação: armazena em "placa" o valor digitado pelo usuário
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                decimal valorTotal = 0;

                while (true)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    // Implementação: realiza a validação do valor digitado para quantidade de horas
                    string validacaoHoras = Console.ReadLine();

                    // Declara que horas é um decimal se não for um valor em branco ou nulo
                    decimal horas;
                    if (string.IsNullOrWhiteSpace(validacaoHoras) || !decimal.TryParse(validacaoHoras, out horas))
                    {
                        Console.WriteLine($"Você inseriu o valor {validacaoHoras}.");
                        Console.WriteLine("Por favor, insira um valor válido para horas.");
                    }
                    // Se o valor de horas for válido, calcula o valor total
                    else
                    {
                        valorTotal = precoInicial + (horas * precoPorHora);
                        break;
                    }
                }

                // Remove a placa da lista "veiculos"
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Implementação: laço de repetição foreach para exibir a lista de veículos
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
