using NArchitecture.Core.Application.Responses;

namespace Application.Features.Products.Commands.Delete;

public class DeletedProductResponse : IResponse
{
    public int Id { get; set; }
}