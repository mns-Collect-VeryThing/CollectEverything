using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CollectEverything.Commandes.Paniers
{
    public class Article : FullAuditedAggregateRoot<Guid>
    {
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }
        public bool RemovedFromSale { get; set; }

        public Article(Guid id, string nom, double prix, int quantity) : base(id)
        {
            Nom = nom;
            Prix = prix;
            Quantity = quantity;
            RemovedFromSale = false;
        }
    }
}