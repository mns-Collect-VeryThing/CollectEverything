using System;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace CollectEverything.Product.Events.Articles
{
    [EventName("CollectEverything.Articles.ArticleCreated")]
    public class ArticleCreatedEto : EntityEto<Guid>
    {
        public Guid BoutiqueId { get; set; }
        public String Nom { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }
    }
}