using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IFuelRepository : IBaseRepository<Fuel, Guid>, IAsyncRepository<Fuel, Guid>
{
}
