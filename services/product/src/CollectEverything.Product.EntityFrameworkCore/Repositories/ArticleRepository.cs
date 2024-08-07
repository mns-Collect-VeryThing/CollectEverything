using System;
using CollectEverything.Product.Articles;
using CollectEverything.Product.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Product.Repositories
{
    public class ArticleRepository : EfCoreRepository<ProductDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<ProductDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}