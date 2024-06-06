using Microsoft.Extensions.Options;

namespace EcoTech.Contexts
{
    public class EcoTechAppMongoDbContext : MongoDbContext
    {
        public EcoTechAppMongoDbContext(IOptions<MongoDBSettings> options) : base(options)
        {

        }

        protected override string? DatabaseName => "EcotechApp";
    }
}
