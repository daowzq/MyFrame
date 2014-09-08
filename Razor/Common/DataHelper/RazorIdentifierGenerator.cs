using NHibernate.Engine;
using NHibernate.Id;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Data
{
    public class RazorIdentifierGenerator : IIdentifierGenerator
    {
        // Methods
        public object Generate(ISessionImplementor session, object obj)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
