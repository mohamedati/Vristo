using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Account.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommand>
    {
        private readonly IStringLocalizer<Resources.Resources> localizer;

        public RefreshTokenCommandValidator(IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage(localizer["Required"]);
            this.localizer = localizer;
        }
    }
}
