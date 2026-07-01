using Gym_G01.Models;

namespace Gym_G01.Repositories.InterFaces
{
    
        public interface IPlanRepository
        {
            //GETAllPlans
            Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken ct = default);
            //GETPlanById
            Task<Plan?> GetByIdAsync(int id, bool tracking = false, CancellationToken ct = default);
            //Add
            Task<int> AddAsync(Plan plan, CancellationToken ct = default);
            //Update
            Task<int> UpdateAsync(Plan plan, CancellationToken ct = default);
            //Delete
            Task<int> DeleteAsync(Plan plan, CancellationToken ct = default);
        }
} 


