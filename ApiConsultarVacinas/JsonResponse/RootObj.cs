using Newtonsoft.Json;

namespace ApiConsultarVacinas.JsonResponse
{
    public class RootObj
    {
        [JsonProperty("hits")]
        public Hits Hits { get; set; }

        [JsonProperty("_scroll_id")]
        public string ScrollId { get; set; }
    }
}
