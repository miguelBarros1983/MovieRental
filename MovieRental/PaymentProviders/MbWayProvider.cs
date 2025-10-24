namespace MovieRental.PaymentProviders
{
    public class MbWayProvider : IPaymentProvider
    {
        public Task<bool> Pay(double price)
        {
            //ignore this implementation
            return Task.FromResult<bool>(true);
        }

        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            Console.WriteLine($"Processing MbWay payment of {amount:C}");
            return Task.FromResult(true);
        }
    }
}
