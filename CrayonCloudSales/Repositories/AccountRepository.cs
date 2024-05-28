using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrayonCloudSales.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsByCustomerAsync(int customerId);
    }

    public class AccountRepository : IAccountRepository
    {

        private readonly CrayonCloudSalesContext _context;

        public AccountRepository(CrayonCloudSalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccountsByCustomerAsync(int customerId)
        {
            return await _context.Accounts!.Where(a => a.CustomerId == customerId)
                .Select(a => new Account
                {
                    Id = a.Id,
                    Name = a.Name,
                    Customer = a.Customer,
                    CustomerId = customerId
                })
                .ToListAsync();
        }

      
    }
}
