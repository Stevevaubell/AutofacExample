using AutofacExample.Core.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AutofacExample.Web.Ioc
{
    public class SessionSetup
    {
        private readonly IPersistenceConfigurer _persistenceConfigurer;
        private SchemaExport _schemaExport;

        public SessionSetup(string connectionString)
        {
            _persistenceConfigurer = MsSqlConfiguration.MsSql2012
                                    .ConnectionString(connectionString)
                                    .AdoNetBatchSize(10);
        }

        public SessionSetup(IPersistenceConfigurer persistenceConfigurer)
        {
            _persistenceConfigurer = persistenceConfigurer;
        }

        public ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                            .Database(_persistenceConfigurer)
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contact>())
                            .BuildSessionFactory();
        }

        public void BuildSchema(ISession session)
        {
            _schemaExport.Execute(true, true, false, session.Connection, null);
        }
    }
}