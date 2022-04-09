using CoveragePolygonService.Core.Entities;
using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoveragePolygonService.Infraestructure.Repositories
{
    public class RouteCoverageRepository : IAsyncRepository<RouteCoverage>
    {
        private readonly CoveragePolygonContext _dbContext;

        public RouteCoverageRepository(CoveragePolygonContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<RouteCoverage>> GetAllAsync() =>
            await _dbContext.RouteCoverages.Include(x => x.Positions).ToListAsync();

        public async Task<RouteCoverage> GetByIdAsync(long id) =>
            await _dbContext.RouteCoverages.Include(x => x.Positions).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<RouteCoverage> CreateAsync(RouteCoverage entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<RouteCoverage> UpdateAsync(RouteCoverage entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(RouteCoverage entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
