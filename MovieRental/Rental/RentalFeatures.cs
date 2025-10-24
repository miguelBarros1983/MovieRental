using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
        private readonly PaymentProviderFactory _paymentFactory;

        public RentalFeatures(MovieRentalDbContext movieRentalDb, PaymentProviderFactory paymentFactory)
		{
			_movieRentalDb = movieRentalDb;
            _paymentFactory = paymentFactory;
        }

		//TODO: make me async :(
		public async Task<Rental> SaveAsync(Rental rental)
		{
			_movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it
		public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
		{
            var customer = await _movieRentalDb.Customers.Where(x => x.Name == customerName).FirstOrDefaultAsync();
            if (customer == null)
				return new List<Rental>();

            return await _movieRentalDb.Rentals
                .Where(x => x.CustomerId == customer.Id)
                .ToListAsync();
        }

	}
}
