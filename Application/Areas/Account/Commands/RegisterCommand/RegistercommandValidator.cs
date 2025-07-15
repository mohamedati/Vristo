using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.RegisterCommand
{
    public  class RegistercommandValidator:AbstractValidator<RegisterCommand>
    {
        private readonly IStringLocalizer<Resources.Resources> localizer;

        public RegistercommandValidator(IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(localizer["Required"]);

            RuleFor(x => x.Email)
          .NotEmpty()
          .WithMessage(localizer["Required"]);


            RuleFor(x => x.Password)
          .NotEmpty()
          .WithMessage(localizer["Required"]);
            this.localizer = localizer;
        }
    }
}
