using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace EcoTech.Models
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser
    {
    }
}
