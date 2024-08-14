using System.Threading.Tasks;
using CollectEverything.Commandes.Paniers;
using CollectEverything.Product.Events.Articles;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CollectEverything.Commandes.Articles
{
    public class ArticleCreatedEventHandler : IDistributedEventHandler<ArticleCreatedEto>, ITransientDependency
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleCreatedEventHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task HandleEventAsync(ArticleCreatedEto eventData)
        {
            var article = new Article(eventData.Id, eventData.Nom, eventData.Prix, eventData.Quantity);
            await _articleRepository.InsertAsync(article);
        }
    }
}