using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WARBOT_V4
{
    public class Status
    {
        public enum GetType
        {
            Shutdown = 0,
            Error = 1,
            Warning = 2,
            Medium = 3,
            Good = 4
        }
    }
}
