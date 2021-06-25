using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hestonSimulation_multiThread
{
    class dimNotMatchException : Exception
    {
        public dimNotMatchException() { }

        public dimNotMatchException(string msg) : base(msg) { }
    }

    class notImplementError : Exception
    {
        public notImplementError() { }
        public notImplementError(string msg) : base(msg) { }
    }
}
