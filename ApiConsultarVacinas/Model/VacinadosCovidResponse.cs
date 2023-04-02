using Newtonsoft.Json;

namespace ApiConsultarVacinas.Model
{
    public class VacinadosCovidResponse
    {
        [JsonProperty("_scroll_id")]
        public int ScrollId { get; set; }

        [JsonProperty("document_id")]
        public int IdDocumento { get; set; }

        [JsonProperty("paciente_id")]
        public int IdPaciente { get; set; }
      
        [JsonProperty("estabelecimento_uf")]
        public string Uf { get; set; }

        [JsonProperty("vacina_dataAplicacao")]
        public string DataAplicacao { get; set; }

        [JsonProperty("vacina_nome")]
        public string NomeVacina { get; set; }

        [JsonProperty("data_importacao_datalake")]
        public string DataSolicitacao { get; set; }  

    }
}
