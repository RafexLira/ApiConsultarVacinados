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
        Task<string> ResponseScrollId(Solicitante solicitante);
        Task<List<Scroll>> SearchScroll(Solicitante solicitante);
        Task<string> ServiceResponseScrollId(string url, string credentials, string fromBody, Solicitante solicitante);
        string Credential();
        string CPF(string cpf);
    }
}
