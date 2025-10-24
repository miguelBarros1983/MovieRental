using MovieRental.Customer;
using MovieRental.Movie;
using MovieRental.PaymentProviders;
using MovieRental.Rental;

namespace MovieRental.Configurations
{
    public static class DependenciesConfig
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureFeatures(services, configuration);
            ConfigureProviders(services);
            ConfigureFactories(services, configuration);
            return services;
        }

        private static void ConfigureFactories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PaymentProviderFactory>();
        }

        private static void ConfigureProviders(IServiceCollection services)
        {
            services.AddScoped<PayPalProvider>();
            services.AddScoped<MbWayProvider>();
        }

        private static void ConfigureFeatures(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieFeatures, MovieFeatures>();
            services.AddScoped<ICustomerFeatures, CustomerFeatures>();
            services.AddScoped<IRentalFeatures, RentalFeatures>();
        }
    }
}
