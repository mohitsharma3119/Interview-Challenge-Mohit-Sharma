using Moq;
using System;
using Xunit;
using Cox_Interview_Challenge_Mohit_Sharma.Interfaces;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using Cox_Interview_Challenge_Mohit_Sharma.Controllers;

namespace DealershipTest
{
    public class DealershipTest 
    {
        #region Property  
        public Mock<IDealershipRepository> mockDealership = new();
        public Mock<ICsvService> mockCsvService = new();
        #endregion       

        [Fact]
        public async void GetDealershipDetailsTest()
        {
            var dealerships = new Dealerships()
            {
                DealNumber = 4589,
                CustomerName = "MS",
                DealershipName = "Test Dealership",
                Vehicle = "2018 Ford Mustang",
                Price = 350987,
                Date = DateTime.Now.Date
            };
            mockDealership.Setup(p => p.GetDealershipDetails(4589)).ReturnsAsync(dealerships);
            DealershipsController dealership = new DealershipsController(mockCsvService.Object, mockDealership.Object);
            var result = await dealership.GetDealershipDetailsByDealNumber(4589);
            Assert.True(dealerships.Equals(result));
        }
    }
}
