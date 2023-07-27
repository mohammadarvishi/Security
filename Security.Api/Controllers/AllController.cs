using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Interface;
using Security.Application.Services;
using Security.Domain.ViewModels;

namespace Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllController : ControllerBase
    {
        private readonly IReturnAll _returnAll;

        public AllController(IReturnAll returnAll)
        {
            this._returnAll = returnAll;
        }

        [HttpPost]
        public async Task<IActionResult> AllAsync()
        {
            var result = await _returnAll.AllAsync();
            return Ok(result);
           
        }
    }
}
