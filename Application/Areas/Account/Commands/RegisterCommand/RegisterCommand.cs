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

namespace Application.Areas.Account.Commands.RegisterCommand
{
    public  class RegisterCommand:IRequest
    {
        public string Email {  get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserName { get; set; } = null!;
    }

    public class RegisterCommandHandler
            (IAppDbContext appDb,
 
         IStringLocalizer<Resources.Resources> localizer,
     
        UserManager<ApplicationUser> userManager,
        IConfiguration config
      ) : IRequestHandler<RegisterCommand>
    {
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

          

            var userEmail = await userManager.FindByEmailAsync(request.Email);
            if (userEmail !=null)
            
                throw new Exception(localizer["AlreadyExistEmail"]);
            

            var userName = await userManager.FindByNameAsync(request.UserName);

            if (userName != null)

                throw new Exception(localizer["AlreadyExistUserName"]);

            if (userEmail == null && userName == null)
            {
                var user = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    EmailConfirmed = true,



                };

               var result= await userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"User creation failed: {errors}");
                }
            }

            

        }
    }
    }
