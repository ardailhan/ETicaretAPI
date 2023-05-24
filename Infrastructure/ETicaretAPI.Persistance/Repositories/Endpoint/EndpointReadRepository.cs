using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories
{
    public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}