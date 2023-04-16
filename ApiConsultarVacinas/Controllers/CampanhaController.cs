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
        private readonly IApiCampanhaServices _api;

        public CampanhaController(IApiCampanhaServices api)
        {
            _api = api;
        }

        [HttpGet]
        [Route("default")]
        public async Task<List<Scroll>> GetSearchDefault(string nome, string cpf)
        {
            return await _api.SearchDefault();
        }

        [HttpPost]
        [Route("searchM")]
        public async Task<List<Scroll>> SearchM(string nome, string cpf)
        {
            return await _api.SearchM();
        }

        [HttpPost]
        [Route("scroll")]
        public async Task<List<Scroll>> SearchScroll([FromBody] CampanhaVacinaRequest request)
        {
            var scrollId = request.ScrollId;
            return await _api.SearchScroll(scrollId);
        }
    }
}
