using ETicaretAPI.Application.Repositories.BasketRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories.BasketRepository
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
