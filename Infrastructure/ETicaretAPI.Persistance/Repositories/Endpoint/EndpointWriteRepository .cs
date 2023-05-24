using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}