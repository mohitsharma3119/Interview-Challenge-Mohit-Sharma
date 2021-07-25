using Cox_Interview_Challenge_Mohit_Sharma.Mappers;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.Interfaces
{
    public interface IDealershipRepository
    {
        Task<List<Dealerships>> GetAllAsync();
        Task<Dealerships> GetDealershipDetails(int dealNumber);
        MostSoldVehicle GetByMostSoldVehicleAsync();
        Task<bool> CreateDealershipAsync(Dealerships dealership);
        Task<bool> BulkInsertDealershipAsync(List<Dealerships> dealership);
    }
}
