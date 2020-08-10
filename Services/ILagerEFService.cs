using DingDingPuls.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public interface ILagerEFService
    {
        Task<List<LegerTable>> GetAllAsync();

        Task<LegerTable> GetByIdAsync(int id);

        Task<LegerTable> AddAsync(LegerTable model);

        Task UpdateAsync(LegerTable model);

        Task DeleteAsync(LegerTable model);
    }
}