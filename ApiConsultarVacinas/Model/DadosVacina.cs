namespace ApiConsultarVacinas.Model
{
    public class DadosVacina
    {
        public int Id { get; set; }      
        public string HitId { get; set; }      
        public string PacienteId { get; set; }  
        public string DataSolicitacao { get; set; }
        public string DataAplicacao { get; set; }
        public string Descricao { get; set; }      
        public Solicitante Solicitante { get; set; }
    }
}
