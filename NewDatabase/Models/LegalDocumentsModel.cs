using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class LegalDocumentsModel : BaseModel
    {
        [JsonPropertyName("id_akt")]
        public Int64 DocumentsId { get; set; }

        [JsonPropertyName("tytul_akt")]
        public string DocumentTitle { get; set; }

        [JsonPropertyName("adres_publikacyjny")]
        public string PublicationAddress { get; set; }

        [JsonPropertyName("inne_publikacje")]
        public string OtherPublications { get; set; }

    }
}
