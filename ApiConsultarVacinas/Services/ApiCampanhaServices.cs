using ApiConsultarVacinas.JsonResponse;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Response;
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

        //Falta configurar injeção
        public ApiCampanhaServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Scroll>> SearchDefault()
        {
            var url = _configuration["Uri1"];
            var response = await GetService(url, Credential(), "");

            return response;
        }

        public async Task<List<Scroll>> SearchM()
        {
            //Falta pegar o retorno do Id Scroll de getService e salvar em uma variável
            //Para ser adicionado na chamada SearchScroll 
            var url = _configuration["Uri2"];
            var size1000 = "{ \"size\": 10000}";
            var response = await GetService(url, Credential(), size1000);

            return response;
        }

        public async Task<List<Scroll>> SearchScroll()
        {
            //Falta pegar o Id Scroll e usar no parâmetro conforme documentação da api
            //Estou usando o scroll estatico temporariamente para testes

            var url = _configuration["Uri3"];
            var scroll = "{ \"scroll_id\": \"FGluY2x1ZGVfY29udGV4dF91dWlkDnF1ZXJ5VGhlbkZldGNoHhY5VDJCckZvOVFyMm03ZHRPNjF4QUdBAAAAAIMjYOYWbXl3TVIzRUFTMUNUU2p2NHRuaXIzZxZwSHBiRklZX1RKaXpLdm5RWjN0OE53AAAAACAqCLsWYXM2M3RXcVVSUjIwZUk5bmJhUHFHURY5VDJCckZvOVFyMm03ZHRPNjF4QUdBAAAAAIMjYOcWbXl3TVIzRUFTMUNUU2p2NHRuaXIzZxZ1ZldXQzg0YlFGS2FfTWRMQXk3WUxnAAAAAI98kzwWVU9BamwxZ1BSNU9IcFpCRGtVbGtzdxZyUGZCV2Z5LVI2ZWdUbXVWUkRMbzN3AAAAAATKDH8WSV80VGNNRVRUU0NUU0RBYzFoTlNkURZ1ZldXQzg0YlFGS2FfTWRMQXk3WUxnAAAAAI98kz0WVU9BamwxZ1BSNU9IcFpCRGtVbGtzdxZXaDBsb3ZFVVNNT2l3eEh4amRlYkFRAAAAAAC8wR8WcUlmaVY2MUlROHVlbEVtMVNXNDZTdxZwSHBiRklZX1RKaXpLdm5RWjN0OE53AAAAACAqCLwWYXM2M3RXcVVSUjIwZUk5bmJhUHFHURZheXE2MUpBU1NxQ0kzRXlpcnhhYWhRAAAAAIr8mBQWc09SS2Q1UHhUM1c5LVNJOVZfemVNQRZwSHBiRklZX1RKaXpLdm5RWjN0OE53AAAAACAqCL0WYXM2M3RXcVVSUjIwZUk5bmJhUHFHURZyUGZCV2Z5LVI2ZWdUbXVWUkRMbzN3AAAAAATKDIAWSV80VGNNRVRUU0NUU0RBYzFoTlNkURZheXE2MUpBU1NxQ0kzRXlpcnhhYWhRAAAAAIr8mBUWc09SS2Q1UHhUM1c5LVNJOVZfemVNQRZheXE2MUpBU1NxQ0kzRXlpcnhhYWhRAAAAAIr8mBMWc09SS2Q1UHhUM1c5LVNJOVZfemVNQRZKQWV3TjVla1NtLXE0Vmh6eFU3djRRAAAAAHoxk7gWblVHTHVkWFpRYk83ajB1anZlNTVnQRZ1ZldXQzg0YlFGS2FfTWRMQXk3WUxnAAAAAI98kz8WVU9BamwxZ1BSNU9IcFpCRGtVbGtzdxZ1ZldXQzg0YlFGS2FfTWRMQXk3WUxnAAAAAI98kz4WVU9BamwxZ1BSNU9IcFpCRGtVbGtzdxZwSHBiRklZX1RKaXpLdm5RWjN0OE53AAAAACAqCL4WYXM2M3RXcVVSUjIwZUk5bmJhUHFHURZKQWV3TjVla1NtLXE0Vmh6eFU3djRRAAAAAHoxk7YWblVHTHVkWFpRYk83ajB1anZlNTVnQRZXaDBsb3ZFVVNNT2l3eEh4amRlYkFRAAAAAAC8wSEWcUlmaVY2MUlROHVlbEVtMVNXNDZTdxZXaDBsb3ZFVVNNT2l3eEh4amRlYkFRAAAAAAC8wSAWcUlmaVY2MUlROHVlbEVtMVNXNDZTdxZKQWV3TjVla1NtLXE0Vmh6eFU3djRRAAAAAHoxk7cWblVHTHVkWFpRYk83ajB1anZlNTVnQRZxU1MyTmZYclFSS3J1Z3FYbUd0TGtnAAAAAAZp7I0WWVFUMmExdmNTVFdQTURWVmxtQl9zZxZxU1MyTmZYclFSS3J1Z3FYbUd0TGtnAAAAAAZp7IwWWVFUMmExdmNTVFdQTURWVmxtQl9zZxZyUGZCV2Z5LVI2ZWdUbXVWUkRMbzN3AAAAAATKDIEWSV80VGNNRVRUU0NUU0RBYzFoTlNkURZXUVF0NFRwM1F2R3FhN0V1ak1jWEhBAAAAAFqUUKgWU21WOEFHMWRTalNsWmRHSW51bjJEURZXUVF0NFRwM1F2R3FhN0V1ak1jWEhBAAAAAFqUUKcWU21WOEFHMWRTalNsWmRHSW51bjJEURZXUVF0NFRwM1F2R3FhN0V1ak1jWEhBAAAAAFqUUKkWU21WOEFHMWRTalNsWmRHSW51bjJEURZxU1MyTmZYclFSS3J1Z3FYbUd0TGtnAAAAAAZp7I4WWVFUMmExdmNTVFdQTURWVmxtQl9zZxZXUVF0NFRwM1F2R3FhN0V1ak1jWEhBAAAAAFqUUKoWU21WOEFHMWRTalNsWmRHSW51bjJEURZXaDBsb3ZFVVNNT2l3eEh4amRlYkFRAAAAAAC8wSIWcUlmaVY2MUlROHVlbEVtMVNXNDZTdw==\", \"scroll\": \"1m\"}";
            var response = await GetService(url, Credential(), scroll);
            return response;
        }

        public async Task<List<Scroll>> GetService(string url, string credentials, string fromBody)
        {      
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Api Consultar Vacina");

                    var httpContent = new StringContent(fromBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.GetAsync(url);

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
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em: " + hit.Source.VacinaDataAplicacao
                            };
                            var vacinaResponse = new CampanhaVacinaResponse()
                            {
                                HitId = hit.Id,
                                PacienteId = hit.Source.PacienteId,
                                DataSolicitacao = hit.Source.DataImportacaoDatalake,
                                DataAplicacao = hit.Source.VacinaDataAplicacao,
                                Descricao = "Relatório Vacinas Pfizer aplicadas no RJ em: " + hit.Source.VacinaDataAplicacao
                            };

                            DadosVacinas.Add(vacina);
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
