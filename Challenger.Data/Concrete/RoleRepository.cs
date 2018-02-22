﻿using Challenger.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Data.Concrete
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(ChallengerContext context) : base(context) { }
    }
}