using System;
using Volo.Abp.Application.Dtos;

namespace CollectEverything.Product.Articles.DTOs.Output
{
    public class ArticleDto : FullAuditedEntityDto<Guid>
    {
        public Guid Boutique { get; set; } = Guid.Empty; 
        public string Name { get; set; }
        public double Price { get; set; }
    }
}