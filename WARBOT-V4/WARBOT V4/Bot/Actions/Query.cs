using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meebey.SmartIrc4net;

namespace WARBOT_V4.Bot.Actions
{
    class Query
    {
        public static void Answer(object sender, IrcEventArgs e)
        {
            Classic.Write("(#PRIVATE) " + e.Data.Nick + ": " + e.Data.Message);
            try
            {
                Lua.Lua.lua.DoString(e.Data.Message);
            }
            catch (Exception ex)
            {
                Bot.Setup.irc.SendMessage(SendType.Message, e.Data.Nick, ex.ToString());
            }
        }
    }
}
