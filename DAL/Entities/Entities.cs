using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class modelEntities1
    {
        public modelEntities1(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}
