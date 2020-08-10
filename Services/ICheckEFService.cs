using DingDingPuls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public interface ICheckEFService
    {
        Task<List<CheckTable>> GetAllAsync();

        Task<CheckTable> GetByIdAsync(int id);

        Task<CheckTable> AddAsync(CheckTable model);

        Task UpdateAsync(CheckTable model);

        Task DeleteAsync(CheckTable model);
    }
}