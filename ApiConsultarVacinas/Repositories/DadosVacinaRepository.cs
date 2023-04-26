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
            var dadosVacinaId = _context.DadosVacinas.Find(id);
            _context.DadosVacinas.Remove(dadosVacinaId);
        }

        public DbSet<DadosVacina> Find(Solicitante solicitante)
        {
            DbSet<DadosVacina> dadosVacinas = null;

            var _solicitante = _context.Solicitantes;

            foreach (var sol in _solicitante)
            {
                if (sol.CPF == solicitante.CPF)
                {
                    dadosVacinas = _context.DadosVacinas;
                    return dadosVacinas;
                }
            }

            return dadosVacinas;
        }

        //public void FindAll()
        //{
        //    throw new System.NotFiniteNumberException();
        //}

        //public void Save()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Update(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
