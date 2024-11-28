using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductDetails;

public interface IProductDetailService
{
    Task<ProductDetail?> GetAsync(
        Expression<Func<ProductDetail, bool>> predicate,
        Func<IQueryable<ProductDetail>, IIncludableQueryable<ProductDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductDetail>?> GetListAsync(
        Expression<Func<ProductDetail, bool>>? predicate = null,
        Func<IQueryable<ProductDetail>, IOrderedQueryable<ProductDetail>>? orderBy = null,
        Func<IQueryable<ProductDetail>, IIncludableQueryable<ProductDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductDetail> AddAsync(ProductDetail productDetail);
    Task<ProductDetail> UpdateAsync(ProductDetail productDetail);
    Task<ProductDetail> DeleteAsync(ProductDetail productDetail, bool permanent = false);
}
