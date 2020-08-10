using DingDingPuls.Datas;
using DingDingPuls.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public class RepairedEFService : IRepairedEFService
    {
        public readonly DingDingDBContext _dingDingDBContext;

        public RepairedEFService(DingDingDBContext dingDingDBContext)
        {
            _dingDingDBContext = dingDingDBContext;
        }

        public async Task<RepairTable> AddAsync(RepairTable model)
        {
            _dingDingDBContext.RepairTable.Add(model);
            await _dingDingDBContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(RepairTable model)
        {
            _dingDingDBContext.RepairTable.Remove(model);
            await _dingDingDBContext.SaveChangesAsync();
        }

        public async Task<List<RepairTable>> GetAllAsync()
        {
            // var obj = new SelectList(_dingDingDBContext.LegerTable, "Id", "AssetsName");
            var context = _dingDingDBContext.RepairTable.Include(r => r.Assets).Include(r => r.Department);
            return await context.ToListAsync();
        }

        public async Task<RepairTable> GetByIdAsync(int id)
        {
            var repairTable = await _dingDingDBContext.RepairTable
               .Include(r => r.Assets)
               .Include(r => r.Department)
               .FirstOrDefaultAsync(m => m.Id == id);

            return repairTable;
            //return await _dingDingDBContext.RepairTable.FindAsync(id);
        }

        public async Task UpdateAsync(RepairTable model)
        {
            _dingDingDBContext.Entry(model).State = EntityState.Modified;
            await _dingDingDBContext.SaveChangesAsync();
        }

        private bool RepairTableExists(int id)
        {
            return _dingDingDBContext.RepairTable.Any(e => e.Id == id);
        }
    }
}