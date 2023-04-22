using ApiConsultarVacinas.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.Context
{
    public class VacinaContext :DbContext
    {
        public VacinaContext(DbContextOptions<VacinaContext> options) :base (options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<DadosVacina> DadosVacinas { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
    }
}
