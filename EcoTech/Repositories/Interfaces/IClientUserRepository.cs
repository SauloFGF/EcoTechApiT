using EcoTech.Contexts;
using EcoTech.Implementations.Interfaces;
using EcoTech.Models;

namespace EcoTech.Repositories.Interfaces
{
    public interface IClientUserRepository : IBaseMongoRepository<ClientUser, EcoTechAppMongoDbContext>
    {

    }
}
