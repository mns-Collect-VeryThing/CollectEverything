using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollectEverything.Product.Articles.DTOs.Output;
using Volo.Abp.Application.Services;

namespace CollectEverything.Product.Articles
{
    public interface IArticlesAppService : IApplicationService
    {
        public Task<List<ArticleDto>> GetListProducts();
        public Task<ArticleDto> GetArticle(Guid idArticle);
        public Task<ArticleDto> CreateProduct();
        public Task DeleteArticle(Guid idArticle);
    }
}