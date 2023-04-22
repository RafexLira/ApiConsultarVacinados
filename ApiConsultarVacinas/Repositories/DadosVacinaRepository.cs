using ApiConsultarVacinas.Context;
using ApiConsultarVacinas.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.Repositories
{
    public class DadosVacinaRepository : IDadosVacinaRepository
    {
        private readonly VacinaContext _context;
        public DadosVacinaRepository(VacinaContext dbContext)
        {
            _context = dbContext;
        }
        public void Add(DadosVacina dadosVacina)
        {
            _context.Add(dadosVacina);             
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
