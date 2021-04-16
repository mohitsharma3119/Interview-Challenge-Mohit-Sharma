using Cox_Interview_Challenge_Mohit_Sharma.Domain;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.DAL
{
    public class DealershipRepository : IDealershipRepository
    {
        private readonly DealershipContext _context;

        public DealershipRepository(DealershipContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<bool> CreateDealershipAsync(Dealerships newDealership)
        {
            _context.Add(newDealership);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public async Task<bool> BulkInsertDealershipAsync(List<Dealerships> newDealership)
        {           
            try
            {
                await _context.BulkInsertAsync(newDealership);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDealershipAsync(int dealNumber)
        {
            try
            {
                var toDelete = _context.Dealerships.Find(dealNumber);
                _context.Dealerships.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task<List<Dealerships>> GetAllAsync()
        {
            return await _context.Dealerships.ToListAsync();
        }

        public dynamic GetByMostSoldVehicleAsync()
        {          
            var dealership =  (from dlr in _context.Dealerships
                             group dlr by dlr.Vehicle into g
                             orderby g.Count() descending
                             select new 
                             {
                                Vehicle = g.Key,
                                count = g.Count()
                             });           
            return dealership.ToList().FirstOrDefault();
        }
    }
}
