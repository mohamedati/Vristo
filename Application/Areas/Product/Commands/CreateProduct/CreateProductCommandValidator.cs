﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Product.Commands.CreateProduct
{
    public  class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        private readonly IAppDbContext appDb;
        private readonly IStringLocalizer<Resources.Resources> localizer;

        public CreateProductCommandValidator(IAppDbContext appDb, IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x=>x)
                .MustAsync((command, props, CancellationToken) => IsNamesAlreadyExist(props.EnName,props.ArName))
                .WithMessage(localizer["AlreadyExists"]);

            RuleFor(x => x.ArName)
                .NotEmpty()
                .WithMessage(localizer["Required"])
                .MaximumLength(50)
                 .WithMessage(localizer["MaxLength", 50]);
                 


            RuleFor(x => x.EnName)
               .NotEmpty()
               .WithMessage(localizer["Required"])
               .MaximumLength(50)
                .WithMessage(localizer["MaxLength", 50]);




            RuleFor(x => x.ArTitle)
               .NotEmpty()
               .WithMessage(localizer["Required"])
               .MaximumLength(50)
                .WithMessage(localizer["MaxLength", 50]);




            RuleFor(x => x.EnTitle)
               .NotEmpty()
               .WithMessage(localizer["Required"])
               .MaximumLength(50)
                .WithMessage(localizer["MaxLength", 50]);


            RuleFor(x => x.ArDescription)
                  .NotEmpty()
                  .WithMessage(localizer["Required"])
                  .MaximumLength(250)
                   .WithMessage(localizer["MaxLength", 250]);


            RuleFor(x => x.EnDescription)
                   .NotEmpty()
                   .WithMessage(localizer["Required"])
                   .MaximumLength(250)
                    .WithMessage(localizer["MaxLength", 250]);




            RuleFor(x => x.CategoryID)
                   .NotEmpty()
                   .WithMessage(localizer["Required"])
                   .MustAsync((command, CategoryID, CancellationToken) => IsValidCategory(CategoryID))
                   .WithMessage(localizer["InvalidCategory"]);

            this.appDb = appDb;
            this.localizer = localizer;
        }

        private async Task<bool> IsNamesAlreadyExist(string enName, string arName)
        {
            return await appDb.Products
                .AnyAsync(a => a.EnName == enName || a.ArName == arName);
        }

        private async Task<bool> IsValidCategory(int categoryID)
        {
            return await appDb
                   .productCategories.AnyAsync(a => a.Id == categoryID);
        }
    }
}
