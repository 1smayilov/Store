using Application.Features.ProductDetails.Commands.Create;
using Application.Features.ProductDetails.Commands.Delete;
using Application.Features.ProductDetails.Commands.Update;
using Application.Features.ProductDetails.Queries.GetById;
using Application.Features.ProductDetails.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductDetailCommand createProductDetailCommand)
    {
        CreatedProductDetailResponse response = await Mediator.Send(createProductDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDetailCommand updateProductDetailCommand)
    {
        UpdatedProductDetailResponse response = await Mediator.Send(updateProductDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductDetailResponse response = await Mediator.Send(new DeleteProductDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductDetailResponse response = await Mediator.Send(new GetByIdProductDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductDetailQuery getListProductDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductDetailListItemDto> response = await Mediator.Send(getListProductDetailQuery);
        return Ok(response);
    }
}