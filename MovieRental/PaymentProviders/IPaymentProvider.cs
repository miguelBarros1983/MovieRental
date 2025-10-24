namespace MovieRental.PaymentProviders
{
    public interface IPaymentProvider
    {
        Task<bool> ProcessPaymentAsync(decimal amount);
    }
}
