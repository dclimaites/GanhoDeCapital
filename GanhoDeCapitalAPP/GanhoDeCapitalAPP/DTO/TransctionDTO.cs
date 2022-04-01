using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.DTO
{
    public class TransctionDTO
    {
        [JsonPropertyName("operation")]
        public string Operation { get; set; }
        [JsonPropertyName("unit-cost")]
        public decimal UnitCost { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
