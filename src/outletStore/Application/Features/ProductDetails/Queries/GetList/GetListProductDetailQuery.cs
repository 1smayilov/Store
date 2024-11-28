using Application.Features.ProductDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductDetails.Constants.ProductDetailsOperationClaims;

namespace Application.Features.ProductDetails.Queries.GetList;

public class GetListProductDetailQuery : IRequest<GetListResponse<GetListProductDetailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProductDetails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProductDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductDetailQueryHandler : IRequestHandler<GetListProductDetailQuery, GetListResponse<GetListProductDetailListItemDto>>
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IMapper _mapper;

        public GetListProductDetailQueryHandler(IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductDetailListItemDto>> Handle(GetListProductDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductDetail> productDetails = await _productDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductDetailListItemDto> response = _mapper.Map<GetListResponse<GetListProductDetailListItemDto>>(productDetails);
            return response;
        }
    }
}