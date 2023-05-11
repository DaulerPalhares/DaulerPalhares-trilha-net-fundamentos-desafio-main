namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<Veiculos> veiculos = new List<Veiculos>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
      // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
      // *IMPLEMENTE AQUI*
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      var novaPlaca = Console.ReadLine();
      Console.WriteLine("Digite a hora de entrada HH:mm (vazio pega a hora atual):");
      var horaEntrada = Console.ReadLine();
      veiculos.Add(new Veiculos(novaPlaca,horaEntrada));
    }

    public void RemoverVeiculo()
    {
      // Pedir para o usuário digitar a placa e armazenar na variável placa
      Console.WriteLine("Digite a placa do veículo para remover:");
      string placa = Console.ReadLine();


      var veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());
      // Verifica se o veículo existe
      if (veiculo != null)
      {
        Console.WriteLine("Digite a hora da saída HH:mm (vazio pega a hora atual):");
        var horaSaida = Console.ReadLine();
        DateTime.TryParse(horaSaida,out var horaFormatada);

        var totalHoras = horaFormatada - veiculo.DataEntrada;
        if(totalHoras.TotalHours < 1 && totalHoras.TotalMinutes <= 15){
          Console.WriteLine($"O veículo {veiculo.Placa} ficou menos de 15 minutos");
          Console.WriteLine($"Estadia minima não foi alcançada, Retirada Gratuita:");
          Console.WriteLine("1 - Confirmar");
          Console.WriteLine("qualquer outro - Cancelar");
          if( Console.ReadLine() == "1"){
            Console.WriteLine($"O veículo {veiculo.Placa} foi retirado do estacionamento e não precisou pagar nada.");
            veiculos.Remove(veiculo);
          }
        }
        else
        {
          var valorTotal = precoInicial+((decimal)totalHoras.TotalHours*precoPorHora);
          Console.WriteLine($"O veículo {veiculo.Placa} ficou {totalHoras.TotalHours} horas.");
          Console.WriteLine($"O valor a ser pago será R${valorTotal}");
          Console.WriteLine($"Confirme o pagamento:");
          Console.WriteLine("1 - Confirmar");
          Console.WriteLine("qualquer outro - Cancelar");

          if( Console.ReadLine() == "1"){
            Console.WriteLine($"O veículo {veiculo.Placa} foi retirado do estacionamento e o preço total pago foi de: R$ {valorTotal}");
            veiculos.Remove(veiculo);
          }
          else{
            Console.WriteLine($"O pagamento foi cancelado.");
          }
        }
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
        foreach (var veiculo in veiculos)
        {
          Console.WriteLine(veiculo.SerializeVeiculo());
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}
