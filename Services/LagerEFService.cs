using DingDingPuls.Datas;
using DingDingPuls.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public class LagerEFService : ILagerEFService
    {
        public readonly DingDingDBContext _dingDingDBContext;

        public LagerEFService(DingDingDBContext dingDingDBContext)
        {
            _dingDingDBContext = dingDingDBContext;
        }

        public async Task<LegerTable> AddAsync(LegerTable model)
        {
            _dingDingDBContext.LegerTable.Add(model);
            await _dingDingDBContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(LegerTable model)
        {
            _dingDingDBContext.LegerTable.Remove(model);
            await _dingDingDBContext.SaveChangesAsync();
        }

        public async Task<List<LegerTable>> GetAllAsync()
        {
            return await _dingDingDBContext.LegerTable.ToListAsync();
        }

        public async Task<LegerTable> GetByIdAsync(int id)
        {
            return await _dingDingDBContext.LegerTable.FindAsync(id);
        }

        public async Task UpdateAsync(LegerTable model)
        {
            _dingDingDBContext.Entry(model).State = EntityState.Modified;
            await _dingDingDBContext.SaveChangesAsync();
        }
    }
}