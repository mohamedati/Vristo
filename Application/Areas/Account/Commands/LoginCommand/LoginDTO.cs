﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Account.Commands.LoginCommand
{
    public  class LoginDTO
    {
        public string Token { get; set; } = null;
 
        public string RefreshToken { get; set; } = null;


    }
}
