using ApiConsultarVacinas.JsonResponse;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Services
{
    public interface IApiCampanhaServices
    {
        Task<List<Scroll>> SearchDefault(Solicitante solicitante);
        Task<List<Scroll>> SearchM(Solicitante solicitante);
        Task<List<Scroll>> SearchScroll(string scrollId, Solicitante solicitante);
        Task<List<Scroll>> ServiceResponse(string url, string credentials, string fromBody, Solicitante solicitante);
        string Credential();
        string CPF(string cpf);
    }
}
