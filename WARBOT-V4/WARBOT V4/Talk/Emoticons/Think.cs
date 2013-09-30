using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WARBOT_V4.Talk.Emoticons
{
    class Think
    {
        public static bool Contains(string message)
        {
            bool hasemot = false;
            if (message.Contains(":D") ||
                message.Contains(":P") ||
                message.Contains(":O") ||
                message.Contains(":)") ||
                message.Contains("O:") ||
                message.Contains(":(") ||
                message.Contains("D:") ||
                message.Contains("P:"))
                hasemot = true;
            return hasemot;
        }
    }
}
