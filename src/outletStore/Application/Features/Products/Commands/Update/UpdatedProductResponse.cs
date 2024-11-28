using NArchitecture.Core.Application.Responses;

namespace Application.Features.Products.Commands.Update;

public class UpdatedProductResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string CoverImage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Adress { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int EmployeeId { get; set; }
}