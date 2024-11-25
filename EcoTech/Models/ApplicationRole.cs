using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace EcoTech.Models;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
}
