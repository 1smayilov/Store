using NArchitecture.Core.Application.Responses;

namespace Application.Features.Categories.Commands.Delete;

public class DeletedCategoryResponse : IResponse
{
    public int Id { get; set; }
}