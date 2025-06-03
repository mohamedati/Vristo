using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Common
{
    public  class BaseAuditingEntity
    {
        public string CreatedBy { get; set; } = null!;

        public string CreatedAt { get; set; } = null!;


        public string UpdatedBy { get; set; } = null!;

        public string UpdatedAt { get; set; } = null!;


        public string DeletedBy { get; set; } = null!;

        public string DeletedAt { get; set; } = null!;


        public ApplicationUser Creator { get; set; }

        public ApplicationUser Updater { get; set; }


        public ApplicationUser Deleter { get; set; }
    }
}
