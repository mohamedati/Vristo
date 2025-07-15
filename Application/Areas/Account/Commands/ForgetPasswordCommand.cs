using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands
{
    public  class ForgetPasswordCommand :IRequest
    {
        public string Email { get; set; } = null!;
    }

    public class ForgetPasswordCommandHandler (
        IAppDbContext appDb,
        IEmailSender emailSender,
        IStringLocalizer<Resources.Resources> localizer,
        UserManager<ApplicationUser> userManager) : IRequestHandler<ForgetPasswordCommand>
    {
        public async  Task Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ItemNotFoundException(localizer["NotFound"]);

            var Token = await userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"https://https:4200/reset-password?token={HttpUtility.UrlEncode(Token)}&email={HttpUtility.UrlEncode(user.Email)}";

             emailSender.SendEmail(user.Email, "Reset Password Link From Vristo Market", resetLink);

        }
    }
}
