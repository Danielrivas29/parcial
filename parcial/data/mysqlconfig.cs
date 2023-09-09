using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class mysqlconfig
    {
        public string _connectionstring;
        public mysqlconfig (string connectionstring)
        {
            _connectionstring = connectionstring;
        }
    }
}
