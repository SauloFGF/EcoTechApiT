using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Validators
{
    public class Validator<T>(T instance) : IValidator<T>
    {
        protected readonly T _instace = instance;
        protected delegate Result FuncValAsync<out Result>(CancellationToken cancellationToken);
        private readonly List<string> _errors = [];

        public List<string> GetErrors() => _errors;
        public object ToResponse() => new { Erros = _errors };
        public bool IsValid() => _errors.Count == 0;

        public async Task<Validator<T>> ValidateAsync(CancellationToken cancellationToken)
        {
            if (_instace is not null)
            {
                var context = new ValidationContext(_instace, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(_instace, context, validationResults, validateAllProperties: true))
                    _errors.AddRange(validationResults.Select(vr => $"{vr.ErrorMessage}"));
            }

            await AddValidations(cancellationToken);

            return this;
        }

        public void AddCustomError(string message) => _errors.Add(message);

        protected void AddError(Func<ValidationResult?> funcValidation)
        {
            ValidationResult? vr = funcValidation.Invoke();

            if (vr is not null)
                _errors.Add($"{vr.ErrorMessage}");
        }

        protected async Task AddErrorAsync(FuncValAsync<Task<ValidationResult?>> currentValidation, CancellationToken cancellationToken)
        {
            ValidationResult? vr = await currentValidation(cancellationToken);

            if (vr is not null)
                _errors.Add($"{vr.ErrorMessage}");
        }

        public async virtual Task AddValidations(CancellationToken cancellationToken) { await Task.CompletedTask; }
    }
}
