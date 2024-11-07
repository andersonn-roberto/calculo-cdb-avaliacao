using CalculoCDB.Server.Services.Interfaces;

namespace CalculoCDB.Server.Services
{
    public class CalculoCdbService : ICalculoCdbService
    {
        public ResultadoCalculo Calcular(double valorInicial, int quantidadeMeses)
        {
            double percentualCdi = 0.009;
            double percentualBancoSobreCdi = 1.08;

            double valorBruto = CalcularValorBruto(valorInicial, quantidadeMeses, percentualCdi, percentualBancoSobreCdi);
            double valorLiquido = valorBruto - CalcularImposto(valorBruto - valorInicial, quantidadeMeses);

            return new ResultadoCalculo(valorBruto, valorLiquido);
        }

        private static double CalcularValorBruto(double valorInicial, int quantidadeMeses, double percentualCdi, double percentualBancoSobreCdi)
        {
            double valorBruto = valorInicial;
            for (int i = 0; i < quantidadeMeses; i++)
            {
                valorBruto *= (1 + (percentualCdi * percentualBancoSobreCdi));
            }
            return valorBruto;
        }

        private static double CalcularImposto(double valorLucro, int quantidadeMeses)
        {
            return quantidadeMeses switch
            {
                <= 6 => valorLucro * 0.225,
                <= 12 => valorLucro * 0.20,
                <= 24 => valorLucro * 0.175,
                _ => valorLucro * 0.15
            };
        }
    }
}
