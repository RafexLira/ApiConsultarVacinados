using ApiConsultarVacinas.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.UnitWork
{
    public class UnitForWorks : IUnitOfWorks
    {
        private VacinaContext _dbContext;

        public UnitForWorks(VacinaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();            
        }
        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}
