using ApiConsultarVacinas.Model;

namespace ApiConsultarVacinas.Response
{
    public class CampanhaVacinaResponse
    {
        public int Id { get; set; }
        public string PacienteId { get; set; }            
        public string HitId { get; set; }
        public string DataSolicitacao { get; set; }
        public string DataAplicacao { get; set; }
        public string Descricao { get; set; }
        public double QtdTotalVacinados { get; set; }
        public string NomeSolicitante { get; set; }
    }
}
