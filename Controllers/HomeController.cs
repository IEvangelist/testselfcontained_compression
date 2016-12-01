using Microsoft.AspNetCore.Mvc;

namespace testselfcontained
{
    public class HomeController : Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}