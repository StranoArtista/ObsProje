using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObsProje.Models;
using ObsProje.Models.ViewModels;

namespace ObsProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly MyContext _context;
        public HomeController(UserManager<User> userManager,SignInManager<User> signInManager,MyContext context )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OgrenciGiris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OgrenciGiris(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var _user = new User()
                {
                    UserName = loginVM.UserName,
                    Password = loginVM.Password
                };
                if (_user != null && _user.Status == Enums.DataStatus.Active || _user.Status == Enums.DataStatus.Modified)
                {
                    List<User> userList = _context.Users.Where(x => x.Status == Enums.DataStatus.Active).ToList();

                    foreach (var user in userList)
                    {
                        if (user.UserName == _user.UserName && user.Password == _user.Password)
                        {
                            return RedirectToAction("Index", "Ogrenci", new { area = "Ogrenci" });
                        }

                    }
                }
                else
                {
                    TempData["loginFailed"] = "Kullanıcı adı veya şifre hatalı!";
                    return View(loginVM);
                }
            }
            else
            {
                TempData["loginfailed"] = "Kullanıcı adı veya şifre hatalı !";

                return View(loginVM);
            }
            return View(loginVM);
        }
        public IActionResult OgretmenGiris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OgretmenGiris(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var _user = new User()
                {
                    UserName = loginVM.UserName,
                    Password = loginVM.Password
                };
                if (_user != null && _user.Status == Enums.DataStatus.Active || _user.Status == Enums.DataStatus.Modified)
                {
                    List<User> userList = _context.Users.Where(x => x.Status == Enums.DataStatus.Active).ToList();

                    foreach (var user in userList)
                    {
                        if (user.UserName == _user.UserName && user.Password == _user.Password)
                        {
                            return RedirectToAction("Index", "Ogretmen", new { area = "Ogretmen" });
                        }

                    }
                }
                else
                {
                    TempData["loginFailed"] = "Kullanıcı adı veya şifre hatalı!";
                    return View(loginVM);
                }
            }
            else
            {
                TempData["loginfailed"] = "Kullanıcı adı veya şifre hatalı !";

                return View(loginVM);
            }
            return View(loginVM);
        }
        public IActionResult IdareGiris()
        {
            
            return View();
        }
        [HttpPost]
        public  IActionResult IdareGiris(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                var _user = new User() 
                {
                    UserName = loginVM.UserName,
                    Password = loginVM.Password
                };
                //var result = await _signInManager.PasswordSignInAsync(_user, loginVM.Password,false,false);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("Index", "Idare", new { area = "Idare" });
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                //    return View(loginVM);
                //}
                if (_user != null && _user.Status == Enums.DataStatus.Active || _user.Status == Enums.DataStatus.Modified)
                {
                    List<User> userList = _context.Users.Where(x => x.Status == Enums.DataStatus.Active).ToList();

                    foreach (var user in userList)
                    {
                        if (user.UserName == _user.UserName && user.Password == _user.Password)
                        {
                            return RedirectToAction("Index", "Idare", new { area = "Idare" });
                        }

                    }
                }
                else
                {
                    TempData["loginFailed"] = "Kullanıcı adı veya şifre hatalı!";
                    return View(loginVM);
                }
            }
            else
            {
                TempData["loginfailed"] = "Kullanıcı adı veya şifre hatalı !";

                return View(loginVM);
            }
            return View(loginVM);
        }
        
    }
}
