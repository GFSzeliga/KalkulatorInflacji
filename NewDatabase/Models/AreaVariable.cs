using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class AreaVariable : BaseModel
    {
        public int Id { get; set; }

        [JsonPropertyName("Nazwa")]
        public string Name { get; set; }

        [JsonPropertyName("id-zmienna")]
        public int VariableId { get; set; }

        [JsonPropertyName("nazwa-zmienna")]
        public string? NameVariable { get; set; }

    }
}
