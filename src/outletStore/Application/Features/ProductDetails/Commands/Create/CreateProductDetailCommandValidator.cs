using FluentValidation;

namespace Application.Features.ProductDetails.Commands.Create;

public class CreateProductDetailCommandValidator : AbstractValidator<CreateProductDetailCommand>
{
    public CreateProductDetailCommandValidator()
    {
        RuleFor(c => c.ProductSize).NotEmpty();
        RuleFor(c => c.BedRoomCount).NotEmpty();
        RuleFor(c => c.BathCount).NotEmpty();
        RuleFor(c => c.RoomCount).NotEmpty();
        RuleFor(c => c.GarageSize).NotEmpty();
        RuleFor(c => c.BuildYear).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}