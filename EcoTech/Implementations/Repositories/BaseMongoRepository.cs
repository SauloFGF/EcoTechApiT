using EcoTech.Contexts;
using EcoTech.Implementations.Interfaces;
using EcoTech.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace EcoTech.Implementations.Repositories
{
    public abstract class BaseMongoRepository<TModel, TContext>(TContext context,
        ILogger<BaseMongoRepository<TModel,
        TContext>> logger) : IBaseMongoRepository<TModel, TContext>
        where TContext : BaseModel
        where TModel : MongoDbContext
    {
        protected readonly TContext _context = context;
        protected readonly ILogger<BaseMongoRepository<TModel, TContext>> _logger = logger;

        protected IMongoCollection<TModel> Collection => _context.Set<TModel>();
        protected IMongoQueryable<TModel> Query => Collection.AsQueryable();

    }
}
