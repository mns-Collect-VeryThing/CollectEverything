using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using CollectEverything.Product.Articles.DTOs.Input;
using CollectEverything.Product.Articles.DTOs.Output;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;

namespace CollectEverything.Product.Articles
{
    public class ArticlesAppService : ProductAppService, IArticlesAppService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ArticlesAppService(IArticleRepository articleRepository, IGuidGenerator guidGenerator)
        {
            _articleRepository = articleRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<List<ArticleDto>> GetListArticles()
        {
            var articles = await _articleRepository.GetListAsync();
            return articles.Select(a => ObjectMapper.Map<Article, ArticleDto>(a)).ToList();
        }

        public async Task<ArticleDto> GetArticle(Guid idArticle)
        {
            var article = await _articleRepository.GetAsync(idArticle);
            return ObjectMapper.Map<Article, ArticleDto>(article);
        }

        public async Task<ArticleDto> CreateArticle(CreateArticleDto createArticleDto)
        {
            var article = new Article(_guidGenerator.Create(), createArticleDto.Nom, createArticleDto.Prix, createArticleDto.Quantity);
            article = await _articleRepository.InsertAsync(article);
            return ObjectMapper.Map<Article, ArticleDto>(article);
        }

        public async Task DeleteArticle(Guid idArticle)
        {
            var article = await _articleRepository.GetAsync(idArticle);
            await _articleRepository.DeleteAsync(article);
        }

        public async Task<ArticleDto> UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var article = await _articleRepository.GetAsync(updateArticleDto.Id);
            article.Nom = updateArticleDto.Nom;
            article.Prix = updateArticleDto.Prix;
            article.Quantity = updateArticleDto.Quantity;
            article = await _articleRepository.UpdateAsync(article);

            return ObjectMapper.Map<Article, ArticleDto>(article);
        }
    }
}