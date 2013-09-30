using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meebey.SmartIrc4net;
using F = System.IO.File;
using SW = System.IO.StreamWriter;

namespace WARBOT_V4.Data
{
    class Saver
    {
        public static List<String> TempList = new List<String>();
        public static void Save(string msg)
        {
                TempList.Add(msg);
        }

        public static void Init()
        {
            if (F.Exists("data/save.txt"))
            {
                Console.BackgroundColor = WARBOT_V4.Config.Warning;
                Classic.Write("Loading the bot...");
                Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
                foreach (string line in F.ReadAllLines("data/save.txt"))
                {
                    TempList.Add(line);
                }
                Console.BackgroundColor = WARBOT_V4.Config.Warning;
                Classic.Write("Loaded the bot!");
                Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
            }
            System.Timers.Timer save = new System.Timers.Timer(600000);
            save.Start();
            save.Elapsed += delegate
            {
                Console.BackgroundColor = WARBOT_V4.Config.Warning;
                Classic.Write("Saving the bot...");
                Classic.Write("NOTE: This might lag the bot for a while!");
                Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
                if (F.Exists("data/save.txt"))
                    F.Delete("data/save.txt");
                SW sw = new SW("data/save.txt");
                foreach (string str in TempList)
                {
                    sw.WriteLine(str);
                }
                sw.Close();
                Console.BackgroundColor = WARBOT_V4.Config.Warning;
                Classic.Write("Saved the bot!");
                Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
            };
        }

        public static string Load(string msg)
        {
            string rtn = "";
            string getms = msg.Replace("Is", "").Replace("What", "").Replace("Where", "").Replace("Who", "").Replace("Are", "").Replace("is", "").Replace("who", "").Replace("what", "").Replace("where", "").Replace("are", "").Replace("?", "").Replace("!", "");
            string[] getspl = getms.Split(' ');
            foreach (string s in getspl)
            {
                var search = TempList.FindAll(x => x.ToLower().Contains(s.ToLower()));
                foreach (var getone in search)
                {
                    rtn = getone;
                }
            }
            return rtn;
        }
    }
}
