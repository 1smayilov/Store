using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductDetailRepository : IAsyncRepository<ProductDetail, int>, IRepository<ProductDetail, int>
{
}