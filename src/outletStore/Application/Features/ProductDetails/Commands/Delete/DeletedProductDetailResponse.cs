using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductDetails.Commands.Delete;

public class DeletedProductDetailResponse : IResponse
{
    public int Id { get; set; }
}