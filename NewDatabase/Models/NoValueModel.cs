using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class NoValueModel
    {
        [JsonPropertyName("id_brak_wartosci")]
        public int NoValueId { get; set; }

        [JsonPropertyName("oznaczenie")]
        public string Mark { get; set; }

        [JsonPropertyName("nazwa")]
        public string Name { get; set; }
    }
}
