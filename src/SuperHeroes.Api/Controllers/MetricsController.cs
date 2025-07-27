using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.UseCases.Metrics.GetAll;
using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseMetricsJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IGetAllMetricsUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }
    }
}
