using Ensek.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Repository.Repository
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAccountsWithLatestReading(List<int> accountIds, CancellationToken cancellationToken);
    }

    public class AccountRepository : IAccountRepository
    {
        public readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> GetAccountsWithLatestReading(List<int> accountIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .Where(x => accountIds.Contains(x.AccountId))
                .Include(c=> c.MeterReadings.OrderByDescending(d =>d.MeterReadingDateTime).Take(1))
                .ToListAsync();
        }
    }
}
