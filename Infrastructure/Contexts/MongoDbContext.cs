using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EcoTech.Contexts
{
    public abstract class MongoDbContext
    {
        public MongoDbContext(IOptions<MongoDBSettings> options)
        {
            var client = new MongoClient(options.Value.MongoConnectionString);
            Database = client.GetDatabase(DatabaseName);
        }

        protected IMongoDatabase Database { get; }
        protected virtual string? DatabaseName { get; }

        public IMongoCollection<TModel> Set<TModel>()
        {
            return Database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public IMongoCollection<TModel> Set<TModel>(string name)
        {
            return Database.GetCollection<TModel>(name);
        }

        public void Execute()
            => LoadConfiguration(default).Wait();

        public async Task LoadConfiguration(CancellationToken cancellationToken)
        {
            var dllNames = new List<string> { "EcoTech.dll" };
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(w => dllNames.Contains(w.ManifestModule.Name)).ToList();

            var models = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(w => w.Namespace != null
                         && w.Namespace.StartsWith("API.Models")
                         && w.IsClass
                         && !w.IsAbstract
                         && w.IsPublic)
                .OrderBy(o => o.Name)
                .ToList();

            await CreateCollections(models, cancellationToken);
        }

        public async Task CreateCollections(List<Type> models, CancellationToken cancellationToken)
        {
            var currentCollections = GetCollectionNames();

            foreach (var model in models)
            {
                if (!currentCollections.Contains(model.Name))
                    await Database.CreateCollectionAsync(name: model.Name, cancellationToken: cancellationToken);
            }
        }

        public List<string> GetCollectionNames()
        {
            var collectionNames = new List<string>();
            var filter = new BsonDocument();

            var collections = Database.ListCollections(new ListCollectionsOptions { Filter = filter });

            foreach (var collection in collections.ToEnumerable())
                collectionNames.Add(collection["name"].AsString);

            return collectionNames;
        }
    }
}
