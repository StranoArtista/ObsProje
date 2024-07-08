using Microsoft.AspNetCore.Mvc;
using ObsProje.Models;

namespace ObsProje.Areas.Ogretmen.Controllers
{
    [Area("Ogretmen")]
    public class OgretmenController : Controller
    {


        private readonly MyContext _context;

        public OgretmenController(MyContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
