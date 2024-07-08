using Microsoft.AspNetCore.Mvc;
using ObsProje.Models;

namespace ObsProje.Areas.Ogrenci.Controllers
{
    [Area("Ogrenci")]
    public class OgrenciController : Controller
    {


        private readonly MyContext _context;

        public OgrenciController(MyContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
