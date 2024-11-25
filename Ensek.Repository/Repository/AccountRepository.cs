using Ensek.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Repository.Repository
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAccountsWithLatestReading(List<int> accountIds);
    }

    public class AccountRepository : IAccountRepository
    {
        public readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> GetAccountsWithLatestReading(List<int> accountIds)
        {
            return await _dbContext.Accounts
                .Where(x => accountIds.Contains(x.AccountId))
                //.Include(m => m.MeterReadings.OrderByDescending(d =>d.MeterReadingDateTime).FirstOrDefault())
                .Include(x=>x.MeterReadings)
                .ToListAsync();
        }
    }
}
