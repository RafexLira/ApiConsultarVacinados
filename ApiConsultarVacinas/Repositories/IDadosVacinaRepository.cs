using ApiConsultarVacinas.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.Repositories
{
    public interface IDadosVacinaRepository
    {

        void Add(DadosVacina dadosVacina);
        void Delete(int id);
        DbSet<DadosVacina> Find(Solicitante solicitante);
        //void FindAll();
        //void Save();
        //void Update(int id);
      
    }
}
