using CollectEverything.Shops.MongoDB;
using CollectEverything.Shops.Samples;
using Xunit;

namespace CollectEverything.Shops.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<ShopsMongoDbTestModule>
{

}
