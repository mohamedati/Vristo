using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Areas.Product.Commands.CreateProduct
{
    public  class CreateProductCommand:IRequest
    {
        public string ArName { get; set; } = null!;

        public string EnName { get; set; } = null!;

        public string ArTitle { get; set; } = null!;

        public string EnTitle { get; set; } = null!;

        public string ArDescription { get; set; } = null!;


        public string EnDescription { get; set; } = null!;


        public decimal Price { get; set; }

        public int Quantity { get; set; }

         public IFormFile Image {  get; set; }

        public int CategoryID { get; set; }

  
    }


    public class CreateProductCommandHandler(
        IAppDbContext appDb,
        IStorageService storage)
        : IRequestHandler<CreateProductCommand>
    {
        public async  Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var data= request.Adapt<Domain.Entities.Product>();

           var fileName= storage.SaveFile(request.Image, "Products");
            data.ImageName = fileName;
           await appDb.Products.AddAsync(data);
           await  appDb.SaveChangesAsync();
        }
    }
}
