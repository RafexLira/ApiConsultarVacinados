using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VacinaController : ControllerBase
    {       
        private ApiCampanhaServices _api;

        public VacinaController(ApiCampanhaServices api)
        {          
            _api = api;
        }        

        [HttpGet]
        [Route("default")]
        public async Task<VacinadosCovidResponse> GetSearchDefault()
        {
            return await _api.SearchDefault();           
        }

        [HttpPost]
        [Route("searchM")]
        public async Task<VacinadosCovidResponse> SearchM()
        {
          return await _api.SearchM();          
        }

        [HttpPost]
        [Route("Scroll")]
        public async Task<VacinadosCovidResponse> SearchScroll()
        {
          return await _api.SearchScroll();          
        }

      

    }
}
