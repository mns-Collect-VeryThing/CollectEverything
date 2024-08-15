using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CollectEverything.Product.Articles
{
    public class Article : FullAuditedAggregateRoot<Guid>
    {
        public Guid ShopId { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }

        protected Article()
        {
            
        }

        public Article(Guid id, string nom, double prix, int quantity) : base(id)
        {
            Nom = nom;
            Prix = prix;
            Quantity = quantity;
        }
    }
}