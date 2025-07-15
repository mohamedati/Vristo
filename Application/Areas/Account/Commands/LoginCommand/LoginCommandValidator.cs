using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Resources;

namespace Application.Areas.Account.Commands.LoginCommand
{
    public  class LoginCommandValidator : AbstractValidator<LoginCommand> 
    {
        public LoginCommandValidator(IAppDbContext appDb,IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(localizer["Required"]);

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(localizer["Required"]);
        }
    }
}
