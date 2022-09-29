using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar
{
    public class ConnectionString
    {
        public string DataSourse { get; set; }

        public string InitialCatalog { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public bool MultipleActiveResultSets { get; set; }

        public string App { get; set; }

        public override string ToString()
        {
            return $"data source={DataSourse};initial catalog={InitialCatalog};User Id={UserId};Password={Password};MultipleActiveResultSets={MultipleActiveResultSets};App={App}";
        }

    }
}
