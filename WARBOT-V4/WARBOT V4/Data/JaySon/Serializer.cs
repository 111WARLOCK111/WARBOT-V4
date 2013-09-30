using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SW = System.IO.StreamWriter;

namespace WARBOT_V4.Data.JaySon
{
    class Serializer
    {
        public static void Serialize(string data, string format, string file)
        {
            string[] getsplit = data.Split('/');
            string[] getform = format.Split('/');
            SW sw = new SW(file);
            sw.WriteLine("JaySon V1.0.0.1 Format");
            sw.WriteLine("{");
            int count = 0;
            foreach (string getd in getsplit)
            {
                sw.WriteLine("    \"" + getform[count] + "\"  \"" + getd + "\"");
                count = count + 1;
            }
            sw.Write("}");
            sw.Close();
        }
    }
}
