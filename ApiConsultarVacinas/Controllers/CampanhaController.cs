using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<VacinadosCovidResponse> GetSearchDefault(string nome, string cpf)
        {
            return await _api.SearchDefault();
        }

        [HttpPost]
        [Route("searchM")]
        public async Task<VacinadosCovidResponse> SearchM(string nome, string cpf)
        {
            return await _api.SearchM();
        }

        [HttpPost]
        [Route("Scroll")]
        public async Task<VacinadosCovidResponse> SearchScroll(string nome, string cpf)
        {
            return await _api.SearchScroll();
        }
    }
}
