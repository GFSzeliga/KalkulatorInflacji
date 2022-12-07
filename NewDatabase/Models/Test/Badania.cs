using System.Text.Json.Serialization;
namespace NewDatabase.Models
{


	public class Badania : BaseModel
{

		[JsonPropertyName("id-badanie")]
		public Int64 IdBadanie { get; set; }

		[JsonPropertyName("symbol-badanie")]
		public string SymbolBadanie { get; set; }

		[JsonPropertyName("temat-badanie")]
		public string TematBadanie { get; set; }

		[JsonPropertyName("badanie-cel")]
		public string BadanieCel { get; set; }

	}

}

