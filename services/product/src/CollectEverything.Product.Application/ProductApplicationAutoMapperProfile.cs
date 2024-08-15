using System;
using AutoMapper;
using CollectEverything.Product.Articles;
using CollectEverything.Product.Articles.DTOs.Output;
using CollectEverything.Product.Events.Articles;

namespace CollectEverything.Product;

public class ProductApplicationAutoMapperProfile : Profile
{
    public ProductApplicationAutoMapperProfile()
    {
        CreateMap<Article, ArticleDto>()
            .ForMember(dto => dto.BoutiqueId, m => m.MapFrom(o => Guid.Empty));
        CreateMap<Article,ArticleCreatedEto>()
            .ForMember(dto => dto.BoutiqueId, m => m.MapFrom(o => Guid.Empty));
    }
}
