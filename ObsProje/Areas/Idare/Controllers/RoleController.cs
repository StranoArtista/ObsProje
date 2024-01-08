using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObsProje.Models;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class RoleController : Controller
    {
        private readonly MyContext _context;
        private readonly SignInManager<User> _signInManager;

        public RoleController(MyContext context, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            bool isSignedIn = _signInManager.IsSignedIn(User);

            if (isSignedIn)
            {
                List<Exam> exams = _context.Exams.Where(x => x.Status == Enums.DataStatus.Active).ToList();

                return View(exams);
            }

            else
            {
                //todo: Login sayfasına yönlendirilecek !
                return View();
            }

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int id)
        {
            Role role = _context.Roles.First(x => x.ID == id);

            role.Status = Enums.DataStatus.Passive;

            _context.Roles.Update(role);

            int retval = _context.SaveChanges();

            DeleteReturnModel returnModel = new DeleteReturnModel();

            returnModel.IsSuccess = retval == 1;

            return JsonConvert.SerializeObject(returnModel);
        }

        public class DeleteReturnModel
        {
            public bool IsSuccess { get; set; }
        }
    }
    
}
