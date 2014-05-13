using AutofacExample.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutofacExample.Core.Service
{
    public interface IDataService
    {
        Contact Get(int id);
        IList<Contact> GetAll();
        IList<Contact> Find(Expression<Func<Contact, bool>> expression);
        IList<Contact> FindDistinct(string columnName);
        void Delete(int id);
        void Save(Contact model);
    }
}
