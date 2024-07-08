using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ObsProje.Interfaces;
using ObsProje.Models;
using ObsProje.Models.ViewModels;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class UserController : Controller
    {
        private readonly MyContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly IManager<User> _userManager;

        public UserController(MyContext context, SignInManager<User> signInManager, IManager<User> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.GetActives();
            return View(users);
            
            
            
            
            
        }

        public IActionResult Create()
        {
            var _roles = _context.Roles.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            });

            var userVM = new UserVM
            {
                Roles = _roles                    
            };
            return View(userVM);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index", user.ID);
        }

        public IActionResult Update()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
           
            _context.Users.Update(user);
            user.Status = Enums.DataStatus.Modified;
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index", user);
        }

        

        public class DeleteReturnModel
        {
            public bool IsSuccess { get; set; }
        }
    }
}
