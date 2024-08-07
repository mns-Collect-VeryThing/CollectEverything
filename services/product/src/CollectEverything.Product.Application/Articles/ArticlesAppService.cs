using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CollectEverything.Product.Articles.DTOs.Output;

namespace CollectEverything.Product.Articles
{
    public class ArticlesAppService : ProductAppService, IArticlesAppService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesAppService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<ArticleDto>> GetListProducts()
        {
            var articles = await _articleRepository.GetListAsync();
            return ObjectMapper.Map<List<Article>, List<ArticleDto>>(articles);
        }

        public Task<ArticleDto> GetArticle(Guid idArticle)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> CreateProduct()
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticle(Guid idArticle)
        {
            throw new NotImplementedException();
        }
    }
}