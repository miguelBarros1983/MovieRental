namespace MovieRental.PaymentProviders
{
    public class PayPalProvider : IPaymentProvider
    {
        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
            return Task.FromResult(true);
        }
    }
}
