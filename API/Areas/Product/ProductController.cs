using API.Attributes;
using API.Extentions;
using Application.Areas.Product.Commands.CreateProduct;
using Application.Areas.Product.Commands.DeleteProduct;
using Application.Areas.Product.Commands.UpdateProduct;
using Application.Areas.Product.Queries.PaginateProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [HasPermission]

    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }


        [HttpGet]
        [Cache(600)]
        public async Task<IActionResult> Paginate([FromQuery] PaginateProducts command)
        {
            return await sender.Send(command).ToGenericResponse();
        }
    }
}
