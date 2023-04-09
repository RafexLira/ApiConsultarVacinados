using System.Collections.Generic;

namespace ApiConsultarVacinas.Response
{
    public class Scroll
    {
        public string ScrollId { get; set; }
        public List<CampanhaVacinaResponse> CampanhaVacina { get; set; }
    }
}
