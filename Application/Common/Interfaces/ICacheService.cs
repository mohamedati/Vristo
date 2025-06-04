using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public  interface ICacheService
    {
          Task<string> GetByKey(string key);


       Task SetByKey(string key,string value,TimeSpan? expiry);

        Task DeleteAsync(string pattern);

    }
}
