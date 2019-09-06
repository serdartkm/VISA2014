using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace VISA2014.Module.BusinessObjects
{
    interface Interface1
    {

         XPCollection<AuditDataItemPersistent> changeHistory{get;}
    }
}
