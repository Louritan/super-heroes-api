using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.UseCases.SuperPowers.GetAll;
using SuperHeroes.Application.UseCases.SuperPowers.Register;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperPowersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSuperPowerRegisteredJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterSuperPowerUseCase useCase,
            [FromBody] RequestRegisterSuperPowerJson request
        )
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseSuperPowersJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllSuperPowersUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.SuperPowers.Count == 0)
                return NoContent();

            return Ok(response);
        }
    }
}
