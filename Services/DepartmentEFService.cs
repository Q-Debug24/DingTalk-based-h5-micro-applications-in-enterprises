using DingDingPuls.Datas;
using DingDingPuls.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public class DepartmentEFService : IDepartmentEFService
    {
        public readonly DingDingDBContext _dingDingDBContext;

        public DepartmentEFService(DingDingDBContext dingDingDBContext)
        {
            _dingDingDBContext = dingDingDBContext;
        }

        public async Task<DepartmentTable> AddAsync(DepartmentTable model)
        {
            _dingDingDBContext.DepartmentTable.Add(model);
            await _dingDingDBContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(DepartmentTable model)
        {
            _dingDingDBContext.DepartmentTable.Remove(model);
            await _dingDingDBContext.SaveChangesAsync();
        }

        public async Task<List<DepartmentTable>> GetAllAsync()
        {
            return await _dingDingDBContext.DepartmentTable.ToListAsync();
        }

        public async Task<DepartmentTable> GetByIdAsync(int id)
        {
            return await _dingDingDBContext.DepartmentTable.FindAsync(id);
        }

        public async Task UpdateAsync(DepartmentTable model)
        {
            _dingDingDBContext.Entry(model).State = EntityState.Modified;
            await _dingDingDBContext.SaveChangesAsync();
        }
    }
}