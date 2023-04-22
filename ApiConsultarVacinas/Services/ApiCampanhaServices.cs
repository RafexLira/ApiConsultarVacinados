using ApiConsultarVacinas.Context;
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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Services
{
    public class ApiCampanhaServices : IApiCampanhaServices
    {
        private IConfiguration _configuration;
        private RootObj responseApi;     
        private List<CampanhaVacinaResponse> campanhaVacinaResponses = new List<CampanhaVacinaResponse>();
        private List<DadosVacina> DadosVacinas = new List<DadosVacina>();
        private List<Scroll> Scrolls = new List<Scroll>();
        private IUnitOfWorks _UnitOfWorks;
        private VacinaContext _context;
        private IDadosVacinaRepository _dadosVacinaRepository;       
       
        public ApiCampanhaServices(IConfiguration configuration, IUnitOfWorks UnitOfWorks, IDadosVacinaRepository dadosVacinaRepository)
        {
            _configuration = configuration;
            _UnitOfWorks = UnitOfWorks;
            _dadosVacinaRepository = dadosVacinaRepository;            
        }

        public async Task<List<Scroll>> SearchDefault()
        {
            var url = _configuration["Uri1"];
            var response = await PostService(url, Credential(), "");

            return response;
        }

        public async Task<List<Scroll>> SearchM()
        {          
            var url = _configuration["Uri2"];
            var conteudo = "{\"size\": 10000 }";
            var response = await PostService(url, Credential(), conteudo);

            return response;
        }

        public async Task<List<Scroll>> SearchScroll(string scrollId)
        {           
            var url = _configuration["Uri3"];

            var conteudo = "{\"scroll_id\":\"" + scrollId+"\","+" \"scroll\":\"1m\"}";       

            var response = await PostService(url, Credential(), conteudo);
            return response;
        }

        public async Task<List<Scroll>> PostService(string url, string credentials, string fromBody)
        {      
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Api Campanha Vacina");              
                    
                    var httpContent = new StringContent(fromBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(url,httpContent);

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
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em" + hit.Source.VacinaDataAplicacao
                            };
                            var vacinaResponse = new CampanhaVacinaResponse()
                            {
                                HitId = hit.Id,
                                PacienteId = hit.Source.PacienteId,
                                DataSolicitacao = hit.Source.DataImportacaoDatalake,
                                DataAplicacao = hit.Source.VacinaDataAplicacao,
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em: " + hit.Source.VacinaDataAplicacao
                            };

                            _dadosVacinaRepository.Add(vacina);                           
                            _UnitOfWorks.Commit();
                            campanhaVacinaResponses.Add(vacinaResponse);
                        }

                        Scrolls.Add(new Scroll {ScrollId = responseApi.ScrollId, CampanhaVacina = campanhaVacinaResponses });                        
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

        public void GetServiceResponse()
        {

        }

    }
}
