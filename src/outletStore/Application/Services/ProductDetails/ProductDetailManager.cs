using Application.Features.ProductDetails.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductDetails;

public class ProductDetailManager : IProductDetailService
{
    private readonly IProductDetailRepository _productDetailRepository;
    private readonly ProductDetailBusinessRules _productDetailBusinessRules;

    public ProductDetailManager(IProductDetailRepository productDetailRepository, ProductDetailBusinessRules productDetailBusinessRules)
    {
        _productDetailRepository = productDetailRepository;
        _productDetailBusinessRules = productDetailBusinessRules;
    }

    public async Task<ProductDetail?> GetAsync(
        Expression<Func<ProductDetail, bool>> predicate,
        Func<IQueryable<ProductDetail>, IIncludableQueryable<ProductDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductDetail? productDetail = await _productDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productDetail;
    }

    public async Task<IPaginate<ProductDetail>?> GetListAsync(
        Expression<Func<ProductDetail, bool>>? predicate = null,
        Func<IQueryable<ProductDetail>, IOrderedQueryable<ProductDetail>>? orderBy = null,
        Func<IQueryable<ProductDetail>, IIncludableQueryable<ProductDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductDetail> productDetailList = await _productDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productDetailList;
    }

    public async Task<ProductDetail> AddAsync(ProductDetail productDetail)
    {
        ProductDetail addedProductDetail = await _productDetailRepository.AddAsync(productDetail);

        return addedProductDetail;
    }

    public async Task<ProductDetail> UpdateAsync(ProductDetail productDetail)
    {
        ProductDetail updatedProductDetail = await _productDetailRepository.UpdateAsync(productDetail);

        return updatedProductDetail;
    }

    public async Task<ProductDetail> DeleteAsync(ProductDetail productDetail, bool permanent = false)
    {
        ProductDetail deletedProductDetail = await _productDetailRepository.DeleteAsync(productDetail);

        return deletedProductDetail;
    }
}
