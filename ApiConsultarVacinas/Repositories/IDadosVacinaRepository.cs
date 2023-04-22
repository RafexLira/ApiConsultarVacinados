using ApiConsultarVacinas.Model;

namespace ApiConsultarVacinas.Repositories
{
    public interface IDadosVacinaRepository
    {
        void Save();
        void Delete(int id);
        void Find(int id);
        void FindAll();
        void Update(int id);
        void Add(DadosVacina dadosVacina);
    }
}
