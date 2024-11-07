namespace CalculoCDB.Server.Services.Interfaces
{
    public interface ICalculoCdbService
    {
        public ResultadoCalculo Calcular(double valorInicial, int quantidadeMeses);
    }
}
