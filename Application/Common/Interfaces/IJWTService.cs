﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public  interface  IJWTService
    {
         Task<string> GenerateToken(ApplicationUser user);

        string GenerateRefreshToken();



    }
}
