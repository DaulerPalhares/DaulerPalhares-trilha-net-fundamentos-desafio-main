namespace DesafioFundamentos.Models
{
  public class Veiculos
  {
    public Veiculos(string placa, string DataEntrada){
      this.Placa = placa;
      if(DateTime.TryParse(DataEntrada,out var data))
        this.DataEntrada = data;
      else
        this.DataEntrada = DateTime.Now;
    }
    public string Placa {get;set;}
    public DateTime DataEntrada {get;set;}

    public string SerializeVeiculo(){
      return $"Placa:{this.Placa} | Hora Entrada {this.DataEntrada.ToString("HH:mm")}";
    }
  }
}