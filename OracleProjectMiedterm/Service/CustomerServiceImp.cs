using Microsoft.EntityFrameworkCore;
using OracleProjectMiedterm.Data;
using OracleProjectMiedterm.Models;

namespace OracleProjectMiedterm.Service
{
	public class CustomerServiceImp : ICustomerService
	{
		private readonly EntityContext _con;
		
		public CustomerServiceImp(EntityContext con)
		{
			_con = con;
			
		}
		public async Task<bool> Create(Customer customer)
		{
			_con.Customsers.Add(customer);
			return await _con.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(Customer customer)
		{
			_con.Customsers.Remove(customer);
			return await _con.SaveChangesAsync() > 0;
		}

		public async Task<Customer> Get(int CustomerId)
		{
			var customer = _con.Customsers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
			return await customer;
		}

		public async Task<List<Customer>> GetAll(string? filter)
		{
			IQueryable<Customer> customers = _con.Customsers;
			if (!string.IsNullOrWhiteSpace(filter))
			{
				customers = customers.Where(x => EF.Functions.Like(x.CustomerName!, $"%{filter}%") ||
												 EF.Functions.Like(x.CustomerCode!, $"%{filter}%") |
												 EF.Functions.Like(x.Phone!, $"%{filter}%")
                );
			}
			return await customers.AsNoTracking().ToListAsync();
			
		}

		public async Task<bool> Update(Customer customer)
		{
			_con.Customsers.Update(customer);
			return await _con.SaveChangesAsync () >0;
		}
	}
}
