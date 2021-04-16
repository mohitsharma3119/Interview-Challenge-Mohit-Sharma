using Cox_Interview_Challenge_Mohit_Sharma.Domain;
using Cox_Interview_Challenge_Mohit_Sharma.Mappers;
using Cox_Interview_Challenge_Mohit_Sharma.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.Services
{
    public class CsvService : ICsvService
    {
        public List<Dealerships> ReadCSVFile(IFormFile file)
        {
            try
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "TempFiles");
                var filePath = "";

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                         file.CopyTo(stream);
                    }                   
                }

                using (var reader = new StreamReader(filePath, Encoding.UTF7))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Context.RegisterClassMap<DealershipCsvMap>();
                    var records = csv.GetRecords<Dealerships>().ToList();
                    reader.Close();
                    File.Delete(filePath);
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void WriteCSVFile(string path, List<Dealerships> dealerships)
        {
            throw new NotImplementedException();
        }
    }
}
