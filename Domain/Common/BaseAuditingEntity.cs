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
        public string? CreatedBy { get; set; } = null!;

        public DateTime? CreatedAt { get; set; } 


        public string? UpdatedBy { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; } 


        public string? DeletedBy { get; set; } = null!;

        public DateTime? DeletedAt { get; set; } 


        public ApplicationUser Creator { get; set; }

        public ApplicationUser Updater { get; set; }


        public ApplicationUser Deleter { get; set; }
    }
}
