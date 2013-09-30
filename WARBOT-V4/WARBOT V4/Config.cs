using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WARBOT_V4
{
    class Config
    {
        public static string Title = "WARBOT V4";
        public static string Description = "An amazing learning bot coded by !!!WARLOCK!!!";
        public static string Company = "!!!WARLOCK!!!";
        public static string Version = "0.0.8";
        public static string ConTitle = Title + " " + Version + " - Enjoy it!";
        public static ConsoleColor Default = ConsoleColor.White;
        public static ConsoleColor Error = ConsoleColor.Red;
        public static ConsoleColor Warning = ConsoleColor.DarkYellow;
        public static ConsoleColor DefaultB = ConsoleColor.Black;

        public static void Init()
        {
            Console.Title = ConTitle;
            Console.ForegroundColor = Default;
        }

        public static void ChangeStatus(Status.GetType type, string message)
        {
            if (type == Status.GetType.Shutdown)
            {
                ChangeTitle("Shutting down...");
                Console.BackgroundColor = Error;
                Console.ForegroundColor = Default;
                Classic.Write("Shutting down the server because of a huge error...");
                System.Timers.Timer sys = new System.Timers.Timer(1000);
                int count = 5;
                sys.Start();
                sys.Elapsed += delegate
                {
                    Classic.Write("In " + count + "...");
                    count = count - 1;
                    if (count == 0)
                    {
                        sys.Stop();
                        Classic.Write("Restarting...");
                        Process[] ps = Process.GetProcessesByName(Title);
                        Process.Start(Title + ".exe");
                        foreach (Process proc in ps)
                        {
                            proc.Kill();
                        }
                    }
                };
            }
            if (type == Status.GetType.Error)
            {
                Console.ForegroundColor = Error;
                Classic.Write("ERROR: " + message);
                Console.ForegroundColor = Default;
            }
            if (type == Status.GetType.Warning)
            {
                Console.ForegroundColor = Warning;
                Classic.Write("Warning: " + message);
                Console.ForegroundColor = Default;
            }
            if (type == Status.GetType.Medium)
            {
                Console.ForegroundColor = Warning;
                Classic.Write("There's a problem: " + message);
                Console.ForegroundColor = Default;
            }
            if (type == Status.GetType.Good)
            {
                Console.ForegroundColor = Default;
                Console.BackgroundColor = DefaultB;
                Classic.Write(message);
            }
        }

        private static void ChangeTitle(string msg)
        {
            ConTitle = Title + " " + Version + " - " + msg;
            Console.Title = ConTitle;
        }
    }
}
