using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface ITransmissionRepository : IBaseRepository<Transmission, Guid>, IAsyncRepository<Transmission, Guid>
{
}
