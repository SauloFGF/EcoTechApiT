namespace EcoTech.Models
{
    public class ExpenseModel : BaseModel
    {
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public int Value { get; private set; }

        public ExpenseModel(string categoryName, string description, int value)
        {
            CategoryName = categoryName;
            Description = description;
            Value = value;
        }
    }
}
