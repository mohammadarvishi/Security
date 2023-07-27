using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Interface;
using Security.Application.Services;
using Security.Domain.ViewModels;

namespace Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteTokenController : ControllerBase
    {
        private readonly IDeleteToken _deleteToken;

        public DeleteTokenController(IDeleteToken deleteToken)
        {
            this._deleteToken = deleteToken;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(InputViewModel inputViewModel)
        {
            var result = await _deleteToken.DeleteAsync(inputViewModel.UserId);
            if (result)
            {
                return Ok();
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
