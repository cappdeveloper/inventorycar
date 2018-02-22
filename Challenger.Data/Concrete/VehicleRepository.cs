using Challenger.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Data.Concrete
{
    public class VehicleRepository : RepositoryBase<Vehicle>
    {
        public VehicleRepository(ChallengerContext context) : base(context) { }
    }
}
