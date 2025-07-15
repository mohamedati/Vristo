using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.LoginCommand
{
    public class LoginCommand:IRequest<LoginDTO>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class LoginCommandHandler
        (IAppDbContext appDb, 
        ICurrentUserService currentUser,
        IJWTService jWT
        , IStringLocalizer<Resources.Resources> localizer,
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager,
        IConfiguration config
      )
        : IRequestHandler<LoginCommand, LoginDTO>
    {
        public async  Task<LoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
          


            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);
                if (result.Succeeded)
                {
                    var token = await jWT.GenerateToken(user);
                    var RefreshToken = jWT.GenerateRefreshToken();

                    user.RefreshToken = RefreshToken;
                    user.RefreshTokenExpiredAt = DateTime.Now.AddMinutes(int.Parse(config["JWT:RefreshTokenExpiresInMinutes"]));
                    await userManager.UpdateAsync(user);
                   

                    return new LoginDTO
                    {
                        Token = token,
                        RefreshToken = jWT.GenerateRefreshToken()
                    };


                }

            }
            throw new ItemNotFoundException(localizer["NotFound"]);

               





        }
    }
}
