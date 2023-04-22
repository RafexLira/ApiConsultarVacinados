using Microsoft.EntityFrameworkCore;

namespace ApiConsultarVacinas.UnitWork
{
    public interface IUnitOfWorks
    {
        void Commit();
        void Rollback();
    }
    
}
