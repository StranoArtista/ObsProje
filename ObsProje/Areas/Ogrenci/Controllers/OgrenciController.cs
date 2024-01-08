using Microsoft.AspNetCore.Mvc;

namespace ObsProje.Areas.Ogrenci.Controllers
{
    public class OgrenciController : Controller
    {
        [Area("Ogrenci")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
