using EcoTech.Contexts;
using EcoTech.Models;

namespace EcoTech.Implementations.Interfaces
{
    public interface IBaseMongoRepository<TModel, TContext>
        where TModel : BaseModel
        where TContext : MongoDbContext
    {

    }
}
