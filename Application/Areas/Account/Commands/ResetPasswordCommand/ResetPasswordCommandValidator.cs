using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.ResetPasswordCommand
{
    public  class ResetPasswordCommandValidator:AbstractValidator<ResetPasswordCommand>
    {
        private readonly IStringLocalizer<Resources.Resources> localizer;

        public ResetPasswordCommandValidator(IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage(localizer["Required"]);

            RuleFor(x => x.Email)
          .NotEmpty()
          .WithMessage(localizer["Required"]);


            RuleFor(x => x.NewPassword)
          .NotEmpty()
          .WithMessage(localizer["Required"]);
            this.localizer = localizer;
        }
    }
}
