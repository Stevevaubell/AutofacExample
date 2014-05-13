
using AutofacExample.Core.Model;
using System.Collections.Generic;

namespace AutofacExample.Web.Models
{
    public class HomeViewModel
    {
        public IList<Contact> Contacts { get; set; }
    }
}