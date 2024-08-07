using System;
using Volo.Abp.Domain.Repositories;

namespace CollectEverything.Product.Articles
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {
        
    }
}