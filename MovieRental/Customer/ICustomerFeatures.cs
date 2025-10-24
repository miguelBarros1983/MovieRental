namespace MovieRental.Customer
{
    public interface ICustomerFeatures
    {
        Task<Customer> SaveAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
    }
}
