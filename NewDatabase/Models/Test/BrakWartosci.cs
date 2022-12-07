using System.Text.Json.Serialization;
namespace NewDatabase.Models
{


	public class BrakWartosci : BaseModel
{

		[JsonPropertyName("id-brak-wartosci")]
		public Int32 IdBrakWartosci { get; set; }

		[JsonPropertyName("oznaczenie")]
		public string Oznaczenie { get; set; }

		[JsonPropertyName("nazwa")]
		public string Nazwa { get; set; }

	}

}

