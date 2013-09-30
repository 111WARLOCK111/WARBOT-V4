using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meebey.SmartIrc4net;

namespace WARBOT_V4.Bot.Actions
{
    class Connect
    {
        public static void Answer(object sender, EventArgs e)
        {
            Classic.Write("Connected!");
            Classic.Write("Signing in...");
            Setup.irc.Login(Config.Nick, "WARBOT V4", 0, Config.Nick, Config.Password);
            Classic.Write("Signed in!");
            Classic.Write("Joining the channel...");
            if (Config.Channel.Contains(','))
            {
                foreach (var get in Config.Channel.Split(','))
                {
                    Setup.irc.RfcJoin(get);
                }
            }
            else
            {
                Setup.irc.RfcJoin(Config.Channel);
            }
            Classic.Write("Joined the channel!");
            Classic.Write("Listening...");
            Setup.irc.Listen();
            Classic.Write("Listened!");
        }
        public static void Try(object sender, EventArgs e)
        {
            Classic.Write("Connecting...");
        }
    }
}
