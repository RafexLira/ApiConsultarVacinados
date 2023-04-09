using Newtonsoft.Json;

namespace ApiConsultarVacinas.JsonResponse
{
    public class Source
    {
        [JsonProperty("vacina_grupoAtendimento_nome")]
        public string VacinaGrupoAtendimentoNome { get; set; }

        [JsonProperty("vacina_codigo")]
        public string VacinaCodigo { get; set; }

        [JsonProperty("paciente_dataNascimento")]
        public string PacienteDataNascimento { get; set; }

        [JsonProperty("ds_condicao_maternal")]
        public string DsCondicaoMaternal { get; set; }

        [JsonProperty("paciente_endereco_nmPais")]
        public string PacienteEnderecoNmPais { get; set; }

        [JsonProperty("paciente_racaCor_valor")]
        public string PacienteRacaCorValor { get; set; }

        [JsonProperty("sistema_origem")]
        public string SistemaOrigem { get; set; }

        [JsonProperty("paciente_id")]
        public string PacienteId { get; set; }

        [JsonProperty("paciente_endereco_uf")]
        public string PacienteEnderecoUf { get; set; }

        [JsonProperty("paciente_idade")]
        public int PacienteIdade { get; set; }

        [JsonProperty("paciente_endereco_cep")]
        public string PacienteEnderecoCep { get; set; }

        [JsonProperty("estabelecimento_valor")]
        public string EstabelecimentoValor { get; set; }

        [JsonProperty("estabelecimento_municipio_codigo")]
        public string EstabelecimentoMunicipioCodigo { get; set; }

        [JsonProperty("data_importacao_datalake")]
        public string DataImportacaoDatalake { get; set; }

        [JsonProperty("paciente_enumSexoBiologico")]
        public string PacienteEnumSexoBiologico { get; set; }

        [JsonProperty("estabelecimento_municipio_nome")]
        public string EstabelecimentoMunicipioNome { get; set; }

        [JsonProperty("vacina_grupoAtendimento_codigo")]
        public string VacinaGrupoAtendimentoCodigo { get; set; }

        [JsonProperty("vacina_descricao_dose")]
        public string VacinaDescricaoDose { get; set; }

        [JsonProperty("paciente_endereco_nmMunicipio")]
        public string PacienteEnderecoNmMunicipio { get; set; }

        [JsonProperty("vacina_categoria_nome")]
        public string VacinaCategoriaNome { get; set; }

        [JsonProperty("vacina_fabricante_nome")]
        public string VacinaFabricanteNome { get; set; }

        [JsonProperty("vacina_categoria_codigo")]
        public string VacinaCategoriaCodigo { get; set; }

        [JsonProperty("dt_deleted")]
        public string DtDeleted { get; set; }

        [JsonProperty("paciente_nacionalidade_enumNacionalidade")]
        public string PacienteNacionalidadeEnumNacionalidade { get; set; }

        [JsonProperty("vacina_numDose")]
        public string VacinaNumDose { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("document_id")]
        public string DocumentId { get; set; }

        [JsonProperty("vacina_lote")]
        public string VacinaLote { get; set; }

        [JsonProperty("id_sistema_origem")]
        public string IdSistemaOrigem { get; set; }

        [JsonProperty("@timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("estalecimento_noFantasia")]
        public string EstabelecimentoNoFantasia { get; set; }

        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("paciente_racaCor_codigo")]
        public string PacienteRacaCorCodigo { get; set; }

        [JsonProperty("estabelecimento_razaoSocial")]
        public string EstabelecimentoRazaoSocial { get; set; }

        [JsonProperty("vacina_nome")]
        public string VacinaNome { get; set; }

        [JsonProperty("estabelecimento_uf")]
        public string EstabelecimentoUf { get; set; }

        [JsonProperty("data_importacao_rnds")]
        public string DataImportacaoRnd { get; set; }

        [JsonProperty("vacina_dataAplicacao")]
        public string VacinaDataAplicacao { get; set; }

        [JsonProperty("co_condicao_maternal")]
        public object CoCondicaoMaternal { get; set; }

        [JsonProperty("paciente_endereco_coPais")]
        public string PacienteEnderecoCoPais { get; set; }

        [JsonProperty("vacina_fabricante_referencia")]
        public string VacinaFabricanteReferencia { get; set; }

        [JsonProperty("paciente_endereco_coIbgeMunicipio")]
        public string PacienteEnderecoCoIbgeMunicipio { get; set; }
    }
}
