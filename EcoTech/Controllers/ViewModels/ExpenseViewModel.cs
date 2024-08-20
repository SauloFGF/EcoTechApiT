using Infrastructure.Models;

namespace EcoTech.Controllers.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
