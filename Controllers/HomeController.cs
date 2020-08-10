using DingDingPuls.Models;
using DingDingPuls.Services;
using DingDingPuls.ViewModels;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        public readonly ICheckEFService _checkEFService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ICheckEFService checkEFService)
        {
            _logger = logger;
            Configuration = configuration;
            _checkEFService = checkEFService;
            //GetAuthToken();
        }

        public async Task<IActionResult> Homepage()
        {
            var result = await _checkEFService.GetAllAsync();
            //var isfinshed = from u in result where u.IsFinshed != 0 select u;
            var result1 = result.Where(s => s.IsFinshed == 0);
            var result2 = result.Where(s => s.IsFinshed == 1);
            var newmodel = new HomeViewModel();
            foreach (var item in result1)
            {
                newmodel.NoCreatNumberList.Add(item.CreatNumber);
                newmodel.NoEquNameList.Add(item.EquName);
                newmodel.NoFinshedId.Add(item.Id);
            };

            foreach (var item in result2)
            {
                newmodel.EquNameList.Add(item.EquName);
                newmodel.CreateNumberList.Add(item.CreatNumber);
                newmodel.FinshedId.Add(item.Id);
            };

            return View(newmodel);
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