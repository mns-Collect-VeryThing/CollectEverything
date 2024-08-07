using System;
using AutoMapper;
using CollectEverything.Product.Articles;
using CollectEverything.Product.Articles.DTOs.Output;

namespace CollectEverything.Product;

public class ProductApplicationAutoMapperProfile : Profile
{
    public ProductApplicationAutoMapperProfile()
    {
        CreateMap<Article, ArticleDto>()
            .ForMember(dto => dto.Boutique, m => m.MapFrom(o => Guid.Empty));
    }
}
