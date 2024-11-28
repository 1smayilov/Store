using Application.Features.ProductDetails.Constants;
using Application.Features.ProductDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductDetails.Constants.ProductDetailsOperationClaims;

namespace Application.Features.ProductDetails.Queries.GetById;

public class GetByIdProductDetailQuery : IRequest<GetByIdProductDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdProductDetailQueryHandler : IRequestHandler<GetByIdProductDetailQuery, GetByIdProductDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly ProductDetailBusinessRules _productDetailBusinessRules;

        public GetByIdProductDetailQueryHandler(IMapper mapper, IProductDetailRepository productDetailRepository, ProductDetailBusinessRules productDetailBusinessRules)
        {
            _mapper = mapper;
            _productDetailRepository = productDetailRepository;
            _productDetailBusinessRules = productDetailBusinessRules;
        }

        public async Task<GetByIdProductDetailResponse> Handle(GetByIdProductDetailQuery request, CancellationToken cancellationToken)
        {
            ProductDetail? productDetail = await _productDetailRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDetailBusinessRules.ProductDetailShouldExistWhenSelected(productDetail);

            GetByIdProductDetailResponse response = _mapper.Map<GetByIdProductDetailResponse>(productDetail);
            return response;
        }
    }
}