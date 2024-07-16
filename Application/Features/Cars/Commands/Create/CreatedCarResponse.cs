using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create
{
    public class CreatedCarResponse
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public Guid ColorId { get; set; }
        public SaleState SaleState { get; set; }
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public long Kilometer { get; set; }
    }
}
