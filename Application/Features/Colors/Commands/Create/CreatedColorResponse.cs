using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Create
{
    public class CreatedColorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
