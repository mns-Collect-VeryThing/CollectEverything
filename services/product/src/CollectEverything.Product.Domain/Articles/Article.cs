using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CollectEverything.Product.Articles
{
    public class Article : FullAuditedAggregateRoot<Guid>
    {
        public string Nom { get; set; }
        public double Prix { get; set; }

        protected Article()
        {
            
        }

        public Article(Guid id, string nom, double prix) : base(id)
        {
            Nom = nom;
            Prix = prix;
        }
    }
}