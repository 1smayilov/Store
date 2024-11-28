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

namespace Application.Features.ProductDetails.Commands.Update;

public class UpdateProductDetailCommand : IRequest<UpdatedProductDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
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

    public string[] Roles => [Admin, Write, ProductDetailsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductDetails"];

    public class UpdateProductDetailCommandHandler : IRequestHandler<UpdateProductDetailCommand, UpdatedProductDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly ProductDetailBusinessRules _productDetailBusinessRules;

        public UpdateProductDetailCommandHandler(IMapper mapper, IProductDetailRepository productDetailRepository,
                                         ProductDetailBusinessRules productDetailBusinessRules)
        {
            _mapper = mapper;
            _productDetailRepository = productDetailRepository;
            _productDetailBusinessRules = productDetailBusinessRules;
        }

        public async Task<UpdatedProductDetailResponse> Handle(UpdateProductDetailCommand request, CancellationToken cancellationToken)
        {
            ProductDetail? productDetail = await _productDetailRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDetailBusinessRules.ProductDetailShouldExistWhenSelected(productDetail);
            productDetail = _mapper.Map(request, productDetail);

            await _productDetailRepository.UpdateAsync(productDetail!);

            UpdatedProductDetailResponse response = _mapper.Map<UpdatedProductDetailResponse>(productDetail);
            return response;
        }
    }
}