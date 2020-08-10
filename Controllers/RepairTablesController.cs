using DingDingPuls.Datas;
using DingDingPuls.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Controllers
{
    public class RepairTablesController : Controller
    {
        private readonly DingDingDBContext _context;

        public RepairTablesController(DingDingDBContext context)
        {
            _context = context;
        }

        // GET: RepairTables
        public async Task<IActionResult> Index()
        {
            var dingDingDBContext = _context.RepairTable.Include(r => r.Assets).Include(r => r.Department);
            return View(await dingDingDBContext.ToListAsync());
        }

        // GET: RepairTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTable = await _context.RepairTable
                .Include(r => r.Assets)
                .Include(r => r.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTable == null)
            {
                return NotFound();
            }

            return View(repairTable);
        }

        // GET: RepairTables/Create
        public IActionResult Create()
        {
            ViewData["AssetsId"] = new SelectList(_context.LegerTable, "Id", "AssetsName");
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTable, "Id", "Name");
            return View();
        }

        // POST: RepairTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatNumber,AssetsId,DepartmentId,BrokenTime,StartTime,EndTime,WorkerName,IsFinshed,Cost,Workers,PlanTime,Applicant,Reason,Leader,Note,CheckStatus")] RepairTable repairTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetsId"] = new SelectList(_context.LegerTable, "Id", "AssetsName", repairTable.AssetsId);
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTable, "Id", "Name", repairTable.DepartmentId);
            return View(repairTable);
        }

        // GET: RepairTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTable = await _context.RepairTable.FindAsync(id);
            if (repairTable == null)
            {
                return NotFound();
            }
            ViewData["AssetsId"] = new SelectList(_context.LegerTable, "Id", "AssetsClass", repairTable.AssetsId);
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTable, "Id", "Name", repairTable.DepartmentId);
            return View(repairTable);
        }

        // POST: RepairTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatNumber,AssetsId,DepartmentId,BrokenTime,StartTime,EndTime,WorkerName,IsFinshed,Cost,Workers,PlanTime,Applicant,Reason,Leader,Note,CheckStatus")] RepairTable repairTable)
        {
            if (id != repairTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairTableExists(repairTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetsId"] = new SelectList(_context.LegerTable, "Id", "AssetsClass", repairTable.AssetsId);
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTable, "Id", "Name", repairTable.DepartmentId);
            return View(repairTable);
        }

        // GET: RepairTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTable = await _context.RepairTable
                .Include(r => r.Assets)
                .Include(r => r.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTable == null)
            {
                return NotFound();
            }

            return View(repairTable);
        }

        // POST: RepairTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairTable = await _context.RepairTable.FindAsync(id);
            _context.RepairTable.Remove(repairTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairTableExists(int id)
        {
            return _context.RepairTable.Any(e => e.Id == id);
        }
    }
}