using ApiConsultarVacinas.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.Repositories
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly VacinaContext _context;
        public SolicitanteRepository(VacinaContext dbContext)
        {
            _context = dbContext;
        }
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public void FindAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {          
            throw new System.NotImplementedException();
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
