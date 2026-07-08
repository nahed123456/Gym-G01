using GymManagmemnt.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gym_G01.Controllers
{
    public class MembersController : Controller
    {
        // MemberService
        private readonly IMemberService _memService;

        public MembersController(IMemberService memService)
        {
            _memService = memService;
        }

        #region Get Members
        // GET :: BaseUrl/Members/Index => List All Members
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            // Service => GetAllMembers
            var members = await _memService.GetAllAsync(ct);
            return View(members);
        }

        // GET :: BaseUrl/Members/Details/{id} => Get Specific Member

        // GET :: BaseUrl/Members/HealthRecordDetails/{id} => Get Data of Specific Member With Health

        #endregion



        #region Create

        // GET :: BaseUrl/Members/Create => Show Empty Form

        // POST :: BaseUrl/Members/Create/{member} => Submit Form

        #endregion

        #region Edit

        // GET :: BaseUrl/Members/Edit/{id} => Show Edit Form

        // POST BaseUrl/Members/Edit/{member} => Submit Edit Form

        #endregion

        #region Delete

        // GET BaseUrl/Members/Delete/{id} => Show Validation Page

        #endregion



    }
}
