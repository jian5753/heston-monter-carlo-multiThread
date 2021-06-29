using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hestonSimulation_multiThread
{
    class DimNotMatchException : Exception
    {
        public DimNotMatchException() { }
        public DimNotMatchException(string msg) : base(msg) { }
    }

    class NotImplementError : Exception
    {
        public NotImplementError() { }
        public NotImplementError(string msg) : base(msg) { }
    }

    class NoDataError : Exception
    {
        public NoDataError() { }
        public NoDataError(string msg) : base(msg) { }
    }
}
