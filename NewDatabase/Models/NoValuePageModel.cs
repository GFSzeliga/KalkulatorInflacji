using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class NoValuePageModel
    {
        [JsonPropertyName("page_Number")]
        public int PageNumber { get; set; }

        [JsonPropertyName("page_Size")]
        public int PageSize { get; set; }

        [JsonPropertyName("page_Count")]
        public int PageCount { get; set; }

        public IEnumerable<NoValueModel> NoValueModels { get; set; }
    }
}
