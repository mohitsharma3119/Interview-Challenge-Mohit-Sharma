using Cox_Interview_Challenge_Mohit_Sharma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.Domain
{
    public interface IDealershipRepository : IDisposable
    {
        Task<List<Dealerships>> GetAllAsync();
        dynamic GetByMostSoldVehicleAsync();
        Task<bool> CreateDealershipAsync(Dealerships dealership);
        Task<bool> BulkInsertDealershipAsync(List<Dealerships> dealership);
    }
}
