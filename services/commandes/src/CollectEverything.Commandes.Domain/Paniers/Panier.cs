using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace CollectEverything.Commandes.Paniers
{
    public class Panier : FullAuditedAggregateRoot<Guid>
    {
        public Guid ShopId { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}