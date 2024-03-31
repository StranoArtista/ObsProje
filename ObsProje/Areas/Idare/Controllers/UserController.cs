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
            
            
            
            //ObsProje.Models.User user= _userManager.GetUserAsync(User);
            //if (user!=null)
            //{
            //    List<User> users = _context.Users.Where(x => x.Status == Enums.DataStatus.Active).ToList();

            //    return View(users);
            //}
            //else
            //{
            //    // Kullanıcı bulunamadı, giriş sayfasına yönlendir
            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}



            //bool isSignedIn = _signInManager.IsSignedIn(user);

            //if (isSignedIn)
            //{
                
            //}

            //else
            //{
            //    //todo: Login sayfasına yönlendirilecek !
            //    return RedirectToAction("Index","Home",new {area=""});
            //}
            
        }

        public IActionResult Create()
        {
            //UserVM _UserVM = new UserVM();
            //List<SelectListItem> listItems= new List<SelectListItem>();
            //foreach(var data in _context.Roles.Where(x=>x.Status==Enums.DataStatus.Active))
            //{
            //    SelectListItem listItem = new SelectListItem() 
            //    {
            //        Value=data.ID.ToString(),
            //        Text=data.Name
            //    };
            //    listItems.Add(listItem);
            //}
            //_UserVM.Roles = listItems;
            //return View(_UserVM);
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            //if(ModelState.IsValid)
            //{
            //    User _user = new User() 
            //    {
            //        UserName = uservm.UserName,
            //        Password = uservm.Password,
            //        Name = uservm.Name,
            //        Surname = uservm.Surname,
            //        TelNo = uservm.TelNo,
            //        Address = uservm.Address,
            //        TCKN = uservm.TCKN,
            //        Email = uservm.Email,
            //        RoleId=uservm.RoleID

            //    };
            //    var actives = _context.Users.Where(x => x.Status == Enums.DataStatus.Active);
            //    foreach (var users in actives)
            //    {
            //        if (_user.UserName.ToUpper() == uservm.UserName.ToUpper())
            //        {
            //            TempData["extUserName"] = "Bu kullanıcı adı zaten oluşturulmuş.";
            //            return View(uservm);
            //        }
            //        if (_user.TCKN == uservm.TCKN)
            //        {

            //            TempData["extTCKN"] = "Bu kimlik numarasına sahip başka bir kullanıcı mevcut.";
            //            return View(uservm);
            //        }

            //    }
            //    _context.Users.Add(_user);
            //    _context.SaveChanges();
            //    TempData["SuccessMessage"] = "Kullanıcı Başarıyla Oluşturuldu !";

            //    return RedirectToAction("Index","Idare",new {area="Idare"});
            //}
            //List<SelectListItem> listItems = new List<SelectListItem>();
            //foreach (var data in _context.Roles.Where(x=>x.Status==Enums.DataStatus.Active).ToList())
            //{
            //    SelectListItem listItem = new SelectListItem() 
            //    {
            //        Value=data.ID.ToString(),
            //        Text=data.Name
            //    };
            //    listItems.Add(listItem);

            //}
            //uservm.Roles= listItems;
            //return View(uservm);
            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index", user);
        }

        public IActionResult Update()
        {
            //var user=_context.Set<User>().Find(id);
            //List<SelectListItem> listItems=new List<SelectListItem>();
            //foreach (var data in _context.Roles.Where(x=>x.Status==Enums.DataStatus.Active))
            //{
            //    SelectListItem listItem = new SelectListItem()
            //    {
            //        Value = data.ID.ToString(),
            //        Text = data.Name
            //    };

            //    listItems.Add(listItem);
            //}
            //UserVM userVM = new UserVM() 
            //{
            //    UserName = user.UserName,
            //    Password = user.Password,
            //    Name = user.Name,
            //    Surname = user.Surname,
            //    TelNo = user.TelNo,
            //    Address = user.Address,
            //    TCKN = user.TCKN,
            //    Email = user.Email,
            //    RoleID = user.RoleId
            //};
            return View();
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    User _user = new User()
            //    {
            //        ID = userVM.ID,
            //        UserName = userVM.UserName,
            //        Password = userVM.Password,
            //        Name = userVM.Name,
            //        Surname = userVM.Surname,
            //        TelNo = userVM.TelNo,
            //        Address = userVM.Address,
            //        TCKN = userVM.TCKN,
            //        Email = userVM.Email,
            //        RoleId = userVM.RoleID
            //    };

            //    var users = _context.Users.Where(x=>x.Status==Enums.DataStatus.Active);

            //    foreach (var user in users)
            //    {
            //        if (_user.UserName.ToUpper() == user.UserName.ToUpper() && _user.ID!=user.ID)
            //        {
            //            TempData["extUserName"] = "Bu kullanıcı adı zaten oluşturulmuş.";
            //            return View(userVM);
            //        }
            //        if (_user.TCKN == user.TCKN && _user.ID!=user.ID)
            //        {

            //            TempData["extTCKN"] = "Bu kimlik numarasına sahip başka bir kullanıcı mevcut.";
            //            return View(userVM);
            //        }
            //    }

            //    _user.UpdatedDate = DateTime.Now;
            //    _user.Status = Enums.DataStatus.Modified;

            //    User originalEntity=_context.Users.FirstOrDefault(_user);
            //    _context.Entry(originalEntity).CurrentValues.SetValues(_user);
            //    _context.SaveChanges();
            //    TempData["UpdateMessage"] = "Kullanıcı Başarıyla Güncellendi !";

            //    return RedirectToAction("Index","Idare",new {area="Idare"});
            //}
            //List<SelectListItem> listItems = new List<SelectListItem>();

            //foreach (var data in _context.Roles.Where(x => x.Status == Enums.DataStatus.Active))
            //{
            //    SelectListItem listItem = new SelectListItem()
            //    {
            //        Value = data.ID.ToString(),
            //        Text = data.Name
            //    };

            //    listItems.Add(listItem);
            //}

            //userVM.Roles = listItems;

            //return View(userVM);
            _context.Users.Update(user);
            user.Status = Enums.DataStatus.Modified;
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index", user);
        }

        //[HttpPost]
        //public string Delete(int id)
        //{
        //    User user = _context.Users.First(x => x.ID == id);

        //    //user.Status = Enums.DataStatus.Passive;
        //    //user.DeletedDate = DateTime.Now;

        //    _context.Users.Update(user);
        //    //_context.SaveChanges();

        //    int retval = _context.SaveChanges();

        //    DeleteReturnModel returnModel = new DeleteReturnModel();

        //    returnModel.IsSuccess = retval == 1;

        //    return RedirectToAction("Index");
        //}

        public class DeleteReturnModel
        {
            public bool IsSuccess { get; set; }
        }
    }
}
