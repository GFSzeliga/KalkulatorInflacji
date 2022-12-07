using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class DataModel : BaseModel
    {
        [JsonPropertyName("data")]
        public int Data { get; set; }
    }
}
