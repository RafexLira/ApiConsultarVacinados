using ApiConsultarVacinas.Model;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Services
{
    public interface IApiCampanhaServices
    {
        Task<VacinadosCovidResponse> SearchDefault();
        Task<VacinadosCovidResponse> SearchM();
        Task<VacinadosCovidResponse> SearchScroll();
        Task<VacinadosCovidResponse> GetService(string url, string credentials, string fromBody);
        string Credential();
    }
}
