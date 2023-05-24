using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories
{
    public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}