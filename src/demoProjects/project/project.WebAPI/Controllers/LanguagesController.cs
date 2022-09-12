using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Application.Features.Languages.Commands.CreateLanguage;
using project.Application.Features.Languages.Commands.DeleteLanguage;
using project.Application.Features.Languages.Commands.UpdateLanguage;
using project.Application.Features.Languages.Dtos;
using project.Application.Features.Languages.Models;
using project.Application.Features.Languages.Queries.GetAllLanguage;
using project.Application.Features.Languages.Queries.GetByIdLanguage;
using project.Application.Features.Languages.Queries.GetListLanguage;

namespace project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Ok("Success");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok("Success");
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllLanguageQuery getAllLanguageQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getAllLanguageQuery);

            return Ok(result);
        }
    }
}
