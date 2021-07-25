using Cox_Interview_Challenge_Mohit_Sharma.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.Interfaces
{
    public interface ICsvService
    {
        public List<Dealerships> ReadCSVFile(IFormFile file);
        public void WriteCSVFile(string path, List<Dealerships> dealerships);
    }
}
