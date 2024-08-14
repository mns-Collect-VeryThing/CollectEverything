using System;
using System.Linq;
using System.Threading.Tasks;
using CollectEverything.Commandes.Paniers;
using CollectEverything.Commandes.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.Repositories
{
    public class PanierRepository : EfCoreRepository<CommandesDbContext, Panier, Guid>, IPanierRepository
    {
        public PanierRepository(IDbContextProvider<CommandesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async override Task<IQueryable<Panier>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(p => p.ArticleJoinEntities);
        }
    }
}