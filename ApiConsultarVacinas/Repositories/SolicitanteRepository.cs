using ApiConsultarVacinas.Context;
using ApiConsultarVacinas.Model;

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
        public string FindCpf(string cpf)
        {
            var Solicitante = _context.Solicitantes;

            foreach (var solicitante in Solicitante)
            {
                if (solicitante.CPF == cpf)
                {
                    return solicitante.CPF;
                }
            }
            return "";
        }       
        public void Add(Solicitante solicitante)
        {
            if (!SolicitanteExist(solicitante.CPF))
            {
                _context.Solicitantes.Add(solicitante);
            }           
        }

        public bool SolicitanteExist(string cpf)
        {
            var retornoCpf = FindCpf(cpf);

            if (retornoCpf != "")
            {
                return true;
            }
            return false;
        }
        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
