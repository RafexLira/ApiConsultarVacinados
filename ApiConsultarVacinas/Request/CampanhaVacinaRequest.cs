using Newtonsoft.Json;

namespace ApiConsultarVacinas.Request
{
    public class CampanhaVacinaRequest
    {
        [JsonProperty("scrollid")]
        public string ScrollId {get;set;}
        public string Cpf { get;set;}
        public string Nome { get;set;}
        public string Conteudo { get; set; }
    }
}
