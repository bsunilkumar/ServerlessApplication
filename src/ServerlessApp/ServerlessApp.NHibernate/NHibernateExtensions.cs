using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using ServerlessApp.Repositories.Tenant.Mappings;
using ServerlessApp.Repositories.User.Mappings;
using System;
using System.Collections.Generic;
using ServerlessApp.Repositories;
using System.Text;

namespace ServerlessApp.NHibernate
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernatePostgreSQL(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(UserMap).Assembly.ExportedTypes);
            mapper.AddMappings(typeof(TenantMap).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {    
                //c.Driver<NpgsqlDriverExtended>();
                //c.Dialect<PostgresDialectExtension>();            
                c.Dialect<PostgreSQL82Dialect>(); 
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                //c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
           
            return services;
        }
    }
}
