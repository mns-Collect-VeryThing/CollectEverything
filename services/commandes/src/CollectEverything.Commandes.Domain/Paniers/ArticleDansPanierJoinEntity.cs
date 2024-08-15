using System;
using Volo.Abp.Domain.Entities;

namespace CollectEverything.Commandes.Paniers
{
    public class ArticleDansPanierJoinEntity : Entity<Guid>
    {
        public Guid PanierId { get; set; }
        public Guid ArticleId { get; set; }
    }
}