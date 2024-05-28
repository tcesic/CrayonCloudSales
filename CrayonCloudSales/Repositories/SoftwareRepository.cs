using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrayonCloudSales.Repositories
{
    public interface ISoftwareRepository
    {
        Task<Software> GetByIdAsync(int id);
        Task AddAsync(Software software);
        Task UpdateAsync(Software software);
        Task DeleteAsync(Software software);
        Task<IEnumerable<Software>> GetAccountSoftwaresAsync(int accountId);
    }

    public class SoftwareRepository : ISoftwareRepository
    {
        private readonly CrayonCloudSalesContext _context;
        public SoftwareRepository(CrayonCloudSalesContext context)
        {
            _context = context;
        }

        public async Task<Software> GetByIdAsync(int id)
        {
            var softwares = await _context.Softwares!.FindAsync(id);
            return softwares!;
        }

        public async Task AddAsync(Software software)
        {
            await _context.Softwares!.AddAsync(software);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Software software)
        {
            _context.Softwares!.Update(software);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Software software)
        {
            _context.Softwares!.Remove(software);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Software>> GetAccountSoftwaresAsync(int accountId)
        {
            return await _context.Softwares!.Where(s => s.AccountId == accountId).ToListAsync();
        }
    }
}
