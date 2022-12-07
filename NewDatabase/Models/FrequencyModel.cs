using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class FrequencyModel
    {
        [JsonPropertyName("id_czestotliwosc")]
        public int FrequencyId { get; set; }

        [JsonPropertyName("nazwa_czestotliwosc")]
        public string FrequencyName { get; set; }
    }
}
