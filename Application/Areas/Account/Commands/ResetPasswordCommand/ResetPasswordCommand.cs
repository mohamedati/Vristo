using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.ResetPasswordCommand
{
    public  class ResetPasswordCommand:IRequest
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }

    public class ResetPasswordCommandHandler
          (IAppDbContext appDb,
        IEmailSender emailSender,
        IStringLocalizer<Resources.Resources> localizer,
        UserManager<ApplicationUser> userManage)
        : IRequestHandler<ResetPasswordCommand>
    {
        public async  Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
           var user=await userManage.FindByEmailAsync(request.Email);

            if (user == null)
                throw new ItemNotFoundException(localizer["NotFound"]);

            var decodedToken = WebUtility.UrlDecode(request.Token); // Important if token came via URL

            var result = await userManage.ResetPasswordAsync(user, decodedToken, request.NewPassword);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMessage);
            }
        }
    }

}
