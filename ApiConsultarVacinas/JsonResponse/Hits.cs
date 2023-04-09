using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiConsultarVacinas.JsonResponse
{
    public class Hits
    {
        [JsonProperty("total")]
        public Total total { get; set; }

        [JsonProperty("max_score")]
        public double max_score { get; set; }

        [JsonProperty("hits")]
        public List<Hit> hits { get; set; }
    }
}
