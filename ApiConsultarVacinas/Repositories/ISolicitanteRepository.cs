using ApiConsultarVacinas.Model;

namespace ApiConsultarVacinas.Repositories
{
    public interface ISolicitanteRepository
    {
        void Add(Solicitante solicitante);
        bool SolicitanteExist(string cpf);
        void Delete(int id);
        string FindCpf(string cpf);       
        void Update(int id);
    }
}
