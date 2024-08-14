using System;
using Volo.Abp.Application.Dtos;

namespace CollectEverything.Product.Articles.DTOs.Output
{
    public class ArticleDto : FullAuditedEntityDto<Guid>
    {
        public Guid BoutiqueId { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }
    }
}