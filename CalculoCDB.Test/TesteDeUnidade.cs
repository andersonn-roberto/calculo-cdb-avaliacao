using CalculoCDB.Server;
using CalculoCDB.Server.Controllers;
using CalculoCDB.Server.Services;
using CalculoCDB.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoCDB.Test
{
    public class TesteDeUnidade
    {
        [Theory]
        [InlineData(1000, 6, 1059.76, 1046.31)]
        [InlineData(1000, 12, 1123.08, 1098.47)]
        [InlineData(1000, 24, 1261.31, 1215.58)]
        [InlineData(1000, 36, 1416.56, 1354.07)]

        public void Calcular_DeveRetornarValorBrutoValorLiquido_QuandoAsInformacoesEstaoCorretas(double valorInicial, int quantidadeMeses, double valorBruto, double valorLiquido)
        {
            var sut = new CalculoCdbService();

            var actual = sut.Calcular(valorInicial, quantidadeMeses);

            Assert.Equal(valorBruto, actual.ValorBruto, 2);
            Assert.Equal(valorLiquido, actual.ValorLiquido, 2);
        }

        [Theory]
        [InlineData(1000, 6, 1059.76, 1046.31)]
        public void Controller_DeveRetornarValorBrutoValorLiquido_QuandoAsInformacoesEstaoCorretas(double valorInicial, int quantidadeMeses, double valorBruto, double valorLiquido)
        {
            var mockService = new Mock<ICalculoCdbService>();
            mockService.Setup(mockService => mockService.Calcular(valorInicial, quantidadeMeses)).Returns(new ResultadoCalculo(valorBruto, valorLiquido));

            var result = new CalculoCdbController(mockService.Object).Calcular(new DadosEntrada(valorInicial, quantidadeMeses));
            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);

            var value = okResult.Value as ResultadoCalculo;
            Assert.NotNull(value);
            Assert.Equal(valorBruto, value!.ValorBruto, 2);
            Assert.Equal(valorLiquido, value!.ValorLiquido, 2);
        }

        [Theory]
        [InlineData(0, 12, "O valor inicial deve ser um valor monetário positivo.")]
        [InlineData(1000, 1, "O prazo em meses deve ser maior que 1(um).")]

        public void Controller_DeveRetornarBadRequestComMensagem_QuandoAlgumaInformacaoEstaEmDesacordo(double valorInicial, int quantidadeMeses, string mensagem)
        {
            var mockService = new Mock<ICalculoCdbService>();
            var result = new CalculoCdbController(mockService.Object).Calcular(new DadosEntrada(valorInicial, quantidadeMeses));
            Assert.IsType<BadRequestObjectResult>(result);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);

            var value = badRequestResult.Value as ArgumentException;
            Assert.NotNull(value);
            Assert.Equal(mensagem, value!.Message);
        }
    }
}