using NArchitecture.Core.Application.Responses;

namespace Application.Features.Categories.Commands.Create;

public class CreatedCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}