
using AutofacExample.Core.Model;
using FluentNHibernate.Mapping;

namespace AutofacExample.Core.Mapping
{
    public class ContactMapping : ClassMap<Contact>
    {
        public ContactMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.RequestBody);
            Map(x => x.DateTimeRequested);
            Table("Contact");
        }
    }
}
