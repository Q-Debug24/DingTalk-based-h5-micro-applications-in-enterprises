using DingDingPuls.Datas;
using DingDingPuls.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public class CheckEFService : ICheckEFService
    {
        public readonly DingDingDBContext _dingDingDBContext;

        public CheckEFService(
            DingDingDBContext dingDingDBContext)
        {
            _dingDingDBContext = dingDingDBContext;
        }

        public async Task<CheckTable> AddAsync(CheckTable model)
        {
            _dingDingDBContext.CheckTable.Add(model);
            await _dingDingDBContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(CheckTable model)
        {
            _dingDingDBContext.CheckTable.Remove(model);
            await _dingDingDBContext.SaveChangesAsync();
        }

        public async Task<List<CheckTable>> GetAllAsync()
        {
            // var content = _dingDingDBContext.CheckTable.Include(r => r.Assets).Include(r => r.Department);
            return await _dingDingDBContext.CheckTable.ToListAsync();
        }

        public async Task<CheckTable> GetByIdAsync(int id)
        {
            var checkTable = await _dingDingDBContext.CheckTable
              .Include(r => r.Assets)
              .Include(r => r.Department)
              .FirstOrDefaultAsync(m => m.Id == id);
            return checkTable;
        }

        public async Task UpdateAsync(CheckTable model)
        {
            _dingDingDBContext.Entry(model).State = EntityState.Modified;
            await _dingDingDBContext.SaveChangesAsync();
        }
    }
}