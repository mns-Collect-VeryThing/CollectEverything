using System;
using Volo.Abp.Application.Dtos;

namespace CollectEverything.Product.Articles.DTOs.Output
{
    public class ArticleDto : FullAuditedEntityDto<Guid>
    {
        public Guid Boutique { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
    }
}