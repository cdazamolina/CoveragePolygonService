using CoveragePolygonService.Core.Entities;
using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Infraestructure.Contexts;

namespace CoveragePolygonService.Infraestructure.Repositories
{
    public class HistoryOfRouteRepository : IAsyncRepository<HistoryOfRoute>
    {

        private readonly CoveragePolygonContext _dbContext;

        public HistoryOfRouteRepository(CoveragePolygonContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<HistoryOfRoute> CreateAsync(HistoryOfRoute entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(HistoryOfRoute entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HistoryOfRoute>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HistoryOfRoute> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryOfRoute> UpdateAsync(HistoryOfRoute entity)
        {
            throw new NotImplementedException();
        }
    }
}
