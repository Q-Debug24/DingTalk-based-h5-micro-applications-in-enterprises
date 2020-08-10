using DingDingPuls.Datas;
using DingDingPuls.Models;
using DingDingPuls.Services;
using DingDingPuls.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Controllers
{
    public class RepairedController : Controller
    {
        public readonly IRepairedEFService _repairedEFService;
        public readonly DingDingDBContext _dingDingDBContext;
        private readonly ILogger<RepairedController> _logger;
        //private string accessToken = "d49682592f9e3fc9873f3287c7994d91";

        public RepairedController(
            IRepairedEFService repairedEFService,
            DingDingDBContext dingDingDBContext,
            ILogger<RepairedController> logger)
        {
            _repairedEFService = repairedEFService;
            _dingDingDBContext = dingDingDBContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var repairTables = await _repairedEFService.GetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                repairTables = repairTables.Where(s => s.CreatNumber.Contains(searchString)).ToList();
            }
            return View(repairTables);
        }

        public async Task<IActionResult> Details(int id)
        {
            var repairTable = await _repairedEFService.GetByIdAsync(id);
            if (repairTable == null)
            {
                return NotFound();
            }

            return View(repairTable);
        }

        public IActionResult AddTable()
        {
            ViewData["AssetsId"] = new SelectList(_dingDingDBContext.LegerTable, "Id", "AssetsName");
            ViewData["DepartmentId"] = new SelectList(_dingDingDBContext.DepartmentTable, "Id", "Name");
            //ViewData["CreatNmber"]=
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTable(RepairedViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Model is not valid");
                return View(model);
            }
            try
            {
                var newModel = new RepairTable
                {
                    CreatNumber = model.CreatNumber,
                    BrokenTime = model.BrokenTime,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    DepartmentId = model.DepartmentId,
                    AssetsId = model.AssetsId,
                    Workers = model.Workers,
                    Reason = model.Reason,
                    Applicant = "覃鸿宇",
                    Leader = "白小凡",
                    CheckStatus = "编制",
                    PlanTime = model.StartTime
                };
                await _repairedEFService.AddAsync(newModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Remade(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var repairTables = await _repairedEFService.GetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                repairTables = repairTables.Where(s => s.CreatNumber.Contains(searchString)).ToList();
            }
            return View(repairTables);
        }
    }
}