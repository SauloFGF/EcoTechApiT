using MongoDB.Bson.Serialization.Attributes;

namespace EcoTech.Models
{
    public class BaseModel
    {

        [BsonId]
        public Guid Id { get; set; }
        public DateTime Inserted { get; private set; }
        public DateTime Updated { get; private set; }

        protected BaseModel()
        {
            Id = Guid.NewGuid();
            Inserted = DateTime.Now;
            Updated = Inserted;
        }

        public void Update(DateTime? updated = null)
        {
            Updated = updated ?? DateTime.Now;
        }
    }
}
