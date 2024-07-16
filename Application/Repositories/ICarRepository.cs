using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICarRepository: IAsyncRepository<Car,Guid> , IBaseRepository<Car,Guid>
    {
        Task<Car?> GetByPlateAsync(string plate);
    }
}
