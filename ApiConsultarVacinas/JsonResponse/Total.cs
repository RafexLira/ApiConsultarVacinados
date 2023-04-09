using Newtonsoft.Json;

namespace ApiConsultarVacinas.JsonResponse
{
    public class Total
    {
        [JsonProperty("value")]
        public int value { get; set; }

        [JsonProperty("relation")]
        public string relation { get; set; }
    }
}
