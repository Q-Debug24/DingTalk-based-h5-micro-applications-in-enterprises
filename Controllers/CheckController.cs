using DingDingPuls.Models;
using DingDingPuls.Services;
using DingDingPuls.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Controllers
{
    public class CheckController : Controller
    {
        public readonly ICheckEFService _checkEFService;

        private readonly ILogger<CheckController> _logger;
        public IConfiguration _configuration { get; }

        public CheckController(
            ICheckEFService checkEFService,
            ILogger<CheckController> logger,
            IConfiguration configuration
           )
        {
            _checkEFService = checkEFService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IActionResult> SentCheck(int id)
        {
            if (id == 2020)
            {
                var model = new CheckViewModel
                {
                    CreatNumber = null,
                    EquName = null
                };
                return View(model);
            }
            else
            {
                var result = await _checkEFService.GetByIdAsync(id);
                if (result != null)
                {
                    var model = new CheckViewModel
                    {
                        CreatNumber = result.CreatNumber,
                        EquName = result.EquName
                    };
                    return View(model);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SentCheck(CheckViewModel model, int id)
        {
            if (id == 2020)
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Model is not valid");
                    return View(model);
                }

                var newmodel = new CheckTable
                {
                    CreatNumber = model.CreatNumber,
                    EquName = model.EquName,
                    CheckAreas = model.CheckAreas,
                    CheckResult = model.CheckResult,
                    CheckStatus = model.CheckStatus,
                    CheckStartTime = model.CheckStartTime,
                    CheckCyc = model.CheckCyc,
                    WorkerName = model.WorkerName,
                    Note = model.Note,
                    IsFinshed = 1,
                    AssetsId = 9,
                    DepartmentId = 5
                };
                await _checkEFService.AddAsync(newmodel);

                return RedirectToAction("homepage", "home");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Model is not valid");
                    return View(model);
                }

                try
                {
                    var result = await _checkEFService.GetByIdAsync(id);

                    result.CreatNumber = model.CreatNumber;
                    result.EquName = model.EquName;
                    result.CheckAreas = model.CheckAreas;
                    result.CheckResult = model.CheckResult;
                    result.CheckStatus = model.CheckStatus;
                    result.CheckStartTime = model.CheckStartTime;
                    result.CheckCyc = model.CheckCyc;
                    result.WorkerName = model.WorkerName;
                    result.Note = model.Note;
                    result.IsFinshed = 1;
                    result.AssetsId = 9;
                    result.DepartmentId = 5;

                    await _checkEFService.UpdateAsync(result);

                    return RedirectToAction("homepage", "home");
                }
                catch
                {
                    return View(model);
                }
            }
        }

        public async Task<IActionResult> CheckDetial(int id)
        {
            var model = await _checkEFService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}