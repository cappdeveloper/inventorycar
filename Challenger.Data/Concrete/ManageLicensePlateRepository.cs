using Challenger.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Data.Concrete
{
    class ManageLicensePlateRepository:RepositoryBase<Role>
    {
        public ManageLicensePlateRepository(ChallengerContext context) : base(context) { }
    }

   
}
