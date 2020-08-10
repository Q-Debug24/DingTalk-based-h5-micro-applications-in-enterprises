using DingDingPuls.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public interface IDepartmentEFService
    {
        Task<List<DepartmentTable>> GetAllAsync();

        Task<DepartmentTable> GetByIdAsync(int id);

        Task<DepartmentTable> AddAsync(DepartmentTable model);

        Task UpdateAsync(DepartmentTable model);

        Task DeleteAsync(DepartmentTable model);
    }
}