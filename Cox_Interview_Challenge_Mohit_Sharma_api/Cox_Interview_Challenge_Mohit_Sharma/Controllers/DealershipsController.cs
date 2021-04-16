using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using Cox_Interview_Challenge_Mohit_Sharma.Domain;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Collections;

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
        public async Task<IActionResult> GetMostSoldVehicle()
        {
            try
            {
                dynamic mostSold =  _dealershipRepository.GetByMostSoldVehicleAsync();
                return StatusCode(200, mostSold);
            }
            catch (Exception ex)
            {
                return  StatusCode(500, ex); ;
            }

        }

        //// GET: Dealerships/Details/5
        public async Task<IActionResult> GetDealerships(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                //call repository to get by deal number/id
                return StatusCode(200, "");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
