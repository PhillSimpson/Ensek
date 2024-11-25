using Ensek.Repository.Entity;

namespace Ensek.Repository.Repository
{
    public interface IMeterReadingRepository
    {
        public Task<bool> Insert(MeterReading reading, CancellationToken cancellationToken);
    }

    public class MeterReadingRepository : IMeterReadingRepository
    {
        public readonly AppDbContext _dbContext;

        public MeterReadingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(MeterReading reading, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(reading, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return reading.Id != 0;
        }
    }
}
