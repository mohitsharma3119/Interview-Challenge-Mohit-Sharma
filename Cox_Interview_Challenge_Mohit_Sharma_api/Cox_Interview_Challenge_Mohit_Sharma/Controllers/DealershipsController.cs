using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using Cox_Interview_Challenge_Mohit_Sharma.Interfaces;
using System.Linq;
using Cox_Interview_Challenge_Mohit_Sharma.Mappers;

namespace Cox_Interview_Challenge_Mohit_Sharma.Controllers
{
    [Produces("application/json")]
    public class DealershipsController : Controller
    {
        private readonly ICsvService _csvService;
        private readonly IDealershipRepository _dealershipRepository;

        public DealershipsController(ICsvService csvService, IDealershipRepository dealershipRepository)
        {
            _csvService = csvService;
            _dealershipRepository = dealershipRepository;
        }

        [HttpGet]
        public async Task<Dealerships> GetDealershipDetailsByDealNumber(int dealNumber)
        {
            var result = await _dealershipRepository.GetDealershipDetails(dealNumber);
            return result;
        }

        // GET: Dealerships
        [HttpGet]
        public async Task<IActionResult> GetDealerships()
        {
            try
            {
                List<Dealerships> dealershipList = new List<Dealerships>();
                dealershipList = await _dealershipRepository.GetAllAsync();
                return StatusCode(200, dealershipList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult GetMostSoldVehicle()
        {
            try
            {
                MostSoldVehicle mostSold = new();
                mostSold =  _dealershipRepository.GetByMostSoldVehicleAsync();
                return StatusCode(200, mostSold);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        // POST: Dealerships/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,DealNumber,CustomerName,DealershipName,Vehicle,Price,Date")] Dealerships dealerships)
        {
            try
            {
                await _dealershipRepository.CreateDealershipAsync(dealerships);
                return StatusCode(201, "Created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        public async Task<IActionResult> UploadCsv()
        {
            try
            {
                var file = Request.Form.Files[0];
                List<Dealerships> dealerships = new List<Dealerships>();
                dealerships = _csvService.ReadCSVFile(file);
                await _dealershipRepository.BulkInsertDealershipAsync(dealerships);
                return StatusCode(201, "Created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// GET: Dealerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                    //call repository to delete
                    return StatusCode(202, "Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
