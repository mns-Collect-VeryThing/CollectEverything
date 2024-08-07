using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollectEverything.Product.Articles.DTOs.Input;
using CollectEverything.Product.Articles.DTOs.Output;
using Volo.Abp.Application.Services;

namespace CollectEverything.Product.Articles
{
    public interface IArticlesAppService : IApplicationService
    {
        public Task<List<ArticleDto>> GetListArticles();
        public Task<ArticleDto> GetArticle(Guid idArticle);
        public Task<ArticleDto> CreateArticle(CreateArticleDto createArticleDto);
        public Task DeleteArticle(Guid idArticle);
    }
}