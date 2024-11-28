using FluentValidation;

namespace Application.Features.ProductDetails.Commands.Delete;

public class DeleteProductDetailCommandValidator : AbstractValidator<DeleteProductDetailCommand>
{
    public DeleteProductDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}