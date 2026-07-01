using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym_G01.Controllers
{
    public class PlanController : Controller
    {
        //Database Connection

        private readonly GymDbContext context;

        public PlanController()
        {
            context = new GymDbContext();
        }



        // GET :: BaseUrl/Plan/Index
        public async Task<IActionResult> Index()
        {
            var plans = await context.Plans.ToListAsync(); // pass by name
            return View(plans);
        }


        // GET :: BaseUrl/Plan/Details/{id}
        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            var plan = await content.Plans.FindAsync(id);
            if (plan == null)
               
                return RedirectToAction(nameof(Index));

            return View(plan);


        }
    }
}