using ApiConsultarVacinas.JsonResponse;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Request;
using ApiConsultarVacinas.Response;
using ApiConsultarVacinas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        //resolver questões de injeção
        private readonly IApiCampanhaServices _apiService;

        public CampanhaController(IApiCampanhaServices api)
        {
            _apiService = api;
        }

        [HttpGet]
        [Route("default")]
        public async Task<List<Scroll>> GetSearchDefault([FromBody] CampanhaVacinaRequest request)
        {
            var solicitante = new Solicitante()
            {
                Nome = request.Nome,
                CPF = request.Cpf
            };
            return await _apiService.SearchDefault(solicitante);
        }

        [HttpPost]
        [Route("searchM")]
        public async Task<List<Scroll>> SearchM([FromBody] CampanhaVacinaRequest request)
        {
            var solicitante = new Solicitante()
            {
                Nome = request.Nome,
                CPF = request.Cpf
            };
            return await _apiService.SearchM(solicitante);
        }

        [HttpPost]
        [Route("scroll")]
        public async Task<List<Scroll>> SearchScroll([FromBody] CampanhaVacinaRequest request)
        {
            var solicitante = new Solicitante()
            {
                Nome = request.Nome,
                CPF = request.Cpf
            };
            return await _apiService.SearchScroll(request.ScrollId, solicitante);
        }

        [HttpPost]
        [Route("CPF")]
        public string CPF([FromBody] CampanhaVacinaRequest request)
        {
            return _apiService.CPF(request.Cpf);
        }
    }
}
