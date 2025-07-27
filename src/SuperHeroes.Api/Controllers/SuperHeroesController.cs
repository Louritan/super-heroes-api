using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.UseCases.SuperHeroes.Delete;
using SuperHeroes.Application.UseCases.SuperHeroes.GetAll;
using SuperHeroes.Application.UseCases.SuperHeroes.GetById;
using SuperHeroes.Application.UseCases.SuperHeroes.Register;
using SuperHeroes.Application.UseCases.SuperHeroes.Update;
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
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterSuperHeroUseCase useCase,
            [FromBody] RequestSuperHeroJson request
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseSuperHeroJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetSuperHeroByIdUseCase useCase,
            [FromRoute] int id
        )
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateSuperHeroUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestSuperHeroJson request
        )
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteSuperHeroUseCase useCase,
            [FromRoute] int id
        )
        {
            await useCase.Execute(id);
            return NoContent();
        }
    }
}
