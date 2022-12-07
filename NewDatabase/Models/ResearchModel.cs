using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class ResearchModel
    {
        [JsonPropertyName("id_badanie")]
        public Int64 ResearchId { get; set; }

        [JsonPropertyName("symbol_badanie")]
        public string ResearchSymbol { get; set; }

        [JsonPropertyName("temat_badanie")]
        public string ResearchTopic { get; set; }

        [JsonPropertyName("badanie_cel")]
        public string ResearchGoal { get; set; }
    }
}
