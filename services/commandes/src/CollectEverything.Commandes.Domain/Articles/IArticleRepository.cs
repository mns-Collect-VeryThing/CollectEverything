using System;
using Volo.Abp.Domain.Repositories;

namespace CollectEverything.Commandes.Paniers
{
    public interface IArticleRepository : IRepository<Article, Guid>;
}