using EcoTech.Controllers.ViewModels;
using EcoTech.Models;
using EcoTech.Repositories.Interfaces;
using Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTech.Controllers
{
    [Route("app/expense"), AllowAnonymous]
    public class ExpenseController(IExpenseRepository repository, ILogger<BaseController> logger) : BaseController(logger)
    {
        [HttpPost, Route("create")]
        public async Task CreateExpenseAsync(ExpenseViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = new ExpenseModel(viewModel.CategoryName, viewModel.Description, viewModel.Value);

            await repository.InsetAsync(model, cancellationToken);
        }
    }
}
