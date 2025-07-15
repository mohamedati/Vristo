using API.Attributes;
using API.Extentions;
using Application.Areas.Product.Commands.CreateProduct;
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
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            return await sender.Send(command).ToGenericResponse();
        }
    }
}
