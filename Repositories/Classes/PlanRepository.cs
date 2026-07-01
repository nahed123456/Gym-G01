using Gym_G01.Models;
using Gym_G01.Repositories.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace Gym_G01.Repositories.Classes
{
    public class PlanRepository
    {

        public class PlanRepository : IPlanRepository
        {
            //{1}DataBase Connection
            private readonly GymDbContext dbContext;
            public PlanRepository(GymDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
            {
                dbContext.Plans.Add(plan);
                return await dbContext.SaveChangesAsync(ct);
            }

            public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
            {
                dbContext.Plans.Remove(plan);
                return await dbContext.SaveChangesAsync(ct);

            }

            public async Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken ct = default)
            {
                //if (tracking) //true

                //    return await dbContext.Plans.ToListAsync(ct);
                //else
                //    return await dbContext.Plans.AsNoTracking().ToListAsync(ct
                IQueryable<Plan> query = tracking ? dbContext.Plans : dbContext.Plans.AsNoTracking();
                return await query.ToListAsync(ct);

            }

            public async Task<Plan?> GetByIdAsync(int id, bool tracking = false, CancellationToken ct = default)
            {
                return await dbContext.Plans.FindAsync(id, ct);
            }

            public Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
            {
                dbContext.Update(plan);
                return dbContext.SaveChangesAsync(ct);
            }
        }
    }

}
