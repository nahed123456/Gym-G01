using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym_G01.Controllers
{
    public class PlanController : Controller
    {



        private readonly IPlanRepository _planRepository;

        public PlanController(IPlanRepository planRepository)
        { 
             _planRepository= planRepository
        }


        public PlanController()
        {
            context = new GymDbContext();
        }



        // GET :: BaseUrl/Plan/Index
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await _planRepository.GetAllAsync(ct: ct);
            return View(plans);
        }


        // GET :: BaseUrl/Plan/Details/{id}
        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            var plan = await _planRepository.GetByIdAsync(id: ct);
            if (plan == null)
               
                return RedirectToAction(nameof(Index));

            return View(plan);


        }
    }
}