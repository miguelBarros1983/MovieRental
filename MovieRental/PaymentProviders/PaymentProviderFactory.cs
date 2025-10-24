namespace MovieRental.PaymentProviders
{
    public class PaymentProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentProvider GetProvider(string paymentMethod)
        {
            try
            {
                if (paymentMethod == "PayPal")
                    return _serviceProvider.GetRequiredService<PayPalProvider>();
                else if (paymentMethod == "MbWay")
                    return _serviceProvider.GetRequiredService<MbWayProvider>();
                else
                    throw new NotSupportedException($"Payment method '{paymentMethod}' not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to resolve payment provider for '{paymentMethod}': {ex.Message}", ex);
            }
        }
    }
}
