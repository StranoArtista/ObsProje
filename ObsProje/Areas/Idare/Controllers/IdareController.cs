using Microsoft.AspNetCore.Mvc;
using ObsProje.Models;

namespace ObsProje.Areas.Idare.Controllers
{
    [Area("Idare")]
    public class IdareController : Controller
    {   
        private readonly MyContext _context;

        public IdareController(MyContext context)
        {
            _context = context;
        }
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
