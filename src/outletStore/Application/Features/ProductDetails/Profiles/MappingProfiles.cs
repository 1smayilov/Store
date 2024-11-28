using Application.Features.ProductDetails.Commands.Create;
using Application.Features.ProductDetails.Commands.Delete;
using Application.Features.ProductDetails.Commands.Update;
using Application.Features.ProductDetails.Queries.GetById;
using Application.Features.ProductDetails.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductDetail, CreateProductDetailCommand>().ReverseMap();
        CreateMap<ProductDetail, CreatedProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailCommand>().ReverseMap();
        CreateMap<ProductDetail, UpdatedProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, DeleteProductDetailCommand>().ReverseMap();
        CreateMap<ProductDetail, DeletedProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, GetListProductDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductDetail>, GetListResponse<GetListProductDetailListItemDto>>().ReverseMap();
    }
}