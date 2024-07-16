using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Repositories;

public class EfFuelRepository : EfBaseRepository<Fuel, Guid, BorusanDbContext>, IFuelRepository
{
    public EfFuelRepository(BorusanDbContext context) : base(context)
    {
    }
}
