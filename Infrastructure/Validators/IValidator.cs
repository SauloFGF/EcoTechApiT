namespace Infrastructure.Validators
{
    public interface IValidator<T>
    {
        Task<Validator<T>> ValidateAsync(CancellationToken cancellationToken);
    }
}
