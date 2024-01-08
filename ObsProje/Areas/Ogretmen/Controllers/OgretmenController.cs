using Microsoft.AspNetCore.Mvc;

namespace ObsProje.Areas.Ogretmen.Controllers
{
    public class OgretmenController : Controller
    {
        [Area("Ogretmen")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
