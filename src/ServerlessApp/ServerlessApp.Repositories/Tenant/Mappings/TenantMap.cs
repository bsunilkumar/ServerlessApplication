using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessApp.Repositories.Tenant.Mappings
{
    public class TenantMap : ClassMapping<Domain.Tenant.Tenant>
    {
       public TenantMap()
        {
            Id(x => x.TenantId, map =>
            {
                map.Generator(Generators.Guid);
                map.Type(NHibernateUtil.Guid);
                map.Column("Id");
                map.UnsavedValue(Guid.Empty);
            });

            Property(x => x.Name, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });

            Property(x => x.Description, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });

            Property(x => x.Domain, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });
            Property(x => x.CreatedDate, map =>
            {
                map.Column("created_date");
                map.Type<CustomUtcType>();
                map.NotNullable(true);
            });
            Table("tenants");
            DynamicUpdate(true);
            SelectBeforeUpdate(true);
        }
    }
}
