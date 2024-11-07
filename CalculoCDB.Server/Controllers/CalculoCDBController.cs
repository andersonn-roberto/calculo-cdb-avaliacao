using CalculoCDB.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoCdbController(ICalculoCdbService calculoCdbService) : ControllerBase
    {
        private readonly ICalculoCdbService _calculoCdbService = calculoCdbService;

        [HttpPost]
        [ProducesResponseType(typeof(ResultadoCalculo), 200)]
        [ProducesResponseType(typeof(ArgumentException), 400)]
        public IActionResult Calcular([FromBody] DadosEntrada request)
        {
            if (request.ValorInicial <= 0)
            {
                return BadRequest(new ArgumentException("O valor inicial deve ser um valor monetário positivo."));
            }

            if (request.QuantidadeMeses <= 1)
            {
                return BadRequest(new ArgumentException("O prazo em meses deve ser maior que 1(um)."));
            }

            return Ok(_calculoCdbService.Calcular(request.ValorInicial, request.QuantidadeMeses));
        }
    }
}
