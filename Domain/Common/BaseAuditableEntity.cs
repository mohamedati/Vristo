﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public  class BaseAuditableEntity<T>:BaseAuditingEntity
    {
        public T Id { get; set; }

    


    }
}
