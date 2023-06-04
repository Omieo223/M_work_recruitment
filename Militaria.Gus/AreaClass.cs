using System.Text.Json.Serialization;

namespace Militaria.Gus
{
    public class AreaClass
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nazwa")]
        public string Nazwa { get; set; }

        [JsonPropertyName("id-nadrzedny-element")]
        public int IdNadrzednyElement { get; set; }

        [JsonPropertyName("id-poziom")]
        public int IdPoziom { get; set; }


        [JsonPropertyName("nazwa-poziom")]
        public string NazwaPoziom { get; set; }


        [JsonPropertyName("czy-zmienne")]
        public bool CzyZmienne { get; set; }
    }
}
