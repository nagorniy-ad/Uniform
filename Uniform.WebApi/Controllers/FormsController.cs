using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Uniform.Core.Dtos;
using Uniform.Core.Services;

namespace Uniform.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        [HttpPost]
        public async Task<IActionResult> SaveFormAsync(SaveFormInput input)
        {
            await _formService.SaveFormAsync(input);
            return Ok();
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchFormAsync(SearchFormInput input)
        {
            var output = await _formService.SearchFormAsync(input);
            return Ok(output);
        }
    }
}
