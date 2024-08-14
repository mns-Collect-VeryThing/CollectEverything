using System;
using CollectEverything.Commandes.Paniers;
using CollectEverything.Commandes.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.Repositories
{
    public class PanierRepository : EfCoreRepository<CommandesDbContext, Panier, Guid>, IPanierRepository
    {
        public PanierRepository(IDbContextProvider<CommandesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}