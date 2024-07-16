using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : BaseEntity<Guid>
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }

        public virtual Brand Brand { get; set; } = default!;
        public virtual ICollection<Car> Cars { get; set; } = default!;
    }
}
