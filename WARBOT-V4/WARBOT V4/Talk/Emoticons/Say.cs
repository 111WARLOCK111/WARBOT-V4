using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WARBOT_V4.Talk.Emoticons
{
    class Say
    {
        public static string Answer(string getmsg)
        {
            string str = "";
            if (getmsg.Contains(":D"))
            {
                str = "D:";
            }
            else if (getmsg.Contains(":)"))
            {
                str = ":(";
            }
            else if (getmsg.Contains(":P"))
            {
                str = "P:";
            }
            else if (getmsg.Contains(":O"))
            {
                str = "O:";
            }
            else if (getmsg.Contains(":("))
            {
                str = ":)";
            }
            else if (getmsg.Contains("O:"))
            {
                str = ":O";
            }
            else if (getmsg.Contains("D:"))
            {
                str = ":D";
            }
            else if (getmsg.Contains("P:"))
            {
                str = ":P";
            }
            return str;
        }
    }
}
