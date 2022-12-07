using System.Text.Json.Serialization;

namespace NewDatabase.Models
{
    public class AreaModel : BaseModel
    {
        public int Id { get; set; }

        [JsonPropertyName("Nazwa")]
        public string Name { get; set; }
        
        [JsonPropertyName("id-nadrzedny-element")]
        public int? SuperiorElement { get; set; }

        [JsonPropertyName("id-poziom")]
        public int? Level { get; set; }

        [JsonPropertyName("nazwa-poziom")]
        public string? LevelName { get; set; }

        [JsonPropertyName("czy-zmienne")]
        public bool IsChanged { get; set; }

    }
}
