
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public CustomerFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        public async Task<Customer> SaveAsync(Customer customer)
        {
            await _movieRentalDb.Customers.AddAsync(customer);
            await _movieRentalDb.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _movieRentalDb.Customers.ToListAsync();
        }
    }
}
