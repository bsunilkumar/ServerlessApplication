using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ServerlessApp.Domain.Tenant;
using ServerlessApp.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessApp.Repositories.User.Mappings
{
    public class UserMap : ClassMapping<Domain.User.User>
    {
        public UserMap()
        {
            Id(x => x.UserId, map =>
            {
                map.Generator(Generators.Guid);
                map.Type(NHibernateUtil.Guid);
                map.Column("Id");
                map.UnsavedValue(Guid.Empty);
            });

            Property(x => x.UserName, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });
            Property(x => x.FirstName, map =>
            {
                map.Type(NHibernateUtil.String);
                map.NotNullable(false);
            });
            Property(x => x.LastName, map =>
            {
                map.Type(NHibernateUtil.String);
                map.NotNullable(false);
            });
            Property(x => x.IsAdmin, map =>
            {
                map.Type(NHibernateUtil.Boolean);
                map.NotNullable(true);
            });
            Property(x => x.IsSuperAdmin, map =>
            {
                map.Type(NHibernateUtil.Boolean);
                map.NotNullable(true);
            });
            Property(x => x.UserStatus, map =>
            {
                map.Column("userstatus_id");
                map.Type<EnumType<UserStatusId>>();
                //map.Type<EnumMapper<UserStatusId>>();
            });
           /* ManyToOne(x => x.Tenant, map =>
               {
                   map.Column("tenant_id");
                   map.Class(typeof(Domain.Tenant.Tenant));                   
                   map.Cascade(Cascade.All);
                   map.Fetch(FetchKind.Select);
               }); */
            Property(x => x.TenantId, map =>
            {
                map.Column("tenant_id");
                map.Type(NHibernateUtil.Guid);
                map.NotNullable(true);
            });
            Property(x => x.CreatedDate, map =>
            {
                map.Column("created_date");
                map.Type<CustomUtcType>();
                map.NotNullable(true);
            });
            Table("users");
            //DynamicUpdate(true);
            //SelectBeforeUpdate(true);
        }
    }
}
