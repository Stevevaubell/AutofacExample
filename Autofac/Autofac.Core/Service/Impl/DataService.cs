
using AutofacExample.Core.Model;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutofacExample.Core.Service.Impl
{
    public class DataService : IDataService
    {
        protected readonly ISession _session;

        public DataService(ISession session)
        {
            _session = session;
        }

        public Contact Get(int id)
        {
            return _session.QueryOver<Contact>().Where(x => x.Id == id).List().FirstOrDefault();
        }

        public IList<Contact> GetAll()
        {
            IList<Contact> items = _session.QueryOver<Contact>().List();
            return items ?? new List<Contact>();
        }

        public IList<Contact> Find(Expression<Func<Contact, bool>> expression)
        {
            return _session.QueryOver<Contact>().Where(expression).List<Contact>();
        }

        public IList<Contact> FindDistinct(string columnName)
        {
            ICriteria criteria = _session.CreateCriteria(typeof(Contact));
            criteria.SetProjection(
                Projections.Distinct(Projections.ProjectionList()
                    .Add(Projections.Alias(Projections.Property(columnName), columnName))));

            criteria.SetResultTransformer(
                new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Contact)));

            return criteria.List<Contact>();
        }

        public void Delete(int id)
        {
            Contact model = _session.QueryOver<Contact>().Where(x => x.Id == id).SingleOrDefault();
            _session.Delete(model);
            _session.Flush();
        }

        public void Save(Contact model)
        {
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(model);
                tx.Commit();
                _session.Flush();
            }
        }
    }
}
