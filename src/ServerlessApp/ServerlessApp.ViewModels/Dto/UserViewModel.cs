using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ServerlessApp.Domain.User;
namespace ServerlessApp.ViewModels.Dto
{
    public class UserViewModel
    {
        [Key]
        public virtual Guid UserId { get; set; }

        //public virtual Tenant.Tenant Tenant { get; set; }

        [Required(ErrorMessage = "The Tenant Id is Required")]
        public virtual Guid TenantId { get; set; }

        [Required(ErrorMessage = "The User Name is Required")]
        [DisplayName("User Name")]
         public virtual string UserName { get; set; }

         [DisplayName("First Name")]
         [Required(ErrorMessage = "The User Name is Required")]
        public virtual string FirstName { get; set; }

         [DisplayName("Last Name")]
        public virtual string LastName { get; set; }

         [DisplayName("IsAdmin")]
        public virtual bool IsAdmin { get; set; }

         [DisplayName("IsSuperAdmin")]
        public virtual bool IsSuperAdmin { get; set; }

         [DisplayName("User Status")]
        public virtual UserStatusId UserStatus { get; set; }
        
         [DisplayName("Created Date")]
        public virtual DateTime CreatedDate { get; set; }
    }
}