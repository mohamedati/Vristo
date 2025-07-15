using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Areas.Account.Commands.LoginCommand;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.RefreshTokenCommand
{
    public  class RefreshTokenCommand:IRequest<LoginDTO>
    {
        public string Token { get; set; } = null!;
    }


    public class RefreshTokenCommandHandler(IAppDbContext appDb,
    
        IJWTService jWT
       , IStringLocalizer<Resources.Resources> localizer,
    
        UserManager<ApplicationUser> userManager,
        IConfiguration config)
        : IRequestHandler<RefreshTokenCommand, LoginDTO>
    {
        public async  Task<LoginDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.Where(a => a.RefreshToken == request.Token).FirstOrDefault();

            if (user is null || user.RefreshTokenExpiredAt <DateTime.Now)
                throw new ForbiddenAccessException(localizer["InvalidToken"]);


            var token = await jWT.GenerateToken(user);
            var RefreshToken = jWT.GenerateRefreshToken();
            user.RefreshToken = RefreshToken;
            user.RefreshTokenExpiredAt = DateTime.Now.AddMinutes(int.Parse(config["RefreshTokenExpiresInMinutes"]));
            await userManager.UpdateAsync(user);


            return new LoginDTO
            {
                Token = token,
                RefreshToken = jWT.GenerateRefreshToken()
            };




        }
    }


}
