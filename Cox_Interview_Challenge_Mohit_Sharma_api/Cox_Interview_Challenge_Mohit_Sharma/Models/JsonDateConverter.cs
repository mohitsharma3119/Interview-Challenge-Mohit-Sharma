using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cox_Interview_Challenge_Mohit_Sharma.Models
{
    class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}