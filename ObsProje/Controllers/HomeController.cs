using Microsoft.AspNetCore.Mvc;

namespace ObsProje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OgrenciGiris()
        {
            return View();
        }
        public IActionResult OgretmenGiris()
        {
            return View();
        }
        public IActionResult IdareGiris()
        {
            return View();
        }
    }
}
