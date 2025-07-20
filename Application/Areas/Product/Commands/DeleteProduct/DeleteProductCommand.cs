using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Areas.Product.Commands.UpdateProduct;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Areas.Product.Commands.DeleteProduct
{
    public  record DeleteProductCommand(int ID):IRequest;
    public class DeleteProductCommandHandler(
      IAppDbContext appDb,
      IStorageService storage,
      IStringLocalizer<Resources.Resources> localizer)
      : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var Product = appDb.Products
                                 .Where(a => a.Id == request.ID)
                                 .FirstOrDefault();



            if (Product is null)
                throw new ItemNotFoundException(localizer["NotFound"]);






            storage.RemoveFile(Product.ImageName);
          
            appDb.Products.Remove(Product);
            await appDb.SaveChangesAsync();
        }
    }
}
