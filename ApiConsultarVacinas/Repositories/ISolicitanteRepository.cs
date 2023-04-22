namespace ApiConsultarVacinas.Repositories
{
    public interface ISolicitanteRepository
    {
        void Save();
        void Delete(int id);
        void Find(int id);
        void FindAll();
        void Update(int id);
    }
}
