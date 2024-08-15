using CollectEverything.Shops.Samples;
using Xunit;

namespace CollectEverything.Shops.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<ShopsMongoDbTestModule>
{

}
