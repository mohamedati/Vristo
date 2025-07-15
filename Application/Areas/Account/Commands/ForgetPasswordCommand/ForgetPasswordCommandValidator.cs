using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.ForgetPasswordCommand
{
    public  class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand> 
    {
        private readonly IStringLocalizer<Resources.Resources> localizer;

        public ForgetPasswordCommandValidator(IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(localizer["Required"]);
            this.localizer = localizer;
        }
    }
}
