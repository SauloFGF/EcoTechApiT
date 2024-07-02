using EcoTech.Contexts;
using EcoTech.Implementations.Repositories;
using EcoTech.Models;
using EcoTech.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoTech.Repositories.implementations
{
    public class ClientUserRepository(EcoTechAppMongoDbContext context, ILogger<BaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>> logger)
        : BaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>(context, logger), IClientUserRepository
    {
        public async Task<ClientUser> GetAsync(string search, CancellationToken cancellationToken)
        {
            return await Query
            .Where(w => string.Equals(w.Contact.Email, search, StringComparison.OrdinalIgnoreCase)
                     || w.Cpf == search).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ClientUser>> GetAllClients(CancellationToken cancellationToken)
        {
            return await Query.ToListAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(string? search, CancellationToken cancellationToken)
        {
            return await Query
                .AnyAsync(w => string.Equals(w.Contact.Email, search, StringComparison.OrdinalIgnoreCase)
                || w.Cpf == search, cancellationToken);
        }
    }
}
