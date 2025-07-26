using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.UseCases.SuperHeroes.GetAll;
using SuperHeroes.Application.UseCases.SuperHeroes.Register;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSuperHeroRegisteredJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterSuperHeroUseCase useCase,
            [FromBody] RequestRegisterSuperHeroJson request
        )
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseSuperHeroesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllSuperHeroesUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.SuperHeroes.Count == 0)
                return NoContent();

            return Ok(response);
        }
    }
}
