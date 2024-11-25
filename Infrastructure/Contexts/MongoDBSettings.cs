namespace Infrastructure.Contexts
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";
        public string DatabaseName { get; set; } = "EcoTech";
    }
}
