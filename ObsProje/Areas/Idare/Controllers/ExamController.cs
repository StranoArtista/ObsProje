using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObsProje.Models;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class ExamController : Controller
    {   
        private readonly MyContext _context;
        private readonly SignInManager<User> _signInManager;

        public ExamController(MyContext context, SignInManager<User> signInManager)
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
        public IActionResult Create(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
            TempData["SuccessMessage"] = 1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int id)
        {
            Exam exam = _context.Exams.First(x => x.ID == id);

            exam.Status = Enums.DataStatus.Passive;

            _context.Exams.Update(exam);

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
