using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace.DataAccess.EF
{
    partial class Entities
    {
        public Entities(string nameOrConnectionString) : base(nameOrConnectionString)
        {
    		this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
