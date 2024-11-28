using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductDetailRepository : EfRepositoryBase<ProductDetail, int, BaseDbContext>, IProductDetailRepository
{
    public ProductDetailRepository(BaseDbContext context) : base(context)
    {
    }
}