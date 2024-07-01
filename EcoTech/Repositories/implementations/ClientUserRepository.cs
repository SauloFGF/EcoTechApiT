using EcoTech.Contexts;
using EcoTech.Implementations.Repositories;
using EcoTech.Models;
using EcoTech.Repositories.Interfaces;

namespace EcoTech.Repositories.implementations
{
    public class ClientUserRepository(EcoTechAppMongoDbContext context, ILogger<BaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>> logger)
        : BaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>(context, logger), IClientUserRepository
    {
        public async Task<ClientUser> GetAsync(string search, CancellationToken cancellationToken)
        {
            return await Query
                .Where(w => string.Equals(w.Contact.Email, search, StringComparison.O))
        }
    }
}
