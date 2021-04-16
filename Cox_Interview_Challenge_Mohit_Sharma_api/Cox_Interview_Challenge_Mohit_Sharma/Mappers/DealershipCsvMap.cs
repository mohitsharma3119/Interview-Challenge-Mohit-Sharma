using Cox_Interview_Challenge_Mohit_Sharma.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cox_Interview_Challenge_Mohit_Sharma.Mappers
{
    public sealed class DealershipCsvMap : ClassMap<Dealerships>
    {
        public DealershipCsvMap()
        {
            Map(x => x.DealNumber).Name("DealNumber");
            Map(x => x.CustomerName).Name("CustomerName");
            Map(x => x.DealershipName).Name("DealershipName");
            Map(x => x.Vehicle).Name("Vehicle");
            Map(x => x.Price).Name("Price");
            Map(x => x.Date).Name("Date");
        }
    }
}
