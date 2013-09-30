using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S = System.IO.StreamWriter;
using F = System.IO.File;

namespace WARBOT_V4
{
    class Classic
    {
        public static void Write(string msg)
        {
            string GetTime = "[" + DateTime.Now.ToString("hh:mm:ss") + "] ";
            string GetDate = "data/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            S sw = F.AppendText(GetDate);
            sw.WriteLine(GetTime + msg);
            sw.Close();
            Console.WriteLine(GetTime + msg);
        }
    }
}
