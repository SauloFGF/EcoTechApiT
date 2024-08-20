using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;

namespace Infrastructure.Contexts
{
    public static class MongoDbConventions
    {
        public static IServiceCollection useMongoDbConventions(this IServiceCollection serviceCollection, bool ignoreIfDefault = false)
        {
            if (!ignoreIfDefault)
                return serviceCollection;

            ConventionRegistry.Register("IgnoreIfNullConvetion", conventions: new ConventionPack
            {
                new IgnoreIfNullConvention(true)
            }, t => true);

            return serviceCollection;
        }
    }
}
