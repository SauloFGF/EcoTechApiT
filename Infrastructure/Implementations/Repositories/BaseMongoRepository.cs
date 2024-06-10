using EcoTech.Contexts;
using EcoTech.Implementations.Interfaces;
using EcoTech.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace EcoTech.Implementations.Repositories
{
    public abstract class BaseMongoRepository<TModel, TContext>(TContext context,
        ILogger<BaseMongoRepository<TModel, TContext>> logger) : IBaseMongoRepository<TModel, TContext>
        where TModel : BaseModel
        where TContext : MongoDbContext
    {
        protected readonly TContext _context = context;
        protected readonly ILogger<BaseMongoRepository<TModel, TContext>> _logger = logger;

        protected IMongoCollection<TModel> Collection => _context.Set<TModel>();
        protected IMongoQueryable<TModel> Query => Collection.AsQueryable();

        #region Get Methods
        public async Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Query.Where(w => w.Id == id).SingleAsync(cancellationToken);
        }

        public async Task<List<TModel>> GetAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            return await Query.Where(w => ids.Contains(w.Id)).ToListAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Query.Where(w => w.Id == id).AnyAsync(cancellationToken);
        }
        #endregion

        #region Insert Methods
        public async Task InsetAsync(TModel model, CancellationToken cancellationToken)
        {
            await Collection.InsertOneAsync(model, cancellationToken: cancellationToken);
        }

        public async Task InsertAsync(List<TModel> models, CancellationToken cancellationToken)
        {
            if (models.Any())
                await Collection.InsertManyAsync(models, cancellationToken: cancellationToken);
        }
        #endregion

        #region Update Methods
        public async Task UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            model.Update();
            await Collection.ReplaceOneAsync(w => w.Id == model.Id, model, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(List<TModel> models, CancellationToken cancellationToken)
        {
            int registerCount = 0;
            var tasks = new List<Task>();

            foreach (var model in models)
            {
                tasks.Add(UpdateAsync(model, cancellationToken));
                registerCount++;
            }

            await Task.WhenAll(tasks);
        }
        #endregion

        #region Delete Methods
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await Collection.FindOneAndDeleteAsync(w => w.Id == id, null, cancellationToken);
        }

        public async Task DeleteAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            var result = await Collection.DeleteManyAsync(w => ids.Contains(w.Id), cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(List<TModel> list, CancellationToken cancellationToken)
        {
            var ids = list.Select(s => s.Id).ToList();

            var result = await Collection.DeleteManyAsync(w => ids.Contains(w.Id), cancellationToken: cancellationToken);
        }
        #endregion
    }
}
