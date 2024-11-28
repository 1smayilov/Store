using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ProductDetails.Queries.GetList;

public class GetListProductDetailListItemDto : IDto
{
    public int Id { get; set; }
    public string ProductSize { get; set; }
    public string BedRoomCount { get; set; }
    public string BathCount { get; set; }
    public string RoomCount { get; set; }
    public string GarageSize { get; set; }
    public string BuildYear { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public string VideoUrl { get; set; }
    public int ProductId { get; set; }
}