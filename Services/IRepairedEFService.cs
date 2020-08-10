using DingDingPuls.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public interface IRepairedEFService
    {
        Task<List<RepairTable>> GetAllAsync();

        Task<RepairTable> GetByIdAsync(int id);

        Task<RepairTable> AddAsync(RepairTable model);

        Task UpdateAsync(RepairTable model);

        Task DeleteAsync(RepairTable model);
    }
}