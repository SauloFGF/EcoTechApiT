using EcoTech.Contexts;
using EcoTech.Models;

namespace EcoTech.Implementations.Interfaces
{
    public interface IBaseMongoRepository<TModel, TContext>
        where TModel : BaseModel
        where TContext : MongoDbContext
    {
        Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<List<TModel>> GetAsync(List<Guid> ids, CancellationToken cancellationToken);

        Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken);

        Task InsetAsync(TModel model, CancellationToken cancellationToken);

        Task InsertAsync(List<TModel> models, CancellationToken cancellationToken);

        Task UpdateAsync(TModel model, CancellationToken cancellationToken);

        Task UpdateAsync(List<TModel> models, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task DeleteAsync(List<Guid> ids, CancellationToken cancellationToken);

        Task DeleteAsync(List<TModel> list, CancellationToken cancellationToken);
    }
}
