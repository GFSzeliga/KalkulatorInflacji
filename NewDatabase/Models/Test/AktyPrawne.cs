using System.Text.Json.Serialization;
namespace NewDatabase.Models
{


	public class AktyPrawne : BaseModel
{

		[JsonPropertyName("id-akt")]
		public Int64 IdAkt { get; set; }

		[JsonPropertyName("tytul-akt")]
		public string TytulAkt { get; set; }

		[JsonPropertyName("adres-publikacyjny")]
		public string AdresPublikacyjny { get; set; }

		[JsonPropertyName("inne-publikacje")]
		public string InnePublikacje { get; set; }

	}

}

