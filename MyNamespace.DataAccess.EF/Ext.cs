using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace.Repositories.EF.Impl
{
    static class Ext
    {
        public static bool IsNew(this EntityObject entity)
        {
            return entity.EntityKey == null || entity.EntityKey.IsTemporary;
        }
    }
}
