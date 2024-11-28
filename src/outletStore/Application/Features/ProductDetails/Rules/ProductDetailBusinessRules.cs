using Application.Features.ProductDetails.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ProductDetails.Rules;

public class ProductDetailBusinessRules : BaseBusinessRules
{
    private readonly IProductDetailRepository _productDetailRepository;
    private readonly ILocalizationService _localizationService;

    public ProductDetailBusinessRules(IProductDetailRepository productDetailRepository, ILocalizationService localizationService)
    {
        _productDetailRepository = productDetailRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductDetailsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductDetailShouldExistWhenSelected(ProductDetail? productDetail)
    {
        if (productDetail == null)
            await throwBusinessException(ProductDetailsBusinessMessages.ProductDetailNotExists);
    }

    public async Task ProductDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductDetail? productDetail = await _productDetailRepository.GetAsync(
            predicate: pd => pd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductDetailShouldExistWhenSelected(productDetail);
    }
}