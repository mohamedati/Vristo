using API.Extentions;
using Application.Areas.Account.Commands.LoginCommand;
using Application.Areas.Account.Commands.RefreshTokenCommand;
using Application.Areas.Account.Commands.RegisterCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController(ISender sender) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
           
            return await sender.Send(command).ToGenericResponse();
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }
    }
}
