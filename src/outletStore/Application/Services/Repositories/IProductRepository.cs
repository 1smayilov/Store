using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>, IRepository<Product, int>
{
}