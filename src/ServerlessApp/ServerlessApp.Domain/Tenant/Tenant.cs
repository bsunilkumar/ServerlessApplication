using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessApp.Domain.Tenant
{
    public class Tenant
    {
        public virtual Guid TenantId { get; set; }

        public virtual string Domain { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime UpdatedDate { get; set; }
    }
}
