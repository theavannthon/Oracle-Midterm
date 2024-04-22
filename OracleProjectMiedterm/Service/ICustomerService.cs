using OracleProjectMiedterm.Models;

namespace OracleProjectMiedterm.Service
{
	public interface ICustomerService
	{
		Task<bool> Create(Customer customer);
		Task<bool> Update(Customer customer);
		Task<bool> Delete(Customer customer);
		Task<Customer> Get(int CustomerId);
		Task<List<Customer>> GetAll(string? filter = null);	
	}
}
