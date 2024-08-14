using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CollectEverything.Commandes.EntityFrameworkCore;
using CollectEverything.Commandes.Paniers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.Repositories
{
    public class ArticleRepository : EfCoreRepository<CommandesDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<CommandesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}