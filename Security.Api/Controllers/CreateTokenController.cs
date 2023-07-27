using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Api.Protos;
using Security.Application.Interface;
using Security.Domain.ViewModels;

namespace Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTokenController : ControllerBase
    {
        private readonly ICreateToken _createToken;

        public CreateTokenController(ICreateToken createToken)
        {
            this._createToken = createToken;
        }
        [HttpPost]
        public async Task<IActionResult> CreatAsync(InputViewModel inputViewModel)
        {
            var result = await _createToken.CreatAsync(inputViewModel.UserId.ToString());
            if (result != null)
            {
                OutputViewModel tokesnView = new OutputViewModel()
                {
                    Token = result
                };
                return Ok(tokesnView);
            }
            else
            {
                var error = new ErrorViewModel
                {
                    Message = "The username is already taken."

                };
                return BadRequest(error);
            }
        }
    }
}
