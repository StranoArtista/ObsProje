using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObsProje.Interfaces;
using ObsProje.Models;
using ObsProje.Models.ViewModels;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class RoleController : Controller
    {
        private readonly MyContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly IManager<Role> _roleManager;
        public RoleController(MyContext context, SignInManager<User> signInManager,IManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.GetActives();
            return View(roles);
            //bool isSignedIn = _signInManager.IsSignedIn(User);

            //if (isSignedIn)
            //{
            //    List<Role> roles = _context.Roles.Where(x => x.Status == Enums.DataStatus.Active).ToList();

            //    return View(roles);
            //}

            //else
            //{
            //    //todo: Login sayfasına yönlendirilecek !
            //    return RedirectToAction("Index","Home",new {area=""});
            //}
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleVM role)
        {
            if (ModelState.IsValid)
            {
                Role _role = new Role()
                {
                    Name = role.RoleName,
                    Role_Exp = role.RoleDescription

                };
                var actives = _roleManager.GetActives();
                foreach (var roles in actives)
                {
                    if (_role.Name.ToUpper() == roles.Name.ToUpper())
                    {
                        TempData["extRoleName"] = "Bu rol zaten oluşturulmuş.";
                        return View(role);
                    }

                }
                _roleManager.Add(_role);
                TempData["SuccessMessage"] = "Rol Başarıyla Oluşturuldu !";

                return RedirectToAction("Index");

            }
            else
            {
                return View(role);
            }
            //if(ModelState.IsValid)
            //{
            //    _context.Roles.Add(role);
            //    _context.SaveChanges();
            //    TempData["SuccessMessage"] = 1;
            //    return RedirectToAction("Index");
            //}
            //return View(nameof(Create),role);
        }

        public IActionResult Update(int id)
        {
            var role = _roleManager.Find(id);

            RoleVM roleVM = new RoleVM()
            {
                Id = role.ID,
                RoleName = role.Name,
                RoleDescription = role.Role_Exp
            };

            return View(roleVM);
        }

        [HttpPost]
        public IActionResult Update(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                Role _role = new Role()
                {
                    ID = roleVM.Id,
                    Name = roleVM.RoleName,
                    Role_Exp = roleVM.RoleDescription

                };

                var roles = _roleManager.GetActives();

                foreach (var role in roles)
                {
                    if (_role.Name.ToUpper() == role.Name.ToUpper())
                    {
                        TempData["extRoleName"] = "Bu tip zaten oluşturulmuş.";
                        return View(roleVM);
                    }

                }

                _roleManager.Update(_role);

                TempData["UpdateMessage"] = "Malzeme Tipi Başarıyla Güncellendi !";

                return RedirectToAction("Index");
            }

            return View(roleVM);
            //_context.Roles.Update(role);
            //_context.SaveChanges();
            //TempData["SuccessMessage"] = 1;
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var role = _roleManager.Find(id);
            _roleManager.Delete(role);
            return RedirectToAction("Index","Idare",new {area="Idare"});
            //Role role = _context.Roles.First(x => x.ID == id);

            //role.Status = Enums.DataStatus.Passive;

            //_context.Roles.Update(role);

            //int retval = _context.SaveChanges();

            //DeleteReturnModel returnModel = new DeleteReturnModel();

            //returnModel.IsSuccess = retval == 1;

            //return JsonConvert.SerializeObject(returnModel);
        }

        //public class DeleteReturnModel
        //{
        //    public bool IsSuccess { get; set; }
        //}
    }
    
}
