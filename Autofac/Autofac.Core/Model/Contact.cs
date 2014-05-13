using System;

namespace AutofacExample.Core.Model
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string RequestBody { get; set; }
        public virtual DateTime DateTimeRequested { get; set; }
    }
}
