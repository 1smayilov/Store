using Application.Features.ProductDetails.Constants;
using Application.Features.ProductDetails.Constants;
using Application.Features.ProductDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductDetails.Constants.ProductDetailsOperationClaims;

namespace Application.Features.ProductDetails.Commands.Delete;

public class DeleteProductDetailCommand : IRequest<DeletedProductDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ProductDetailsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductDetails"];

    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, DeletedProductDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly ProductDetailBusinessRules _productDetailBusinessRules;

        public DeleteProductDetailCommandHandler(IMapper mapper, IProductDetailRepository productDetailRepository,
                                         ProductDetailBusinessRules productDetailBusinessRules)
        {
            _mapper = mapper;
            _productDetailRepository = productDetailRepository;
            _productDetailBusinessRules = productDetailBusinessRules;
        }

        public async Task<DeletedProductDetailResponse> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            ProductDetail? productDetail = await _productDetailRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDetailBusinessRules.ProductDetailShouldExistWhenSelected(productDetail);

            await _productDetailRepository.DeleteAsync(productDetail!);

            DeletedProductDetailResponse response = _mapper.Map<DeletedProductDetailResponse>(productDetail);
            return response;
        }
    }
}