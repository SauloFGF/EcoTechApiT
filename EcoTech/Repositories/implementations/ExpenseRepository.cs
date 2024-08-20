using EcoTech.Contexts;
using EcoTech.Implementations.Repositories;
using EcoTech.Models;

namespace EcoTech.Repositories.implementations
{
    public class ExpenseRepository : BaseMongoRepository<ExpenseModel, EcoTechAppMongoDbContext>
    {
        public ExpenseRepository(EcoTechAppMongoDbContext context,
            ILogger<BaseMongoRepository<ExpenseModel, EcoTechAppMongoDbContext>> logger) : base(context, logger)
        {
        }
    }
}
