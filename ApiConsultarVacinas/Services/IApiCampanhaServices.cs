﻿using ApiConsultarVacinas.JsonResponse;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiConsultarVacinas.Services
{
    public interface IApiCampanhaServices
    {
        Task<List<Scroll>> SearchDefault();
        Task<List<Scroll>> SearchM();
        Task<List<Scroll>> SearchScroll(string scrollId);
        Task<List<Scroll>> PostService(string url, string credentials, string fromBody);
        string Credential();
    }
}
