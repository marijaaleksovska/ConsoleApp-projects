using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common
{
    public class FlowException:Exception
    {
        public FlowException(string msg):base(msg)
        {

        }
    }
}
