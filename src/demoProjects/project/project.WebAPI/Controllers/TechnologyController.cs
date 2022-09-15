using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Application.Features.Languages.Commands.CreateLanguage;
using project.Application.Features.Technologies.Commands.CreateTechnolgy;
using project.Application.Features.Technologies.Dtos;

namespace project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }
    }
}
