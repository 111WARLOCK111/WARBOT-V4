using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using luanet;
using System.IO;

namespace WARBOT_V4.Lua
{
    class Lua
    {
        public static lua51 lua;
        public static void Init()
        {
            lua = new lua51();
            lua.ConnectDotNet(Error, lua);
            lua.RegisterFunction("include", Include);
            lua.RegisterFunction("SendMessage", SendMessage);
            lua.RegisterFunction("Join", Join);
            lua.RegisterFunction("Quit", Part);
            if (File.Exists("data/libs.lua"))
            {
                lua.DoString(File.ReadAllText("data/libs.lua"));
            }
        }
        public static void Error(string err)
        {
            Config.ChangeStatus(Status.GetType.Warning, err);
        }
        public static int Include()
        {
            string getpath = lua.GetParameterString(1);
            if (File.Exists("data/" + getpath))
            {
                lua.DoString(File.ReadAllText("data/" + getpath));
            }
            return 0;
        }
        public static int SendMessage()
        {
            string chan = lua.GetParameterString(1);
            string mess = lua.GetParameterString(2);
            Bot.Setup.irc.SendMessage(Meebey.SmartIrc4net.SendType.Message, chan, mess);
            return 0;
        }
        public static int Join()
        {
            string chan = lua.GetParameterString(1);
            Bot.Setup.irc.RfcJoin(chan);
            return 0;
        }
        public static int Part()
        {
            string chan = lua.GetParameterString(1);
            Bot.Setup.irc.RfcPart(chan);
            return 0;
        }
        public static int Print()
        {
            string getmsg = lua.GetParameterString(1);
            Classic.Write(getmsg);
            return 0;
        }
    }
}
