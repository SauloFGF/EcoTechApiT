using EcoTech.Contexts;
using EcoTech.Implementations.Interfaces;
using EcoTech.Models;

namespace EcoTech.Repositories.Interfaces
{
    public interface IClientUserRepository : IBaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>
    {
        Task<ClientUser> GetAsync(string search, CancellationToken cancellationToken);
        Task<List<ClientUser>> GetAllClients(CancellationToken cancellationToken);
        Task<bool> AnyAsync(string? search, CancellationToken cancellationToken);
    }
}
