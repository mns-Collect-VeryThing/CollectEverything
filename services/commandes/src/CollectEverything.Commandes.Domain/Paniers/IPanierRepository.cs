using System;
using Volo.Abp.Domain.Repositories;

namespace CollectEverything.Commandes.Paniers
{
    public interface IPanierRepository : IRepository<Panier, Guid>;
}