using Autofac;
using Autofac.Integration.Mvc;
using AutofacExample.Core.Service.Impl;
using NHibernate;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Web;

namespace AutofacExample.Web.Ioc
{
    public class DependencySetup
    {
        public void AddDependencies(IContainer context, string connectionString)
        {
            Contract.Requires(context != null);
            Contract.Requires(connectionString != null);

            SessionSetup sessionSetup = new SessionSetup(connectionString);
            var sessionFactory = sessionSetup.GetSessionFactory();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(sessionFactory);

            // Either use a session in view model or per instance depending on the context.
            if (HttpContext.Current != null)
            {
                builder.Register(s => s.Resolve<ISessionFactory>().OpenSession()).InstancePerHttpRequest();
            }
            else
            {
                builder.Register(s => s.Resolve<ISessionFactory>().OpenSession());
            }

            AddServices(builder);
            builder.RegisterFilterProvider();
            builder.Update(context);
        }

        private static void AddServices(ContainerBuilder builder)
        {
            var serviceAssembly = Assembly.GetAssembly(typeof(DataService));
            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();
        }
    }
}