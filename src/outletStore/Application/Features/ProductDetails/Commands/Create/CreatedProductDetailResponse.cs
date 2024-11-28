using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductDetails.Commands.Create;

public class CreatedProductDetailResponse : IResponse
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