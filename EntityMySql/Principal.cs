using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityMySql
{

    public partial class leonuxEntities : DbContext
    {
        public leonuxEntities(string cns)
            : base(cns)
        {
        }
    }

}