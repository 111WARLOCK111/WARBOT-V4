using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using F = System.IO.File;
using D = System.IO.Directory;
using C = System.Console;

namespace WARBOT_V4
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Init();
            Lua.Lua.Init();
            if (!D.Exists("config/"))
            {
                D.CreateDirectory("config/");
            }
            if (!D.Exists("data/"))
            {
                D.CreateDirectory("data/");
            }
            if (!F.Exists("config/main.txt"))
            {
                C.WriteLine("Please enter the nickname of bot:");
                string getnick = C.ReadLine();
                C.WriteLine("Please enter the password of bot:");
                string getpass = C.ReadLine();
                C.WriteLine("Please enter the host of the bot:");
                string host = C.ReadLine();
                C.WriteLine("Please enter the port of the bot:");
                string port = C.ReadLine();
                C.WriteLine("Please enter the channel you want:");
                string chan = C.ReadLine();
                C.WriteLine("Saving the config...");
                Data.JaySon.Serializer.Serialize(getnick + "/" + getpass + "/" + host + "/" + port + chan, "nick/pass/host/port/channel", "config/main.txt");
                C.WriteLine("Saved the config!");
                Bot.Config.Nick = getnick;
                Bot.Config.Password = getpass;
                Bot.Config.Server = host;
                Bot.Config.Port = int.Parse(port);
            }
            else
            {
                string[] data = Data.JaySon.Deserializer.Deserialize("nick/pass/host/port/channel", "config/main.txt");
                Bot.Config.Nick = data[0];
                Bot.Config.Server = data[2];
                Bot.Config.Password = data[1];
                Bot.Config.Port = int.Parse(data[3]);
                Bot.Config.Channel = data[4];
            }
            Data.Saver.Init();
            Bot.Setup.Init();
        }
    }
}
