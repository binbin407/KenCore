using Ken.Service;
using KenCore.Cache;
using KenCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KenCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICache _redisCatch;
        private readonly IUserService _userService;
        public HomeController(ICache redisCatch, IUserService userService)
        {
            _redisCatch = redisCatch;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            _redisCatch.Set("111", "222");
            await _userService.CreateUser(new Ken.Models.User()
            {
                RealName = "jacky.zhang"
            });
            var user = _userService.FirstOrDefaultAsync(1);
            ViewBag.Name = user.RealName;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
