using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meebey.SmartIrc4net;

namespace WARBOT_V4.Bot.Actions
{
    class Message
    {
        public static void Answer(object sender, IrcEventArgs e)
        {
            string msg = e.Data.Message;
            string chan = e.Data.Channel;
            string send = e.Data.Nick;
            if (send.Contains("Bot"))
            {
                if (msg.Contains(":"))
                {
                    send = msg.Split(':')[0];
                    msg = msg.Split(':')[1].Substring(1);
                }
            }
            Classic.Write("(" + chan + ") " + send + ": " + msg);
            if (msg.ToLower().StartsWith("lua::"))
            {
                if (msg.Length > 5)
                {
                    Lua.Lua.lua.DoString(msg.Substring(5));
                }
                return;
            }
            if (Talk.Emoticons.Think.Contains(msg))
            {
                Bot.Setup.irc.SendMessage(SendType.Message, chan, Talk.Emoticons.Say.Answer(msg));
            }
            else if (msg.ToLower().Contains("is"))
            {
                if (msg.ToLower().StartsWith("what") || msg.ToLower().StartsWith("who"))
                {
                    string getload = Data.Saver.Load(msg);
                    if (getload != "" && getload.ToLower() != msg.ToLower())
                    {
                        Classic.Write("(" + chan + ") WARBOT: " + getload);
                        Bot.Setup.irc.SendMessage(SendType.Message, chan, getload);
                    }
                }
                else
                {
                    Classic.Write("(" + chan + ") SAVED above AS msg IN TempList");
                    Data.Saver.Save(msg);
                }
            }
        }
    }
}
