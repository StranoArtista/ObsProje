using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObsProje.Models;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class ClassController : Controller
    {
        private readonly MyContext _context;
        private readonly SignInManager<User> _signInManager;

        public ClassController(MyContext context, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            bool isSignedIn = _signInManager.IsSignedIn(User);

            if (isSignedIn)
            {
                List<Class> classes = _context.Classes.Where(x => x.Status == Enums.DataStatus.Active).ToList();

                return View(classes);
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
        public IActionResult Create(Class obj)
        {
            _context.Classes.Add(obj);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Class obj)
        {
            _context.Classes.Update(obj);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int id)
        {
            Class obj = _context.Classes.First(x => x.ID == id);

            obj.Status = Enums.DataStatus.Passive;

            _context.Classes.Update(obj);

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
