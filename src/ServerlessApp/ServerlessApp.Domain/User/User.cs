using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessApp.Domain.User
{
    public class User
    {
        public virtual Guid UserId { get; set; }
        //public virtual Tenant.Tenant Tenant { get; set; }
        public virtual Guid TenantId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual bool IsSuperAdmin { get; set; }
        public virtual UserStatusId UserStatus { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
