using System.Collections.Generic;

namespace ApiConsultarVacinas.Model
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<DadosVacina> DadosVacina { get; set; }
    }
}
