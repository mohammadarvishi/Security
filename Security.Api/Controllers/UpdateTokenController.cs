using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Interface;
using Security.Domain.ViewModels;

namespace Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateTokenController : ControllerBase
    {
        private readonly IUpdateToken _updateToken;

        public UpdateTokenController(IUpdateToken updateToken)
        {
            this._updateToken = updateToken;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(InputViewModel inputViewModel)
        {
            var result = await _updateToken.UpdateAsync(inputViewModel.UserId.ToString());
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
                    Message = "Username not found."

                };
                return BadRequest(error);
            }
        }
    }
}
