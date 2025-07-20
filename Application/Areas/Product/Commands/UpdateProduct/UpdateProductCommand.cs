using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Areas.Product.Commands.CreateProduct;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Product.Commands.UpdateProduct
{
    public  class UpdateProductCommand:IRequest
    {
        public int ID {  get; set; }
        public string ArName { get; set; } = null!;

        public string EnName { get; set; } = null!;

        public string ArTitle { get; set; } = null!;

        public string EnTitle { get; set; } = null!;

        public string ArDescription { get; set; } = null!;


        public string EnDescription { get; set; } = null!;


        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public IFormFile? Image { get; set; }

        public int CategoryID { get; set; }


    }


    public class UpdateProductCommandHandler(
        IAppDbContext appDb,
        IStorageService storage,
        IStringLocalizer<Resources.Resources> localizer)
        : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var Product= appDb.Products
                                 .Where(a => a.Id == request.ID)
                                 .FirstOrDefault();



            if (Product is null)
                throw new ItemNotFoundException(localizer["NotFound"]);


            var newImagName = "";
            if (request.Image != null)
            {
                storage.RemoveFile(Product.ImageName);
                newImagName = storage.SaveFile(request.Image, "Products");
            }
            else
            {
                newImagName = Product.ImageName; 
            }
               

           
                                 

            var data = request.Adapt<Domain.Entities.Product>();

            data.ImageName = newImagName;
             appDb.Products.Update(data);
            await appDb.SaveChangesAsync();
        }
    }
}
