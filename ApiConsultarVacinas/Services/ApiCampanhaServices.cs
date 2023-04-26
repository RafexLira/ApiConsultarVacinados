using ApiConsultarVacinas.JsonResponse;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Repositories;
using ApiConsultarVacinas.Response;
using ApiConsultarVacinas.UnitWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Services
{
    public class ApiCampanhaServices : IApiCampanhaServices
    {
        private IConfiguration _configuration;
        private RootObj responseApi;
        private List<CampanhaVacinaResponse> campanhaVacinaResponses = new List<CampanhaVacinaResponse>();
        private List<Scroll> Scrolls = new List<Scroll>();
        private IUnitOfWorks _UnitOfWorks;
        private IDadosVacinaRepository _dadosVacinaRepository;
        private ISolicitanteRepository _solicitanteRepository;
        private List<DadosVacina> dadosVacina = new List<DadosVacina>();

        public ApiCampanhaServices(IConfiguration configuration, IUnitOfWorks UnitOfWorks, IDadosVacinaRepository dadosVacinaRepository, ISolicitanteRepository solicitanteRepository)
        {
            _configuration = configuration;
            _UnitOfWorks = UnitOfWorks;
            _dadosVacinaRepository = dadosVacinaRepository;
            _solicitanteRepository = solicitanteRepository;
        }

        public async Task<List<Scroll>> SearchDefault(Solicitante solicitante)
        {
            if (_solicitanteRepository.SolicitanteExist(solicitante.CPF))
            {
                return DbResponse(solicitante);
            }

            var url = _configuration["Uri1"];
            var response = await ServiceResponse(url, Credential(), "", solicitante);

            return response;
        }

        public async Task<List<Scroll>> SearchM(Solicitante solicitante)
        {
            if (_solicitanteRepository.SolicitanteExist(solicitante.CPF))
            {
                return DbResponse(solicitante);
            }
            var url = _configuration["Uri2"];
            var conteudo = "{\"size\": 10000 }";
            var response = await ServiceResponse(url, Credential(), conteudo, solicitante);

            return response;
        }

        public async Task<List<Scroll>> SearchScroll(string scrollId, Solicitante solicitante)
        {
            if (_solicitanteRepository.SolicitanteExist(solicitante.CPF))
            {
                return DbResponse(solicitante);
            }

            var url = _configuration["Uri3"];

            var conteudo = "{\"scroll_id\":\"" + scrollId + "\"," + " \"scroll\":\"1m\"}";

            var response = await ServiceResponse(url, Credential(), conteudo, solicitante);
            return response;
        }

        public async Task<List<Scroll>> ServiceResponse(string url, string credentials, string fromBody, Solicitante dadosSolicitante)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Api Campanha Vacina");

                    var httpContent = new StringContent(fromBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        responseApi = JsonConvert.DeserializeObject<RootObj>(responseContent);
                        var hits = responseApi.Hits.hits;

                        foreach (var hit in hits)
                        {                      
                            var vacina = new DadosVacina() 
                            {
                                HitId = hit.Id,
                                PacienteId = hit.Source.PacienteId,
                                DataSolicitacao = hit.Source.DataImportacaoDatalake,
                                DataAplicacao = hit.Source.VacinaDataAplicacao,
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em" + hit.Source.VacinaDataAplicacao,
                            };
                            dadosVacina.Add(vacina);                   

                            var vacinaResponse = new CampanhaVacinaResponse()
                            {
                                HitId = hit.Id,
                                PacienteId = hit.Source.PacienteId,
                                DataSolicitacao = hit.Source.DataImportacaoDatalake,
                                DataAplicacao = hit.Source.VacinaDataAplicacao,
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em: " + hit.Source.VacinaDataAplicacao,
                                NomeSolicitante = dadosSolicitante.Nome
                            };

                            campanhaVacinaResponses.Add(vacinaResponse);

                        }
                        var solicitante = new Solicitante()
                        {
                            Nome = dadosSolicitante.Nome,
                            CPF = dadosSolicitante.CPF,
                            DadosVacina = dadosVacina
                        };
                        _solicitanteRepository.Add(solicitante);
                        _UnitOfWorks.Commit();
                        
                        Scrolls.Add(new Scroll { ScrollId = responseApi.ScrollId, CampanhaVacina = campanhaVacinaResponses });
                    }
                    else
                    {
                        var result = response.StatusCode;
                    }
                }
            }

            catch (Exception e)
            {

            }

            return Scrolls;
        }
        public string Credential()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_configuration["_User"]}:{_configuration["_Password"]}"));
        }

        public List<Scroll> DbResponse(Solicitante solicitante)
        {
            var dadosVacinaDb = _dadosVacinaRepository.Find(solicitante);

            if (dadosVacinaDb != null)
            {
                CampanhaVacinaResponse vacinaResponse = null;
                foreach (var dadosVacinas in dadosVacinaDb)
                {              
                    vacinaResponse = new CampanhaVacinaResponse()
                    {
                        HitId = dadosVacinas.Id.ToString(),
                        PacienteId = dadosVacinas.PacienteId,
                        DataSolicitacao = dadosVacinas.DataSolicitacao,
                        DataAplicacao = dadosVacinas.DataAplicacao,
                        Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em: " + dadosVacinas.DataAplicacao
                    };

                    campanhaVacinaResponses.Add(vacinaResponse);
                }
                Scrolls.Add(new Scroll { CampanhaVacina = campanhaVacinaResponses });
            }

            return Scrolls;
        }

        public void GetServiceResponse()
        {

        }
        public string CPF(string cpf)
        {
            return _solicitanteRepository.FindCpf(cpf);
        }


    }
}
