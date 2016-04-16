using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Web.Framework.Svc
{
    public class SvcBusinessException : Exception
    {
        public SvcBusinessException()
        {
        }

        public SvcBusinessException(string message)
            : base(message)
        {
        }
    }  
}
