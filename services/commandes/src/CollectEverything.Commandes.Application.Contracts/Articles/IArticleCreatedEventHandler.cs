using CollectEverything.Product.Events.Articles;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CollectEverything.Commandes.Articles
{
    public interface IArticleCreatedEventHandler : IDistributedEventHandler<ArticleCreatedEto>, ITransientDependency;
}