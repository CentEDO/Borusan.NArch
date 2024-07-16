using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IModelRepository : IBaseRepository<Model, Guid>, IAsyncRepository<Model, Guid>
{
}
